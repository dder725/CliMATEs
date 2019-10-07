using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plant flowers objective
public class ObjectiveThreeHT : Objective
{
    private GameObject player;
    private BlockPlacing blockPlacingScript;

    public override void GiveObjectiveRewards()
    {
        
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return blockPlacingScript.numberOfBlocks <= 0;
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
}
