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

    [SerializeField] private Text noAnimalsText;

    public HUDButtons HUDButtons;


    // Start is called before the first frame update
    void Start()
    {
        beeButton.gameObject.SetActive(false);
        butterflyButton.gameObject.SetActive(false);
        turtleButton.gameObject.SetActive(false);
        penguinButton.gameObject.SetActive(false);
        tuataraButton.gameObject.SetActive(false);

        noAnimalsText.gameObject.SetActive(true);

        beeButton.enabled = false;
        butterflyButton.enabled = false;
        turtleButton.enabled = false;
        penguinButton.enabled = false;
        tuataraButton.enabled = false;
    }

    public void ShowLevel1Tokens(){
        ShowBeeToken();
        ShowButterflyToken();
        ShowTurtleToken();
    }

    public void ShowBeeToken()
    {
        //Disable the 'no animals' text
        noAnimalsText.gameObject.SetActive(false);

        //DisplayAnimalsWindow();

        HUDButtons.animalTokenWindow.SetActive(true);

        beeButton.gameObject.SetActive(true);
        beeButton.enabled = true;

        // Trigger an achievement
        AchievementManager.ach01Trigger = true;
        Debug.Log("Ach01 Trigger is" + AchievementManager.ach01Trigger);

    }

    public void ShowButterflyToken()
    {
        DisplayAnimalsWindow();


        butterflyButton.gameObject.SetActive(true);
        butterflyButton.enabled = true;
    }

    public void ShowTurtleToken()
    {
        DisplayAnimalsWindow();

        turtleButton.gameObject.SetActive(true);
        turtleButton.enabled = true;
    }

    public void ShowPenguinToken()
    {
        DisplayAnimalsWindow();

        penguinButton.gameObject.SetActive(true);
        penguinButton.enabled = true;
    }

    public void ShowTuataraToken()
    {
        DisplayAnimalsWindow();

        tuataraButton.gameObject.SetActive(true);
        tuataraButton.enabled = true;
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

    public void OpenButterflyInfo()
    {
        SceneManager.LoadScene("ButterflyInfo", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

    public void OpenPenguinInfo()
    {
        SceneManager.LoadScene("PenguinInfo", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }


    public void OpenTuataraInfo()
    {
        SceneManager.LoadScene("TuataraInfo", LoadSceneMode.Additive);
        Time.timeScale = 0;
    }

    private void DisplayAnimalsWindow()
    {

        HUDButtons.animalTokenWindow.SetActive(true);

    }

    public List<CombatManager.AnimalMove> GetAnimalMoves() {
        var moves = new List<CombatManager.AnimalMove>();

        if (beeButton != null && beeButton.enabled)
            moves.Add(CombatManager.AnimalMove.BeeMove);

        if (butterflyButton != null && butterflyButton.enabled)
            moves.Add(CombatManager.AnimalMove.ButterflyMove);

        if (turtleButton != null && turtleButton.enabled)
            moves.Add(CombatManager.AnimalMove.TurtleMove);

        if (tuataraButton != null && tuataraButton.enabled)
            moves.Add(CombatManager.AnimalMove.TuataraMove);

        if (penguinButton != null && penguinButton.enabled)
            moves.Add(CombatManager.AnimalMove.PenguinMove);

        return moves;
    }

}
