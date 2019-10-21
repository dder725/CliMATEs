using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective6City : Objective
{

    public Transform ecoWorker;
    private WanderingTalkingNPC ecoWorkerScript;


    public bool isDone;

    public override void GiveObjectiveRewards()
    {
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return ecoWorkerScript.ConversationFinished() || isDone;
    }

    public override void RunStartUpLogicForObjective()
    {
        ecoWorkerScript = ecoWorker.GetComponent<WanderingTalkingNPC>();
        ecoWorkerScript.canTalk = true;
    }

    public override void RunTearDownLogicForObjective()
    {

    }
}
