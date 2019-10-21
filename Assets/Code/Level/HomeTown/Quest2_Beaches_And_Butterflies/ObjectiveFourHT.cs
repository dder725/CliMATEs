using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveFourHT : Objective
{

    public Transform surferDudeNPC;
    private WanderingTalkingNPC surferNPCScript;

    public Transform mob;
    private Monster mobScript;

    public override void GiveObjectiveRewards()
    {
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        Debug.Log(mobScript.defeated);
        return mobScript.defeated;
    }

    public override void RunStartUpLogicForObjective()
    {
        SetupSurfer();

        mobScript = mob.GetComponent<Monster>();
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
