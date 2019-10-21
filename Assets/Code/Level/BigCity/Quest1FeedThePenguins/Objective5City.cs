using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective5City : Objective
{


    public Transform penguinArea;
    private PenguinCounter penguinCounter;

    private AnimalTokensScript animalTokensScript;
    public override void GiveObjectiveRewards()
    {

        animalTokensScript = FindObjectOfType<AnimalTokensScript>();
        animalTokensScript.ShowPenguinToken();
    }

    public override bool ObjectiveGoalIsAchieved()
    {

        return penguinCounter.CheckNumPenguins();
    }

    public override void RunStartUpLogicForObjective()
    {

        penguinCounter = penguinArea.GetComponent<PenguinCounter>();
    }

    public override void RunTearDownLogicForObjective()
    {
        throw new System.NotImplementedException();
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
