using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") & !gameIsPaused)
        {
            Pause();
        } else if(Input.GetKeyDown("escape") & gameIsPaused){
            Resume();
        }
        
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
        SceneManager.LoadScene("TitleScreen");
        // Application.Quit();

    }
}
