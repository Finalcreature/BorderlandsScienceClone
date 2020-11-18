using System.Collections;
using System.Collections.Generic;
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
        if(activeScene > 1)
        {
            animator.Play("Open");
        }
    }

    void Update()
    {
        timeToLoad -= Time.deltaTime;
        if(timeToLoad <= 0 && activeScene == 0)
        {
            SceneManager.LoadScene(activeScene + 1);
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
