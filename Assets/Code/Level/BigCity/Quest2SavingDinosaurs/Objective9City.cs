using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective9City : Objective
{

    public Transform bigBoss;
    private WanderingTalkingNPC bossScript;

    public bool isDone;
    
    public override void GiveObjectiveRewards()
    {
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return bossScript.ConversationFinished() || isDone;
    }

    public override void RunStartUpLogicForObjective()
    {
        Instantiate(bigBoss, new Vector3(71, -16, 0), Quaternion.identity);
        bossScript = bigBoss.GetComponent<WanderingTalkingNPC>();
    }

    public override void RunTearDownLogicForObjective()
    {
    }

}
