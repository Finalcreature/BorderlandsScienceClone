using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowColumn : MonoBehaviour
{
    [SerializeField] ArrowTile Emptytile;
    [SerializeField] int numberOfCells;
    List<ArrowTile> arrows = new List<ArrowTile>();
    [SerializeField] UpArrowScript upArrow;
    
    void Start()
    {
            for (int i = 0; i < numberOfCells; i++)
        {
            ArrowTile tile = Instantiate(Emptytile, new Vector2(transform.position.x, transform.position.y + i), Quaternion.identity) as ArrowTile;
            tile.transform.parent = transform;
            tile.name = "Tile " + (i + 1);
            arrows.Insert(i, tile);

        }
            GenerateAuto();
          
    }
    void GenerateAuto()
    {
            for (int arrowIndex = 0; arrowIndex < numberOfCells; arrowIndex++)
            {

                UpArrowScript arrow = Instantiate(upArrow,arrows[arrowIndex].transform.position, Quaternion.identity);
                arrow.transform.parent = arrows[arrowIndex].transform;           
            }
    }     
    
    public int GetNumOfArrows()
    {
        return arrows.Count;
    }

    public List<ArrowTile> GetArrowsTiles()
    {
        return arrows;
    }


}  
