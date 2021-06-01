using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    PlayerControls controls;
    public GameObject pauseMenuUI;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Pause.Pause.performed += ctx => Pause();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Pause()
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
