using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveOneHomeTown : Objective
{
    private bool enteredZone;
    public Transform player;

    private void Awake()
    {
        objectiveName = "Go to bread";
        objectiveDescription = "Go to the door of the house named House2";
        objectiveID = 1;
        levelID = 1;
        Debug.Log("Objective awake");
    }

    public override void RunStartUpLogicForObjective()
    {
        Debug.Log("Objective 1 active");
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return enteredZone;
    }

    public override void RunTearDownLogicForObjective()
    {
        return;
    }

    public override void GiveObjectiveRewards()
    {
        Debug.Log("Objective 1 complete");
    }

    private void Update()
    {
        enteredZone = this.transform.parent.position.x < 10;
    }
}