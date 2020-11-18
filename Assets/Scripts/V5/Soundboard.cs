using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundboard : MonoBehaviour
{
    private void Awake()
    {
         DontDestroyOnLoad(gameObject);
    }
}
