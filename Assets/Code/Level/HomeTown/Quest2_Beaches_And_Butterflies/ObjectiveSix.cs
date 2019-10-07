using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSix : Objective
{

    private GameObject player;
    public MilkBlockPlacing blockPlacingScript;

    public Transform butterflyGirlNPC;
    private WanderingTalkingNPC butterflyGirlNPCScript;
    private bool notCreated = true;

    private AnimalTokensScript animalTokensScript;

    private void Update()
    {
        if(blockPlacingScript.numberOfBlocks <= 0 && notCreated)
        {
            Destroy(GameObject.Find("ButterflyGirlNPC(Clone)"));
            SetupButterflyGirlNPC();
            notCreated = false;
        }
    }
    public override void GiveObjectiveRewards()
    {
        //TODO - give butterfly token
        animalTokensScript = FindObjectOfType<AnimalTokensScript>();
        animalTokensScript.ShowButterflyToken();
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return blockPlacingScript.numberOfBlocks <= 0 && butterflyGirlNPCScript.ConversationFinished();
    }

    public override void RunStartUpLogicForObjective()
    {
        player = GameObject.Find("Player");
        blockPlacingScript = player.GetComponent<MilkBlockPlacing>();
        blockPlacingScript.CanPlaceBlocksNow();

    }

    public override void RunTearDownLogicForObjective()
    {
    }

    private void SetupButterflyGirlNPC()
    {
        Instantiate(butterflyGirlNPC, new Vector3(34, 2, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("ButterflyGirl2NPC(Clone)");
        butterflyGirlNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }
}
