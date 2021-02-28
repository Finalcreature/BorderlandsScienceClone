using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text playerScoreText;
    [SerializeField] Text targetScoreText;
    [SerializeField] int targetScore;
    SpriteFinder[] spriteFinders;
    LevelLoader levelLoader;
    int[] scores; //Holds the score of each sprite finder
    int totalScore;
    bool isLimitedArrows; 

    void Start()
    {
        //Set references
        levelLoader = FindObjectOfType<LevelLoader>();
        spriteFinders = FindObjectsOfType<SpriteFinder>();

        //Set the scores to the number of sprite finders
        scores = new int[spriteFinders.Length];

        targetScoreText.text = targetScore.ToString();

        //If there is an ArrowColumn it means that there is a limited of arrows that can be used
        if(FindObjectOfType<ArrowColumn>())
        {
            isLimitedArrows = true;
        }
        else
        {
            isLimitedArrows = false;
        }
    }

    //TODO see if I can get those actions outside the Update func
    void Update()
    {
        //Get the score of each sprite finder and print the cumulative amount 
        for (int scoreIndex = 0; scoreIndex < spriteFinders.Length; scoreIndex++)
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
        totalScore = 0; //Reset the amount to recalculate all the scores from the sprite finders from scratch
        foreach(int score in scores)
        {
            totalScore += score; 
        }
     }

     public bool LimitedArrowsChecker()
     {
         return isLimitedArrows;
     }

     public int GetTotalScore()
     {
         return totalScore;
     }
}

