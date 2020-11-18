using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text playerScoreText;
    [SerializeField] Text targetScoreText;
    [SerializeField] int targetScore;
    SpriteFinder[] spriteFinders;
    LevelLoader levelLoader;
    int[] scores;
    int totalScore;
    bool limitedArrows; 

    void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
        spriteFinders = FindObjectsOfType<SpriteFinder>();
        scores = new int[spriteFinders.Length];
        targetScoreText.text = targetScore.ToString();
        if(FindObjectOfType<ArrowColumn>())
        {
            limitedArrows = true;
        }
        else
        {
            limitedArrows = false;
        }
    }
    void Update()
    {
        for(int scoreIndex = 0; scoreIndex < spriteFinders.Length; scoreIndex++)
        {
        scores[scoreIndex] = spriteFinders[scoreIndex].GetScore();
        }
      
        playerScoreText.text = totalScore.ToString();
        if(targetScore <= totalScore)
        {
            levelLoader.LoadNextLevel();
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
     public bool isLimitedArrows()
     {
         return limitedArrows;
     }
     public int GetTotalScore()
     {
         return totalScore;
     }
}

