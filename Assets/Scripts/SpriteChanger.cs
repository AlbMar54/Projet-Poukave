using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //pas oublier à importer  avec les UI

public class SpriteChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> SpritesList;
    int currentIndexList;
    public Image image;
    void Start()
    {
        
             
    }

    // Update is called once per frame
    void Update()
    {
        }

    public void ChangeSprite() 
    {
        if (currentIndexList == 0)
        {
            image.sprite = SpritesList[1];
            currentIndexList = 1;
        }
        
        else
        {
            image.sprite = SpritesList[0];
            currentIndexList = 0;
        }
    }
}
