using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class HUDButtons : MonoBehaviour
{

    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject animalTokenWindow;
    public GameObject animalsButton;
  

     void Start()
    {
        animalTokenWindow.SetActive(false);    
    }


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


    public void ShowInventory()
    {


    }

    public void ShowAnimals()
    {
        bool animalTabIsActive = animalTokenWindow.activeSelf;

        if (animalTabIsActive)
        {
            animalTokenWindow.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);

        }
        else
        {
            animalTokenWindow.SetActive(true);
        }


        //if (EventSystem.current.currentSelectedGameObject == animalsButton)
        //{
        //    Debug.Log("Yes");
        //    animalTokenWindow.SetActive(true);
        //}

        

    }

    public void LoadMenu()
    {

    }

    public void QuitGame()
    {

        Application.Quit();

    }
}
