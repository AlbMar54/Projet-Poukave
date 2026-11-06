using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StoryManager : MonoBehaviour
{
    public TextAsset storycsv;
    public TextMeshProUGUI textSpeakerUp;
    public TextMeshProUGUI textSpeakerDown;
    string[,] storyGrid;
    // Start is called before the first frame update
    void Start()
    {
        storyGrid = CSVReader.SplitCsvGrid(storycsv.text);
        textSpeakerDown.text = (storyGrid[13,1]);
        print(storyGrid[13, 1]);
        //Invoke() 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
