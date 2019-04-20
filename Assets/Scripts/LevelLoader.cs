using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 3;
    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(LoadSplashScreen());
        } 
    }
    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1f;
    }
    IEnumerator LoadSplashScreen()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadLevel("Start Screen");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
        Time.timeScale = 1f;
    }
}
