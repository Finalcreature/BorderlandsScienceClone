using UnityEngine;

public class SpriteScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.gray;
    }
}