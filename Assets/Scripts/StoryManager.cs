using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public TextAsset storycsv;
    string[,] storyGrid;
    // Start is called before the first frame update
    void Start()
    {
        storyGrid = CSVReader.SplitCsvGrid(storycsv.text);
        print(storyGrid[0,1]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
