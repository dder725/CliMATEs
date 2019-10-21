using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective3City : Objective
{

    public Transform monster;
    private Monster monsterScript;

    public override void GiveObjectiveRewards()
    {
        
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return monsterScript.defeated;
    }

    public override void RunStartUpLogicForObjective()
    {
        monsterScript = monster.GetComponent<Monster>();

    }

    public override void RunTearDownLogicForObjective()
    {
        
    }
}
