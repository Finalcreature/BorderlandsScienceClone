using System.Collections.Generic;
using UnityEngine;

public class ArrowColumn : MonoBehaviour
{
    [SerializeField] ArrowTile emptyTile;
    [SerializeField] int numberOfCells;
    List<ArrowTile> arrows = new List<ArrowTile>();
    [SerializeField] UpArrowScript upArrow;
    
    void Start()
    {
        //Instantiate the amount of arrow cells based on the number of cells in the column
        for (int i = 0; i < numberOfCells; i++)
        {
            ArrowTile tile = Instantiate(emptyTile, new Vector2(transform.position.x, transform.position.y + i), Quaternion.identity) as ArrowTile;
            tile.transform.parent = transform;
            tile.name = "Tile " + (i + 1);
            arrows.Insert(i, tile); //Add the newly created tile into the list
        }

        GenerateArrows();
    }

    //Instantiate an arrow for each cell in the column
    void GenerateArrows()
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
