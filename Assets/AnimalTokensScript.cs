using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalTokensScript : MonoBehaviour
{

    public Button beeButton;
    public Button butterflyButton;
    public Button turtleButton;
    public Button polarBearButton;
    [SerializeField] private Text noAnimalsText;


    // Start is called before the first frame update
    void Start()
    {

        beeButton.gameObject.SetActive(false);
        butterflyButton.gameObject.SetActive(false);
        turtleButton.gameObject.SetActive(false);
        polarBearButton.gameObject.SetActive(false);
        noAnimalsText.gameObject.SetActive(true);

        beeButton.enabled = false;
        butterflyButton.enabled = false;
        turtleButton.enabled = false;
        polarBearButton.enabled = false;
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

    public void ShowPolarBearToken()
    {
        polarBearButton.gameObject.SetActive(true);
        polarBearButton.enabled = true;
    }

    public List<CombatManager.AnimalMove> GetAnimalMoves() {
        var moves = new List<CombatManager.AnimalMove>();

        if (beeButton.enabled)
            moves.Add(CombatManager.AnimalMove.BeeMove);

        if (butterflyButton.enabled)
            moves.Add(CombatManager.AnimalMove.ButterflyMove);

        if (turtleButton.enabled)
            moves.Add(CombatManager.AnimalMove.TurtleMove);

        if (polarBearButton.enabled)
            moves.Add(CombatManager.AnimalMove.PolarBearMove);

        return moves;
    }

}
