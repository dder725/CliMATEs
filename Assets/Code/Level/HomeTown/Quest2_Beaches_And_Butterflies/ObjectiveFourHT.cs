using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveFourHT : Objective
{

    public Transform surferDudeNPC;
    private WanderingTalkingNPC surferNPCScript;


    public override void GiveObjectiveRewards()
    {
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
        DestroySurfer();
    }

    private void SetupSurfer()
    {
        Instantiate(surferDudeNPC, new Vector3(20, -22, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("SurferDudeNPC(Clone)");
        surferNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }

    private void DestroySurfer()
    {

        Destroy(GameObject.Find("SurferDudeNPC(Clone)"));
    }


    
}
