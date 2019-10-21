using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective3City : Objective
{

    public Transform monster;
    private Monster monsterScript;

    public Transform player;
    private Player playerScript;


    public bool isDone;
    public override void GiveObjectiveRewards()
    {
        
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        if (playerScript.combatVictory || isDone){
            playerScript.combatVictory = false;
            return true;
        } else
        {
            return false;
        }
    }

    public override void RunStartUpLogicForObjective()
    {
        monsterScript = monster.GetComponent<Monster>();
        playerScript = player.GetComponent<Player>();

    }

    public override void RunTearDownLogicForObjective()
    {
        
    }
}
