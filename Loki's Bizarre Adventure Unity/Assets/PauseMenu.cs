using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public void Pause()
    {
        if(GameIsPaused == true)
        {
            pauseMenuUI.SetActive(false);
            GameIsPaused = false;
            Time.timeScale = 1f;
        }
        else
        {
            pauseMenuUI.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 0f;
        }
    }

    public void LoadControls()
    {
        Debug.Log("Controls");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
