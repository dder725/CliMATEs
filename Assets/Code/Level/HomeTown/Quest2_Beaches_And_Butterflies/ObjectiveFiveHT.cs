using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveFiveHT : Objective
{

    public Transform shopKeeperNPC;
    private WanderingTalkingNPC shopKeeperNPCScript;
    public override void GiveObjectiveRewards()
    {

    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return shopKeeperNPCScript.ConversationFinished();
    }

    public override void RunStartUpLogicForObjective()
    {
        SetUpShopKeeperNPC();
    }

    public override void RunTearDownLogicForObjective()
    {
        
    }

    private void SetUpShopKeeperNPC()
    {
        Instantiate(shopKeeperNPC, new Vector3(30, -4, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("ShopKeeper2NPC(Clone)");
        shopKeeperNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }

}
