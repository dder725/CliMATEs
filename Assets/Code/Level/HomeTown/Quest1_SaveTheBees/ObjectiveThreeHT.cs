using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plant flowers objective
public class ObjectiveThreeHT : Objective
{
    private GameObject player;
    private BlockPlacing blockPlacingScript;


    public Transform butterflyGirl;
    private WanderingTalkingNPC talkingNPCScript;

    private bool completed = false;

    public override void GiveObjectiveRewards()
    {
        
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return completed;
        //return blockPlacingScript.numberOfBlocks <= 0;
    }

    public override void RunStartUpLogicForObjective()
    {
        player = GameObject.Find("Player");
        blockPlacingScript = player.GetComponent<BlockPlacing>();
        blockPlacingScript.CanPlaceBlocksNow();
    }

    public override void RunTearDownLogicForObjective()
    {
        blockPlacingScript.CanNotPlaceBlocksNow();
    }

    private void Update()
    {
        if(blockPlacingScript.numberOfBlocks <= 0)
        {
            SetupButterflyGirl();
            completed = true;
        }
    }

    private void SetupButterflyGirl()
    {
        Instantiate(butterflyGirl, new Vector3(34, -6, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("ButterflyGirlNPC(Clone)");
        talkingNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }



}
