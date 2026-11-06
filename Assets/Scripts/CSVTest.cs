using UnityEngine;
using System.Collections;

public class CSVTest : MonoBehaviour {

    public TextAsset csv;
    public TextMesh text;
    string[,] dataArray;

	// Use this for initialization
	void Start () {
        dataArray = CSVReader.SplitCsvGrid(csv.text);

        text.text = dataArray[2, 0];
                
        //Debug.Log(RobotCaracs.robotCaracs[dataArray[4,2]]);
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
