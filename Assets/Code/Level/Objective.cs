using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Objective should be complete when logic
 * in ObjectiveGoalIsAchieved returns true
 */
public abstract class Objective : MonoBehaviour
{
    public string objectiveName;
    public string objectiveDescription;
    public int objectiveID;
    public int levelID;

    private bool isActiveObjective;

    public abstract void GiveObjectiveRewards();

    public abstract bool ObjectiveGoalIsAchieved();

    public abstract void RunStartUpLogicForObjective();

    public abstract void RunTearDownLogicForObjective();

    public bool IsActive()
    {
        return isActiveObjective;
    }

    public void SetObjectiveToActive()
    {
        this.isActiveObjective = true;
        Debug.Log("Objective " + objectiveID + " is active");
    }

    public void SetObjectiveToInactive()
    {
        this.isActiveObjective = false;
        Debug.Log("Objective " + objectiveID + " is inactive");
    }

    public string GetObjectiveName()
    {
        return objectiveName;
    }

    public string GetObjectiveDescription()
    {
        return objectiveDescription;
    }
}
