using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectivesManager : MonoBehaviour
{
    public int levelID;

    private Objective[] objectives;
    private int currentObjectiveIndex;
    private Objective currentObjective;

    private bool levelIsCompleted;

    public void Awake()
    {
        levelIsCompleted = false;
        currentObjectiveIndex = 1;
        StartNewObjective();
    }

    private void StartNewObjective()
    {
        objectives = GetComponents<Objective>();
        currentObjective = GetCurrentObjective();
        currentObjective.RunStartUpLogicForObjective();
        currentObjective.SetObjectiveToActive();
    }

    private Objective GetCurrentObjective()
    {
        foreach (var objective in objectives)
        {
            if (ObjectiveIsCurrentAndCorrectLevel(objective))
            {
                return objective;
            }
        }
        Debug.LogError("Current objective not found");
        return null;
    }

    private bool ObjectiveIsCurrentAndCorrectLevel(Objective objective)
    {
        return objective.objectiveID == currentObjectiveIndex && objective.levelID == levelID;
    }

    // Runs every frame of the game
    public void Update()
    {
        if (!levelIsCompleted && currentObjective != null)
        {
            AdvanceToNextObjectiveIfCompleted();
        }
    }

    private void AdvanceToNextObjectiveIfCompleted()
    {
        if (currentObjective.ObjectiveGoalIsAchieved())
        {
            CompleteAndDestroyCurrentObjective();
            AdvanceToNextObjectiveOrCompleteLevel();
        }
    }

    private void CompleteAndDestroyCurrentObjective()
    {
        currentObjective.GiveObjectiveRewards();
        currentObjective.SetObjectiveToInactive();
        currentObjective.RunTearDownLogicForObjective();
        Destroy(currentObjective);
        //Debug.Log("CurrentObjective: " + currentObjective);
    }

    private void AdvanceToNextObjectiveOrCompleteLevel()
    {
        if (CurrentObjectiveWasLastObjective())
        {
            CompleteLevel();
        }
        else
        {
            AdvanceToNextObjective();
        }
    }

    private bool CurrentObjectiveWasLastObjective()
    {
        return GetComponents<Objective>().Length == 1;
    }

    private void CompleteLevel()
    {
        levelIsCompleted = true;
        // TODO Make GameManager kill this ObjectiveManager when level is completed
        Debug.Log("Level Complete");
    }

    private void AdvanceToNextObjective()
    {
        currentObjectiveIndex++;
        StartNewObjective();
    }
}
