using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimalTokensScript : MonoBehaviour
{

    public Button beeButton;
    public Button butterflyButton;
    public Button turtleButton;
    public Button penguinButton;
    public Button tuataraButton;
    public Button polarBearButton;

    [SerializeField] private Text noAnimalsText;


    // Start is called before the first frame update
    void Start()
    {

        beeButton.gameObject.SetActive(false);
        butterflyButton.gameObject.SetActive(false);
        turtleButton.gameObject.SetActive(false);
        penguinButton.gameObject.SetActive(false);


       // tuataraButton.gameObject.SetActive(false);
       // polarBearButton.gameObject.SetActive(false);

        noAnimalsText.gameObject.SetActive(true);


    }

    public void ShowLevel1Tokens(){
        beeButton.gameObject.SetActive(true);
        butterflyButton.gameObject.SetActive(true);
        turtleButton.gameObject.SetActive(true);
        noAnimalsText.gameObject.SetActive(false);
    }

    public void ShowBeeToken()
    {
        //Disable the 'no animals' text
        noAnimalsText.gameObject.SetActive(false);

        beeButton.gameObject.SetActive(true);
        beeButton.enabled = true;

        // Trigger an achievement
        AchievementManager.ach01Trigger = true;
        Debug.Log("Ach01 Trigger is" + AchievementManager.ach01Trigger);

    }

    public void ShowButterflyToken()
    {
        butterflyButton.gameObject.SetActive(true);
        butterflyButton.enabled = true;
    }

    public void ShowTurtleToken()
    {
        turtleButton.gameObject.SetActive(true);
        turtleButton.enabled = true;
    }

    public void ShowPenguinToken()
    {
        penguinButton.gameObject.SetActive(true);
        penguinButton.enabled = true;
    }



    public void OpenBeeInfo()
    {

        SceneManager.LoadScene("BeeInfo", LoadSceneMode.Additive);
        Time.timeScale = 0;


    }

    public void OpenTurtleInfo()
    {

        SceneManager.LoadScene("TurtleInfo", LoadSceneMode.Additive);
        Time.timeScale = 0;

    }





}
