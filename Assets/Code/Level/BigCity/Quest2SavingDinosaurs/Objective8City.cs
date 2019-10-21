using System.Collections;
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
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        Debug.Log(playerScript.combatVictory);
        return playerScript.combatVictory || isDone ;
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
        smogRenderer.enabled = false;
    }
}
