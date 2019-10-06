using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTwoHomeTown : Objective
{
    private bool enteredZone;

    private void Awake()
    {
        objectiveName = "You are dead";
        objectiveDescription = "Blah blah balsh e house named House2";
        objectiveID = 2;
        levelID = 1;
        Debug.Log("Objective awake");
    }

    public override void RunStartUpLogicForObjective()
    {
        Debug.Log("Objective 2 active");
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return enteredZone;
    }

    public override void RunTearDownLogicForObjective()
    {
    }

    private void Update()
    {
        enteredZone = this.transform.parent.position.x > 30;
    }

    public override void GiveObjectiveRewards()
    {
        
    }
}
