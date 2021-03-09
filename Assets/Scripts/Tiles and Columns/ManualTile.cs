using System.Collections.Generic;
using UnityEngine;

public class ManualTile : MonoBehaviour
{
    ManualColumn[] columnScript;
    public List<ManualTile> tiles;
    [SerializeField] UpArrowScript arrow;
    SpriteFinder[] spriteFinders;
    int columnIndex;
    Score score;
    ArrowTile arrowTile;

    private void Start()
    {
        //Set column
        columnIndex = 0;
        SetColumn();

        //Get references
        spriteFinders = FindObjectsOfType<SpriteFinder>();
        score = FindObjectOfType<Score>();
        arrowTile = FindObjectOfType<ArrowTile>();
     }
    
    private void Update()
     {
        if(score.GetTotalScore() == 0)
        {
            foreach (SpriteFinder spriteFinder in spriteFinders)   //Check a way to move that code from Update
            {
                spriteFinder.SetScore();
            }
        }

        score.SetTotalScore();  
    }

    //Checking each list of tiles if they are in the same position as the column, aka in the column itself
    private void SetColumn()
    {
        columnScript = FindObjectsOfType<ManualColumn>();
        if (columnScript[columnIndex].transform.position.x == transform.position.x)
        {
            tiles = columnScript[columnIndex].GetTileScript(); 
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

        //Update score
        foreach (SpriteFinder spriteFinder in spriteFinders)
        {
            spriteFinder.SetScore();
            
        }
        score.SetTotalScore();  
    }

    private void SpritePressed(int tileIndex, int lastIndex)
    {
        if(score.LimitedArrowsChecker())
        {
            if (tiles[lastIndex].transform.childCount == 0 && arrowTile.GetRemainingArrows() > 0) //Ensure arrows remaining and top tile is empty
            {
                IntantiateArrow(tileIndex, lastIndex);
                arrowTile.DecreaseArrow();

            }
        }
        else if (tiles[lastIndex].transform.childCount == 0) //Ensure top tile is empty
        {
              IntantiateArrow(tileIndex, lastIndex);
        }     
    }

    private void IntantiateArrow(int tileIndex, int lastIndex)
    {
        UpArrowScript arrowUp = Instantiate(arrow, transform.position, Quaternion.identity) as UpArrowScript;
        arrowUp.transform.parent = transform;

        for (int i = lastIndex; i >= tileIndex; i--)
        {

            if (tiles[i].transform.childCount != 0)
            {
                tiles[i].transform.GetChild(0).position += new Vector3(0, 1);
                tiles[i].transform.GetChild(0).transform.parent = tiles[i + 1].transform;
            }
        }
    }

    private void ArrowPressed(int tileIndex, int lastIndex)
    {
        if(score.LimitedArrowsChecker())
        {
            arrowTile.IncreaseArrow();
        }    
        
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