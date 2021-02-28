using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    float timeToLoad;
    int activeScene;
    [SerializeField] Animator animator;
    
    void Start()
    {
        timeToLoad = 4;
        activeScene = SceneManager.GetActiveScene().buildIndex;

        //Ensure not to play the open transition in the main menu
        if(activeScene > 1)
        {
            animator.Play("Open");
        }
    }

    void Update()
    {
        //Load the main menu after splash screen timer runs out
        if(activeScene == 0)
        {
            timeToLoad -= Time.deltaTime;

            if(timeToLoad <= 0 && activeScene == 0)
            {
                SceneManager.LoadScene(activeScene + 1);
            }
        }
    }

    public void LoadNextLevel()
    {
       StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        animator.Play("Close");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(activeScene + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
