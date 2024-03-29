﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective4City : Objective
{


    public Transform player;
    private Inventory playerInventory;

    public Transform portWorker;
    private WanderingTalkingNPC portTalkingScript;
    private WalkingNPC portWalkingScript;


    public bool isDone;
    public override void GiveObjectiveRewards()
    {
        playerInventory.hasFish = true;
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        AchievementManager.ach06Trigger = true;
        return portTalkingScript.ConversationFinished() || isDone;
    }

    public override void RunStartUpLogicForObjective()
    {
        portTalkingScript = portWorker.GetComponent<WanderingTalkingNPC>();
        portWalkingScript = portWorker.GetComponent<WalkingNPC>();
        playerInventory = player.GetComponent<Inventory>();

        portWalkingScript.walkDirection = 1;
        portWalkingScript.walkTime = 4;
        portWalkingScript.speed = 3;

        portTalkingScript.canTalk = true;
    }

    public override void RunTearDownLogicForObjective()
    {
    }
  
}
