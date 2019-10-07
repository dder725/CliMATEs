using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSix : Objective
{

    public Transform butterflyGirlNPC;
    private WanderingTalkingNPC butterflyGirlNPCScript;
    public override void GiveObjectiveRewards()
    {
        //TODO - give butterfly token
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return butterflyGirlNPCScript.ConversationFinished();
    }

    public override void RunStartUpLogicForObjective()
    {
        Destroy(GameObject.Find("ButterflyGirlNPC(Clone)"));
        SetupButterflyGirlNPC();
    }

    public override void RunTearDownLogicForObjective()
    {
    }

    private void SetupButterflyGirlNPC()
    {
        Instantiate(butterflyGirlNPC, new Vector3(34, 2, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("ButterflyGirl2NPC(Clone)");
        butterflyGirlNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }
}
