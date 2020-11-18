using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }
}