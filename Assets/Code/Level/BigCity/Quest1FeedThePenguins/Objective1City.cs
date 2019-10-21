using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective1City : Objective
{

    public Transform sushiDaughter;
    private WanderingTalkingNPC sushiDaughterScript;

    public bool isDone;
    public override void GiveObjectiveRewards()
    {
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return sushiDaughterScript.ConversationFinished() || isDone;
    }

    public override void RunStartUpLogicForObjective()
    {
        sushiDaughterScript = sushiDaughter.GetComponent<WanderingTalkingNPC>();
    }

    public override void RunTearDownLogicForObjective()
    {
        sushiDaughterScript.waitTime = 2;
        sushiDaughterScript.walkTime = 3;
        sushiDaughterScript.speed = 2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
