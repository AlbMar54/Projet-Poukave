using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FontManager : MonoBehaviour
{
    public TextAsset storycsv;
    public TextMeshProUGUI textSpeakerUp;
    public TextMeshProUGUI textSpeakerDown;
    public TMP_FontAsset russianFont;
    public TMP_FontAsset germanFont;
    string wantedFontUp;
    string wantedFontDown;
    string[,] storyGrid;
    public StoryManager storyManager;
    // Start is called before the first frame update
    void Start()
    {
        storyGrid = CSVReader.SplitCsvGrid(storycsv.text);
        //print(storyGrid.GetLength(0) + " " + storyGrid.GetLength(1));
        

    }


    void Update()
    {
        

    }

    public void GivingTextFont(int randomStory)
    {
        wantedFontUp = storyGrid[6, randomStory]; //à remplacer par un paramètre index
        if (wantedFontUp == "Cyrillique")
        {
            textSpeakerUp.font = russianFont;
        }

        if (wantedFontUp == "Allemand")
        {
            textSpeakerUp.font = germanFont;
        }

        wantedFontDown = storyGrid[11, randomStory]; //à remplacer par un paramètre index
        if (wantedFontUp == "Cyrillique")
        {
            textSpeakerDown.font = russianFont;
        }

        if (wantedFontDown == "Allemand")
        {
            textSpeakerDown.font = germanFont;
        }
    }
}
