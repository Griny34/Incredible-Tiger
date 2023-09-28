using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserInterfase : MonoBehaviour
{
    public void PlayGame()
    {
        //int currentIndexScen = SceneManager.GetActiveScene().buildIndex;

        string nameCurrentScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(nameCurrentScene + 1.ToString());

        //SceneManager.LoadScene(currentIndexScen + 1);
    }

    public void CheckTutorial()
    {
        if(Tutorial.IsTiger)
        {
            SceneManager.LoadScene("Level 1");           
        }
        else
        {
            SceneManager.LoadScene("SceneTutorial");
        }
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("SceneMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StopGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
