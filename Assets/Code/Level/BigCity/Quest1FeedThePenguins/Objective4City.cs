using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective4City : Objective
{


    public Transform player;
    private Inventory playerInventory;

    public Transform portWorker;
    private WanderingTalkingNPC portWorkerScript;

    public override void GiveObjectiveRewards()
    {

    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return portWorkerScript.ConversationFinished();
    }

    public override void RunStartUpLogicForObjective()
    {
        Instantiate(portWorker, new Vector2(60, -44), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("PortWorker");
        portWorkerScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }

    public override void RunTearDownLogicForObjective()
    {
        playerInventory.hasFish = true;
    }
  
}
