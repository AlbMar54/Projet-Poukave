using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StoryManager : MonoBehaviour
{
    public AnswerChecker answerChecker;
    public FontManager fontManager;
    public TextAsset storycsv;
    public TextMeshProUGUI textSpeakerUp;
    public TextMeshProUGUI textSpeakerDown;
    float textSpeedSpeakerUp;
    float textSpeedSpeakerDown;
    string[,] storyGrid;
    int indexSpeakerUp;
    int indexSpeakerDown;
    string trueAnswer;
    float timerBeforeChangingDialog;
    int randomStory;
    int randomStoryIndex;
    List<int> storyIndexList = new List<int>();
    ActiveSpeaker activeSpeaker = ActiveSpeaker.ActiveSpeakerUp;

    // Start is called before the first frame update
    void Start()
    {
        storyGrid = CSVReader.SplitCsvGrid(storycsv.text);
        print(storyGrid.GetLength(0) + " " + storyGrid.GetLength(1));
        textSpeakerUp.text = "";
        textSpeakerDown.text = " ";

        for (int i = 1; i < storyGrid.GetLength(1); i++)
        {
            if (storyGrid[0, i] != "")
            {
                storyIndexList.Add(i);
            }

        }
        foreach (int storyIndex in storyIndexList)
        {
            print(storyIndex);
        }

        ChangeStory();
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
        Invoke("ChangeSpeaker", 1);
    }
    public void ChangeSpeaker()
    {

        {
            switch (activeSpeaker)
            {
                case ActiveSpeaker.ActiveSpeakerUp:

                    activeSpeaker = ActiveSpeaker.ActiveSpeakerDown;
                    indexSpeakerUp += 2;
                    DisplayText();
                    break;

                case ActiveSpeaker.ActiveSpeakerDown:
                    activeSpeaker = ActiveSpeaker.ActiveSpeakerUp;
                    indexSpeakerDown += 2;
                    DisplayText();
                    break;

            }
        }
    }


    public void ChangeStory()
    {
        StopAllCoroutines();
        //activeSpeaker = ActiveSpeaker.NoActiveSpeaker; A CONTINUER 
        //textSpeakerUp.text = " ";
        //textSpeakerDown.text = " ";
        randomStoryIndex = UnityEngine.Random.Range(0, storyIndexList.Count);
        //print(randomStoryIndex);
        randomStory = storyIndexList[randomStoryIndex];//c'est la LIGNE de l'histoire
        storyIndexList.RemoveAt(randomStoryIndex);
        //print(randomStory);
        indexSpeakerUp = randomStory;
        indexSpeakerDown = randomStory + 1;//psq le locuteur du bas commence une ligne en dessous
        //print(indexSpeakerDown);
        //print(storyGrid.GetLength(0)+" "+ storyGrid.GetLength(1));
        //print(storyGrid[12, indexSpeakerDown]);
        print("randomStory =");
        print(randomStory);
        textSpeedSpeakerUp = float.Parse(storyGrid[7, indexSpeakerUp]);
        textSpeedSpeakerDown = float.Parse(storyGrid[12, indexSpeakerDown]);
        textSpeedSpeakerUp = textSpeedSpeakerDown / 10; // à retirer après testing
        textSpeedSpeakerDown = textSpeedSpeakerDown / 10; // à retirer après testing
        fontManager.GivingTextFont(randomStory);
        trueAnswer= storyGrid[4, randomStory];
        
        DisplayText();

    }
    public void DisplayText()
    {

        if (textSpeakerUp.text == "*Raccroche*")
        {
            CancelInvoke("ChangeSpeaker");
            textSpeakerUp.text = " ";
            textSpeakerDown.text = " ";
            print("Fin de l'histoire, appuyez sur ENTRER");
            activeSpeaker = ActiveSpeaker.NoActiveSpeaker;
            if (Input.GetKey(KeyCode.KeypadEnter))
            {
                ChangeStory();
            }



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
                   StartCoroutine(TestTextDefile(textSpeakerUp, storyGrid[15, indexSpeakerUp], textSpeedSpeakerUp));
                    textSpeakerDown.text = " ";
                    
                    break;
                }

            case ActiveSpeaker.ActiveSpeakerDown:
                {
                    
                    StartCoroutine(TestTextDefile(textSpeakerDown, storyGrid[15, indexSpeakerDown], textSpeedSpeakerDown));
                    textSpeakerUp.text = " ";
                    
                    break;
                }
        }
    }


    public void GivenAnswerGoulag()
    {
        if (trueAnswer == "Traître")
        {
            answerChecker.CheckAnswer("Correct");
        }
        else
        {
            answerChecker.CheckAnswer("Incorrect");
        }
    }

      public void GivenAnswerCamarade()
        {
            if (trueAnswer == "Traître")
            {
                answerChecker.CheckAnswer("Incorrect");
            }
            else
            {
                answerChecker.CheckAnswer("Correct");
            }


        }
}



 

