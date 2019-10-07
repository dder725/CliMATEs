﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveOneHT : Objective
{
    public Transform mumNPC;
    private WanderingTalkingNPC mumNPCScript;

    private void Awake()
    {
        mumNPCScript = mumNPC.GetComponent<WanderingTalkingNPC>();
    }

    public override void GiveObjectiveRewards()
    {
  
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return mumNPCScript.InConversation();
    }

    public override void RunStartUpLogicForObjective()
    {

    }

    public override void RunTearDownLogicForObjective()
    {

    }
}
