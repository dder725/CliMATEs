using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective2City : Objective
{

    public Transform sushiOwner;
    private WanderingTalkingNPC sushiOwnerScript;

    public override void GiveObjectiveRewards()
    {
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return sushiOwnerScript.ConversationFinished();
    }

    public override void RunStartUpLogicForObjective()
    {
        sushiOwnerScript = sushiOwner.GetComponent<WanderingTalkingNPC>();
    }

    public override void RunTearDownLogicForObjective()
    {

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
