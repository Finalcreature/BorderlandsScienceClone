using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnScript : MonoBehaviour
{
    [SerializeField] TileScript Emptytile; 
    [SerializeField] int numberOfCells;
    [SerializeField] List<GameObject> sprites;
    List<TileScript> tiles = new List<TileScript>();

    void Start()
    {
        numberOfCells = 5;
        for (int i = 0; i < numberOfCells; i++)
        {
           TileScript tile = Instantiate(Emptytile, new Vector2(transform.position.x, transform.position.y + i), Quaternion.identity) as TileScript;
            tile.transform.parent = transform;
            tile.name = "Tile " + (i + 1);
            tiles.Insert(i, tile);
        }
        foreach (TileScript tile in tiles)
        {
            int tileLastIndex = tiles.Count - 1;
            int tileIndex = tiles.IndexOf(tile);
            if(tileIndex < tileLastIndex - 1)
            {
            GameObject sprite = Instantiate(sprites[0], tile.transform.position, Quaternion.identity);
            sprite.transform.parent = tile.transform;
            }
        }
    }
    public int GetNumberOfCells()
    {
        return numberOfCells;
    }

    public List<TileScript> GetTileScript()
    {
        return tiles;
    }
}
