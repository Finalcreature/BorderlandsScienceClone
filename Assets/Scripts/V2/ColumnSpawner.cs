using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColumnSpawner : MonoBehaviour
{
   
    [SerializeField] Text playerScoreText;
    [SerializeField] Text targetScoreText;
    [SerializeField] int targetScore;
    SpriteFinder[] spriteFinders;
    int[] scores;
    int totalScore;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteFinders = FindObjectsOfType<SpriteFinder>();
        scores = new int[spriteFinders.Length];
        targetScoreText.text = targetScore.ToString();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        for(int scoreIndex = 0; scoreIndex < spriteFinders.Length; scoreIndex++)
        {
        scores[scoreIndex] = spriteFinders[scoreIndex].GetScore();
        }
      
        playerScoreText.text = totalScore.ToString();
        if(targetScore <= totalScore)
        {
            Debug.Log("You Win");
        }
     }

    public void SetTotalScore()
     {
         totalScore = 0;
           foreach(int score in scores)
        {
            totalScore += score; 
        }
     }
}
