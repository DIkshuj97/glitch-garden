using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] int timetowait = 4;
    int currentsceneindex;

    // Start is called before the first frame update
    void Start()
    {
        currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        if (currentsceneindex==0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timetowait);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentsceneindex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionMenu()
    { 
        SceneManager.LoadScene("Option Screen");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentsceneindex + 1);
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

