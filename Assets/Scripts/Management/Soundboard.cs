using UnityEngine;

public class Soundboard : MonoBehaviour
{
    private void Awake()
    {
         DontDestroyOnLoad(gameObject);
    }
}
