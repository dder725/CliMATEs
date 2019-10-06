using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveOneHT : Objective
{
    public Transform player;

    public override void GiveObjectiveRewards()
    {
  
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return player.transform.position.x < 10;
    }

    public override void RunStartUpLogicForObjective()
    {

    }

    public override void RunTearDownLogicForObjective()
    {

    }
}
