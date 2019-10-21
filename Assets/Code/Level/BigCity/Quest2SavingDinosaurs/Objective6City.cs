using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective6City : Objective
{

    public Transform ecoWorker;
    private WanderingTalkingNPC talkingScript;


    public bool isDone;
    public override void GiveObjectiveRewards()
    {

    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return talkingScript.ConversationFinished() || isDone;
    }

    public override void RunStartUpLogicForObjective()
    {
        talkingScript = ecoWorker.GetComponent<WanderingTalkingNPC>();
        talkingScript.canTalk = true;
    }

    public override void RunTearDownLogicForObjective()
    {
    }

}
