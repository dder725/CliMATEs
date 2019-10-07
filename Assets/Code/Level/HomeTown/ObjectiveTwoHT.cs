using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTwoHT : Objective
{
    public Transform shopKeeperNPC;
    public Transform mumNPC;
    private WanderingTalkingNPC shopKeeperNPCScript;
    private WanderingTalkingNPC mumNPCScript;

    private bool mumNPCInitialized = false;

    private bool talkedToShopKeeper = false;
    private bool talkedToMum = false;

    public override void GiveObjectiveRewards()
    {
  
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        talkedToShopKeeper |= shopKeeperNPCScript.InConversation();
        if (mumNPCInitialized)
        {
            talkedToMum |= mumNPCScript.InConversation();
        }
        return talkedToShopKeeper && talkedToMum;
    }

    public override void RunStartUpLogicForObjective()
    {
        SetUpShopKeeperNPC();
    }

    private void SetUpShopKeeperNPC()
    {
        Instantiate(shopKeeperNPC, new Vector3(30, -4, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("ShopKeeperNPC(Clone)");
        shopKeeperNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }

    private void Update()
    {
        if (talkedToShopKeeper && !mumNPCInitialized)
        {
            SetUpMumNPC();
            mumNPCInitialized = true;
        }
    }

    private void SetUpMumNPC()
    {
        DestroyOldMum();
        SetUpNewMumNPC();
    }

    private void DestroyOldMum()
    {
        Destroy(GameObject.Find("MumNPC"));
    }

    private void SetUpNewMumNPC()
    {
        Instantiate(mumNPC, new Vector3(-7, 10, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("MumNPC(Clone)");
        mumNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }

    public override void RunTearDownLogicForObjective()
    {
        DestroyShopKeeper();
    }

    private void DestroyShopKeeper()
    {
        Destroy(GameObject.Find("ShopKeeperNPC(Clone)"));
    }
}
