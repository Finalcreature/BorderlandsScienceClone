using System.Collections.Generic;
using UnityEngine;

public class SpriteFinder : MonoBehaviour
{
    public int score;
     SpriteScript[] sprites;
     SpriteFinder twinFinder;
     SpriteFinder[] spriteFinders;

    void Start()
    {
        spriteFinders = FindObjectsOfType<SpriteFinder>();
        score = 0;

        for (int i = 0; i < spriteFinders.Length; i++)
        {   
            if(spriteFinders[i].transform.position.y == transform.position.y && name != spriteFinders[i].name)
            {
                twinFinder = spriteFinders[i];
            }
        }     
    }
 
    void Update()
    {   
       sprites = FindObjectsOfType<SpriteScript>();  
    }

    public void SetScore()
    {
        List<SpriteScript> spriteScript = new List<SpriteScript>();
        
        foreach(SpriteScript sprite in sprites)
        {
           if(!twinFinder)
           {
               if(sprite.transform.position.y == transform.position.y)
               { 
                    if( sprite.GetComponent<SpriteRenderer>().sprite.name ==  GetComponent<SpriteRenderer>().sprite.name)
                    {
                        spriteScript.Add(sprite);
                        sprite.GetComponent<SpriteRenderer>().color = Color.white;
                    }
                    else
                    {
                        sprite.GetComponent<SpriteRenderer>().color = Color.gray;
                    }  
               }      
           }

        else
        {
           
            if(sprite.transform.position.y == transform.position.y && sprite.GetComponent<SpriteRenderer>().sprite.name ==  GetComponent<SpriteRenderer>().sprite.name)
            {
                spriteScript.Add(sprite);
                sprite.GetComponent<SpriteRenderer>().color = Color.white;    
            }
            else if(sprite.transform.position.y == twinFinder.transform.position.y && sprite.GetComponent<SpriteRenderer>().sprite.name ==  twinFinder.GetComponent<SpriteRenderer>().sprite.name)
            {
                sprite.GetComponent<SpriteRenderer>().color = Color.white;
            }
            else if(sprite.transform.position.y == transform.position.y)
            {
                 sprite.GetComponent<SpriteRenderer>().color = Color.gray;
            }
        }    

        score = spriteScript.Count;      
        }
    }

    public int GetScore()
    {
        return score ;
    }
}