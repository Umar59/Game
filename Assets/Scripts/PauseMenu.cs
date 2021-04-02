using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject Paused;
    public GameObject PauseButton;

    void Update(){
        
        if (GameIsPaused)
        { 
            Pause();
        }
        else {
            Resume();
        } 
    }

    public void Resume()
    {
        PauseButton.SetActive(true);
        Paused.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PauseButton.SetActive(false);
        Paused.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Resume();
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("EBLAN");
    }
}
