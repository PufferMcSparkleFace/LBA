﻿using System.Collections;
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
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenuUI.SetActive(true);
            GameIsPaused = true;
            Time.timeScale = 1f;
        }
    }
}
