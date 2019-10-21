using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective1City : Objective
{

    private AnimalTokensScript animalTokensScript;

    public Transform sushiDaughter;
    private WanderingTalkingNPC sushiDaughterScript;

    public bool isDone;
    public override void GiveObjectiveRewards()
    {
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        AchievementManager.ach05Trigger = true;
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
        animalTokensScript = FindObjectOfType<AnimalTokensScript>();
        animalTokensScript.ShowLevel1Tokens(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
