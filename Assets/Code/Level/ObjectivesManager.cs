using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        UpdateQuestLogName();
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
        UpdateQuestLogName();
    }

    private bool CurrentObjectiveWasLastObjective()
    {
        return GetComponents<Objective>().Length == 1;
    }

    private void CompleteLevel()
    {
        levelIsCompleted = true;
        Debug.Log("Level Complete");
    }

    private void AdvanceToNextObjective()
    {
        currentObjectiveIndex++;
        StartNewObjective();
    }

    private void UpdateQuestLogName()
    {
        Text textBox = GameObject.Find("QuestName").GetComponent<Text>();
        if (!levelIsCompleted)
        {
            textBox.text = currentObjective.GetObjectiveName();
        }
        else
        {
            textBox.text = "Level complete!";
        }
    }
}
