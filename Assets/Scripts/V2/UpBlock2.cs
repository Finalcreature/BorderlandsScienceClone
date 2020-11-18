using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBlock2 : MonoBehaviour
{
  GameTile gameTile;
  List<UpBlock> blocks;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        
    //     FindObjectOfType<GameTile>().transform.position = gameTile.blocks[gameTile.blocks.Count-1].transform.position;
        

    //     foreach (UpBlock block in gameTile.blocks)
    //     {
    //         int thisIndex = gameTile.blocks.IndexOf(this);
    //         int index = gameTile.blocks.IndexOf(block);
    //         if(index > thisIndex)
    //         {
    //             Debug.Log("UpperBlock " + index + " ClickedBlock " + thisIndex);
    //         block.transform.position -= new Vector3(0,1);
    //         }
    //     }

    //     gameTile.blocks.Remove(this);

    //     Destroy(gameObject);
    // }

    // public void InsertBlock(UpBlock blockl)
    // {

    // }
}
      public void InsertBlock(UpBlock2 block)
    {
        
    }
}
