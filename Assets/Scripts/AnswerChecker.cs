using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public  StoryManager storyManager;

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckAnswer(string CorrectOrIncorrect)
    {
        if (CorrectOrIncorrect == "Correct")
           
        {
            print("Bien joué !");
            storyManager.ChangeStory();
        }
        else
        {
            print("T'es mauvais jack");
            storyManager.ChangeStory();
        }
    }
}

