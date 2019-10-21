﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective8City : Objective
{

    public Transform mob;
    private WalkingNPC mobScript;
    private Monster combatScript;

    public Transform player;
    private Player playerScript;
    public Transform smog;
    private SpriteRenderer smogRenderer;

    public bool isDone;
    public override void GiveObjectiveRewards()
    {

        smogRenderer.enabled = false;
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        if(playerScript.combatVictory || isDone)
        {
            playerScript.combatVictory = false;
            return true;
        } else
        {
            return false;
        }
    }

    public override void RunStartUpLogicForObjective()
    {
        Instantiate(mob, new Vector3(71, 16, 0), Quaternion.identity);

        mobScript = mob.GetComponent<WalkingNPC>();
        combatScript = mob.GetComponent<Monster>();

        smogRenderer = smog.GetComponent<SpriteRenderer>();

        playerScript = player.GetComponent<Player>();

    }

    public override void RunTearDownLogicForObjective()
    {
    }
}
