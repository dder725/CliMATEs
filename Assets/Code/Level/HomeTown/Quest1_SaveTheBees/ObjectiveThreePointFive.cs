using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveThreePointFive : Objective
{


    public Transform butterflyGirl;
    private WanderingTalkingNPC talkingNPCScript;
    public override void GiveObjectiveRewards()
    {
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return talkingNPCScript.ConversationFinished();
    }

    public override void RunStartUpLogicForObjective()
    {
        SetupButterflyGirl();
    }

    public override void RunTearDownLogicForObjective()
    {
    }

    private void SetupButterflyGirl()
    {
        Instantiate(butterflyGirl, new Vector3(34, -6, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("ButterflyGirlNPC(Clone)");
        talkingNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
        talkingNPCScript.gender = WanderingTalkingNPC.Gender.Female;
    }
}
