using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBlock : MonoBehaviour
{
    GameTile gameTile;
    // Start is called before the first frame update
    void Start()
    {
        gameTile = FindObjectOfType<GameTile>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
        FindObjectOfType<GameTile>().transform.position = gameTile.blocks[gameTile.blocks.Count-1].transform.position;
        

        foreach (UpBlock block in gameTile.blocks)
        {
            int thisIndex = gameTile.blocks.IndexOf(this);
            int index = gameTile.blocks.IndexOf(block);
            if(index > thisIndex)
            {
             //Debug.Log("UpperBlock " + index + " ClickedBlock " + thisIndex);

             Debug.Log(block.transform.position);   
             block.transform.position -= new Vector3(0,1);
            }
        }

        gameTile.blocks.Remove(this);

        Destroy(gameObject);
    }

  
}
