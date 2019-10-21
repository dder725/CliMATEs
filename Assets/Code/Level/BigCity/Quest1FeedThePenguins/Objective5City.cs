using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective5City : Objective
{


    public Transform penguinArea;
    private PenguinCounter penguinCounter;

    public Transform tokens;
    private AnimalTokensScript animalTokensScript;
    private HUDButtons HUDButtons;


    public bool isDone;
    public override void GiveObjectiveRewards()
    {
        Debug.Log("Penguin token gained");
        HUDButtons = FindObjectOfType<HUDButtons>();
        HUDButtons.ShowAnimals();

        //animalTokensScript = FindObjectOfType<AnimalTokensScript>();
        animalTokensScript = tokens.GetComponent<AnimalTokensScript>();
        animalTokensScript.ShowPenguinToken();
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return penguinCounter.CheckNumPenguins() || isDone;
    }

    public override void RunStartUpLogicForObjective()
    {
        penguinCounter = penguinArea.GetComponent<PenguinCounter>();
    }

    public override void RunTearDownLogicForObjective()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
