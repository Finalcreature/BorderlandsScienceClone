using System.Collections.Generic;
using UnityEngine;


public class ManualColumn : MonoBehaviour
{
    [SerializeField] ManualTile emptyTile; //// The prefab tile that will hold the sprites
    [SerializeField] int numberOfCells;
    List<ManualTile> tiles = new List<ManualTile>();
    [SerializeField] List<GameObject> spriteInColumn;
    
    void Start()
    {
        for (int i = 0; i < numberOfCells; i++)
        {
            ManualTile tile = Instantiate(emptyTile, new Vector2(transform.position.x, transform.position.y + i), Quaternion.identity) as ManualTile;
            tile.transform.parent = transform;
            tile.name = "Tile " + (i + 1);
            tiles.Insert(i, tile);
        }

        GenerateSprites();    
    }

    void GenerateSprites()
    {

      if(spriteInColumn.Count != 0)
        {
            for (int spriteIndex = 0; spriteIndex < spriteInColumn.Count; spriteIndex++)
            {

                GameObject sprite = Instantiate(spriteInColumn[spriteIndex],tiles[spriteIndex].transform.position, Quaternion.identity);
                sprite.transform.parent = tiles[spriteIndex].transform;           
            }
       }
    }     
    public List<ManualTile> GetTileScript()
    {
        return tiles;
    }
}  
    

    


