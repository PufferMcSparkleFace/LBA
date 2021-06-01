using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartMenu : MonoBehaviour
{
    public CinemachineVirtualCamera lokicam, baldrcam, clonecam, titlescreencam;
    public GameObject titlescreen;
    public GameObject controlsscreen;
    public LokiControls lokicontrols;
    // Start is called before the first frame update
    void Start()
    {
        lokicam.Priority = 0;
        baldrcam.Priority = 0;
        clonecam.Priority = 0;
        titlescreencam.Priority = 1;
        lokicontrols.OnDisable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        titlescreen.SetActive(false);
        lokicontrols.OnEnable();
        titlescreencam.Priority = 0;
        lokicam.Priority = 1;
    }
    public void Controls()
    {
        titlescreen.SetActive(false);
        controlsscreen.SetActive(true);

    }

    public void Back()
    {
        controlsscreen.SetActive(false);
        titlescreen.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
