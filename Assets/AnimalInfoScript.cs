using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalInfoScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ExitBeeButton()
    {
        SceneManager.UnloadSceneAsync("BeeInfo");
        Time.timeScale = 1;
    }

    public void ExitTurtleButton()
    {
        SceneManager.UnloadSceneAsync("TurtleInfo");
        Time.timeScale = 1;

    }

    public void ExitButterflyButton()
    {
        SceneManager.UnloadSceneAsync("ButterflyInfo");
        Time.timeScale = 1;

    }

    public void ExitPenguinButton()
    {
        SceneManager.UnloadSceneAsync("PenguinInfo");
        Time.timeScale = 1;

    }

    public void ExitTuataraButton()
    {
        SceneManager.UnloadSceneAsync("TuataraInfo");
        Time.timeScale = 1;

    }


}
