﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        
    }


    public void Resume()
    {
        //Unfreeze game, get rid of pause menu and unpause
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    public void Pause()
    {
        //Freeze game, bring up pause menu and pause game
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

    }

    public void LoadMenu()
    {

    }

    public void QuitGame()
    {

        Application.Quit();

    }
}