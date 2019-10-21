using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective7City : Objective
{

    public Transform factoryWorker;
    private WanderingTalkingNPC factoryWorkerScript;


    public Transform protester1;
    private WanderingTalkingNPC npcScript1;
   
    public Transform protester2;
    private WanderingTalkingNPC npcScript2;
    
    public Transform protester3;  
    private WanderingTalkingNPC npcScript3;
    
    public Transform protester4;
    private WanderingTalkingNPC npcScript4;
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
        factoryWorkerScript.canTalk = true;

        SpawnNPC(protester1, npcScript1, 25, 30, WanderingTalkingNPC.Gender.Female, "Some climate slogan");

        SpawnNPC(protester2, npcScript2, 26, 27, WanderingTalkingNPC.Gender.Male, "Some climate slogan");

        SpawnNPC(protester3, npcScript3, 22, 25, WanderingTalkingNPC.Gender.Male, "Some climate slogan");

        SpawnNPC(protester4, npcScript4, 24, 33, WanderingTalkingNPC.Gender.Female, "Some climate slogan");


    }

    public override void RunTearDownLogicForObjective()
    {
    }

    private void SpawnNPC(Transform npc, WanderingTalkingNPC npcScript, int x, int y, WanderingTalkingNPC.Gender gender, string speech)
    {
        Instantiate(npc, new Vector3(x, y, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("Protestor");
        npcScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
        npcScript.gender = gender;
        npcScript.dialogue.sentences[0] = speech;
        npcScript.canTalk = true;
    }
}
