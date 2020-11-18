using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile : MonoBehaviour
{
    [SerializeField] UpBlock block;
    public List<UpBlock> blocks;
    
    
    private void OnMouseDown()
    {
        Vector3 tilePos = transform.position;
        transform.position += new Vector3(0,1);
        UpBlock newBlock = Instantiate(block, tilePos, Quaternion.identity) as UpBlock;
        blocks.Insert(blocks.Count, newBlock);
    }
}
