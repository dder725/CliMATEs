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

    public bool isDone;
    public override void GiveObjectiveRewards()
    {

    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return factoryWorkerScript.ConversationFinished() || isDone;
    }

    public override void RunStartUpLogicForObjective()
    {
        factoryWorkerScript = factoryWorker.GetComponent<WanderingTalkingNPC>();
        factoryWorkerScript.canTalk = true;

        npcScript1 = citizen1.GetComponent<WanderingTalkingNPC>();
        npcScript2 = citizen2.GetComponent<WanderingTalkingNPC>();
        npcScript3 = citizen3.GetComponent<WanderingTalkingNPC>();
        npcScript4 = citizen4.GetComponent<WanderingTalkingNPC>();
        npcScript5 = citizen5.GetComponent<WanderingTalkingNPC>();

        MoveNPC(citizen1, npcScript1, 71, -6, "Some climate change slogan");
        MoveNPC(citizen2, npcScript2, 72, -3, "Some climate change slogan");
        MoveNPC(citizen3, npcScript3, 67, -7, "Some climate change slogan");
        MoveNPC(citizen4, npcScript4, 74, -7, "Some climate change slogan");
        MoveNPC(citizen5, npcScript5, 70, -3, "Some climate change slogan");


    }

    public override void RunTearDownLogicForObjective()
    {
        SetMoving(npcScript1);
        SetMoving(npcScript2);
        SetMoving(npcScript3);
        SetMoving(npcScript4);
        SetMoving(npcScript5);

    }

    private void MoveNPC(Transform npc, WanderingTalkingNPC npcScript, int x, int y, string speech)
    {
        npc.position = new Vector3(x, y, 0);
        npcScript.dialogue.sentences[0] = speech;
        npcScript.dialogue.sentences[1] = speech;
        npcScript.walkTime = 0f;
        npcScript.speed = 0f;
    }

    private void SetMoving(WanderingTalkingNPC script)
    {
        script.speed = 3f;
        script.walkTime = 3f;
        script.waitTime = 1f;
    }

}
