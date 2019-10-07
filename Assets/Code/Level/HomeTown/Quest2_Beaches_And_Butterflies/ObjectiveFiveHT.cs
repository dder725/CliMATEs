using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveFiveHT : Objective
{

    private GameObject player;
    public MilkBlockPlacing blockPlacingScript;

    public Sprite sprite;

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
        player = GameObject.Find("Player");
        blockPlacingScript = player.GetComponent<MilkBlockPlacing>();
        blockPlacingScript.CanPlaceBlocksNow();

    }

    private void SetUpShopKeeperNPC()
    {
        Instantiate(shopKeeperNPC, new Vector3(30, -4, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("ShopKeeper2NPC(Clone)");
        shopKeeperNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }

}
