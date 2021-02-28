using System.Collections.Generic;
using UnityEngine;

public class ArrowTile : MonoBehaviour
{ 
    ArrowColumn arrowColumn;
    List<ArrowTile> arrowTiles = new List<ArrowTile>();
    [SerializeField] UpArrowScript arrow;
    int numberOfArrows;
    int bottomArrow;
    int lastIndex; //When using countdown to prevent counting the bottom tile
    
       private void Start()
    {
        SetColumn();
        numberOfArrows = arrowColumn.GetNumOfArrows();
        bottomArrow = arrowTiles.IndexOf(arrowTiles[0]);
        lastIndex = arrowTiles.Count - 1;
    }

    private void SetColumn()
    {
        arrowColumn = FindObjectOfType<ArrowColumn>();     
        arrowTiles = arrowColumn.GetArrowsTiles();  
    }

    public void DecreaseArrow()
    {     
        arrowTiles[bottomArrow].transform.GetChild(0).GetComponent<UpArrowScript>().DestroyArrow();
        for (int i = lastIndex; i >= bottomArrow; i--)
        {
            if (arrowTiles[i].transform.childCount != 0 && arrowTiles[i] != arrowTiles[bottomArrow]) //Ensure the tile has a child and that it's not the bottom tile
            {  
                arrowTiles[i].transform.GetChild(0).position -= new Vector3(0, 1);
                arrowTiles[i].transform.GetChild(0).transform.parent = arrowTiles[i - 1].transform;
            }
        }

        numberOfArrows--;
    }

    public void IncreaseArrow()
    {
        for (int i = lastIndex; i >= bottomArrow; i--)
        {
            if (arrowTiles[i].transform.childCount != 0) //Ensure the tile has a child 
            {
                arrowTiles[i].transform.GetChild(0).position += new Vector3(0, 1);
                arrowTiles[i].transform.GetChild(0).transform.parent = arrowTiles[i + 1].transform;
            }
        }

        UpArrowScript arrowUp = Instantiate(arrow, arrowTiles[0].transform.position, Quaternion.identity) as UpArrowScript;
        arrowUp.transform.parent = arrowTiles[0].transform;
        numberOfArrows++;  
    }

    public int GetRemainingArrows()
    {
        return numberOfArrows;
    }
}

