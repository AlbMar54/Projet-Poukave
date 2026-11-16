using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StoryManager : MonoBehaviour
{
    public TextAsset storycsv;
    public TextMeshProUGUI textSpeakerUp;
    public TextMeshProUGUI textSpeakerDown;
    public float textSpeedSpeakerUp;
    public float textSpeedSpeakerDown; //pour le testing
    string[,] storyGrid;
    //float textSpeedSpeakerUp;
    //float textSpeedSpeakerDown;
    public RectTransform rectTransformTextSpeakerUp;
    public RectTransform rectTransformTextSpeakerDown;
    int indexSpeakerUp = 1;
    int indexSpeakerDown = 0;
    float timerBeforeChangingDialog;
    ActiveSpeaker activeSpeaker = ActiveSpeaker.ActiveSpeakerUp;

    // Start is called before the first frame update
    void Start()
    {
        storyGrid = CSVReader.SplitCsvGrid(storycsv.text);
        //print(storyGrid.GetLength(0) + " " + storyGrid.GetLength(1));
        textSpeakerDown.text = " ";
        //textSpeedSpeakerUp = float.Parse(storyGrid[17,1]);
        //textSpeedSpeakerDown = float.Parse(storyGrid[12,1]); //pour convertir un string en float
        timerBeforeChangingDialog = float.Parse(storyGrid[17,2]);
        StartCoroutine(TestTextDefile(textSpeakerUp, storyGrid[15, indexSpeakerUp], textSpeedSpeakerUp));
        Invoke("ChangeSpeaker", timerBeforeChangingDialog);
                
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public IEnumerator TestTextDefile(TextMeshProUGUI textMeshProUGUI, string textToDisplay, float delayDuration)
    {
        textMeshProUGUI.text = "";
        foreach (char character in textToDisplay)
        {
            textMeshProUGUI.text += character;
            yield return new WaitForSeconds(delayDuration);
        }
    }
    public void ChangeSpeaker()
    {
        
        {
            switch (activeSpeaker)
            {
                case ActiveSpeaker.ActiveSpeakerUp:

                    activeSpeaker = ActiveSpeaker.ActiveSpeakerDown;
                    Invoke("DisplayText", 0);
                    break;

                case ActiveSpeaker.ActiveSpeakerDown:
                    activeSpeaker = ActiveSpeaker.ActiveSpeakerUp;
                    Invoke("DisplayText", 0);
                    break;

            }
        }
    }

    public void DisplayText()
    {
        if (textSpeakerUp.text == "*Raccroche*")
        {
            CancelInvoke("ChangeSpeaker");
            textSpeakerUp.text = " ";
            textSpeakerDown.text = " ";
            print("Fin de l'histoire");
            activeSpeaker = ActiveSpeaker.NoActiveSpeaker;
            //ajouter son raccroche
            //calculer score
        }
        
        if (textSpeakerDown.text == "*Raccroche*")
        {
            CancelInvoke("ChangeSpeaker");
            textSpeakerUp.text = " ";
            textSpeakerDown.text = " ";
            print("Fin de l'histoire");
            activeSpeaker = ActiveSpeaker.NoActiveSpeaker;
            //calculer score
        }
               switch (activeSpeaker)
                {
                    case ActiveSpeaker.ActiveSpeakerUp:
                        {
                            indexSpeakerUp += 2;
                            textSpeakerDown.text = " ";
                            StartCoroutine(TestTextDefile(textSpeakerUp, storyGrid[15, indexSpeakerUp], textSpeedSpeakerUp));
                            Invoke("ChangeSpeaker", timerBeforeChangingDialog);
                            break;
                        }

                    case ActiveSpeaker.ActiveSpeakerDown:
                        {
                            indexSpeakerDown += 2;
                            textSpeakerUp.text = " ";
                            StartCoroutine(TestTextDefile(textSpeakerDown, storyGrid[15, indexSpeakerDown], textSpeedSpeakerDown));
                            Invoke("ChangeSpeaker", timerBeforeChangingDialog);
                            break;
                        }
                }
            }
        }
 

