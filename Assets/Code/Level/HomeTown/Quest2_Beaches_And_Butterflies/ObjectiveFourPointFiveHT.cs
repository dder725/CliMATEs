using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveFourPointFiveHT : Objective
{


    public Transform surferDudeNPC;
    private WanderingTalkingNPC surferNPCScript;
    

    private AnimalTokensScript animalTokensScript;

    public override void GiveObjectiveRewards()
    {
        //TODO - give turtle token
        animalTokensScript = FindObjectOfType<AnimalTokensScript>();
        animalTokensScript.ShowTurtleToken();
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return surferNPCScript.ConversationFinished();
    }

    public override void RunStartUpLogicForObjective()
    {
        SetupSurfer();
    }

    public override void RunTearDownLogicForObjective()
    {

    }

    private void SetupSurfer()
    {
        Instantiate(surferDudeNPC, new Vector3(20, -22, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("SurferDude2NPC(Clone)");
        surferNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }
}
