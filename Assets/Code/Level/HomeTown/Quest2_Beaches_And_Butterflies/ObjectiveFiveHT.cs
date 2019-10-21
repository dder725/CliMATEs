using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveFiveHT : Objective
{

    public Transform shopKeeperNPC;
    private WanderingTalkingNPC shopKeeperNPCScript;
    public Transform butterflyGirlNPC;
    private WanderingTalkingNPC butterflyGirlNPCScript;

    public override void GiveObjectiveRewards()
    {
            Destroy(GameObject.Find("ButterflyGirlNPC(Clone)"));
            SetupButterflyGirlNPC();
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

        private void SetupButterflyGirlNPC()
    {
        Instantiate(butterflyGirlNPC, new Vector3(34, 2, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("ButterflyGirl2NPC(Clone)");
        butterflyGirlNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }

}
