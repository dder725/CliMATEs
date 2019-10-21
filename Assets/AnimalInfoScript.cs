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


    public void ExitButton()
    {
        SceneManager.UnloadSceneAsync("AnimalInfo");
        Time.timeScale = 1;
    }
}
