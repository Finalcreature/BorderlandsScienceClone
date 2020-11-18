using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    ColumnScript[] ColumnScript;
    public List<TileScript> tiles;
    [SerializeField] UpArrowScript arrow;
    SpriteFinder[] spriteFinders;
    int columnIndex;
    Score score;
  
    private void Start()
    {
        columnIndex = 0;
        SetColumn();
        spriteFinders = FindObjectsOfType<SpriteFinder>();
        score = FindObjectOfType<Score>();
        
     }

    private void Update() {
           foreach (SpriteFinder spriteFinder in spriteFinders)
        {
            spriteFinder.SetScore();
            
        }
         score.SetTotalScore();  
    }

    private void SetColumn()
    {
        ColumnScript = FindObjectsOfType<ColumnScript>();
        if (ColumnScript[columnIndex].transform.position.x == transform.position.x)
        {
            tiles = ColumnScript[columnIndex].GetTileScript();
        }
        else
        {
            columnIndex++;
            SetColumn();
           
        }
    }


    private void OnMouseDown()
    {
      int tileIndex = tiles.IndexOf(this);
      int lastIndex = tiles.Count-1;
      
      if(tileIndex != lastIndex) // Check if current tile is the top one in the column
      {
          if(transform.childCount != 0) // Check if tile is not empty
          {
              
              if(transform.GetChild(0).GetComponent<UpArrowScript>()) // Check if tile has an arrow in it
                {
                    ArrowPressed(tileIndex, lastIndex);
                }
                else // Will execute if tile has a sprite in it
                {
                    SpritePressed(tileIndex, lastIndex);
                }
            }
      }
    }

    private void SpritePressed(int tileIndex, int lastIndex)
    {
        if (tiles[lastIndex].transform.childCount == 0)
        {
           
            UpArrowScript arrowUp = Instantiate(arrow, transform.position, Quaternion.identity) as UpArrowScript;
            arrowUp.transform.parent = transform;

            for (int i = lastIndex; i >= tileIndex; i--)
            {
               
                if (tiles[i].transform.childCount != 0 /*&&  tiles[i].transform.parent == transform*/)
                {
                     tiles[i].transform.GetChild(0).position += new Vector3(0, 1);
                     tiles[i].transform.GetChild(0).transform.parent = tiles[i + 1].transform;
                }
            }
           
        }
    }

    private void ArrowPressed(int tileIndex, int lastIndex)
    {
        transform.GetChild(0).GetComponent<UpArrowScript>().DestroyArrow();

        for (int i = lastIndex; i > tileIndex; i--)
        {
            if (tiles[i].transform.childCount != 0)
            {
                tiles[i].transform.GetChild(0).position -= new Vector3(0, 1);
                tiles[i].transform.GetChild(0).transform.parent = tiles[i - 1].transform;
            }
        }
    }
}