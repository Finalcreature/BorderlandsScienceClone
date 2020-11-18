using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCounter : MonoBehaviour
{
    [SerializeField] ArrowColumn arrowColumn;
    int numOfArrows;
    // Start is called before the first frame update
    void Start()
    {
      numOfArrows = arrowColumn.GetNumOfArrows();
    }
}
