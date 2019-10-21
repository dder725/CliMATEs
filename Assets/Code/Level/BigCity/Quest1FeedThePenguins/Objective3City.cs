using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective3City : Objective
{

    public Transform monster;
    private Monster monsterScript;


    public bool isDone;
    public override void GiveObjectiveRewards()
    {
        
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return monsterScript.defeated || isDone;
    }

    public override void RunStartUpLogicForObjective()
    {
        monsterScript = monster.GetComponent<Monster>();

    }

    public override void RunTearDownLogicForObjective()
    {
        
    }
}
