using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective7City : Objective
{

    public Transform factoryWorker;
    private WanderingTalkingNPC factoryWorkerScript;

    public Transform citizen1;
    private WanderingTalkingNPC npcScript1;

    public Transform citizen2;
    private WanderingTalkingNPC npcScript2;

    public Transform citizen3;
    private WanderingTalkingNPC npcScript3;

    public Transform citizen4;
    private WanderingTalkingNPC npcScript4;

    public Transform citizen5;
    private WanderingTalkingNPC npcScript5;
    public override void GiveObjectiveRewards()
    {

    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return factoryWorkerScript.ConversationFinished();
    }

    public override void RunStartUpLogicForObjective()
    {
        factoryWorkerScript = factoryWorker.GetComponent<WanderingTalkingNPC>();

        npcScript1 = citizen1.GetComponent<WanderingTalkingNPC>();

        npcScript2 = citizen2.GetComponent<WanderingTalkingNPC>();

        npcScript3 = citizen3.GetComponent<WanderingTalkingNPC>();

        npcScript4 = citizen4.GetComponent<WanderingTalkingNPC>();

        npcScript5 = citizen5.GetComponent<WanderingTalkingNPC>();
    }

    public override void RunTearDownLogicForObjective()
    {

    }

}
