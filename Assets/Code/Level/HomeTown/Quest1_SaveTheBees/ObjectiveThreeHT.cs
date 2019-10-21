using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plant flowers objective
public class ObjectiveThreeHT : Objective
{
    private GameObject player;
    private BlockPlacing blockPlacingScript;


    public Transform butterflyGirl;
    private WanderingTalkingNPC talkingNPCScript;

    private AnimalTokensScript animalTokensScript;
    private HUDButtons HUDButtons;

    private bool completed = false;
    private bool isCreated = false;

    public override void GiveObjectiveRewards()
    {
        Debug.Log("Bee token gained");
        HUDButtons = FindObjectOfType<HUDButtons>();
        HUDButtons.ShowAnimals();

        animalTokensScript = FindObjectOfType<AnimalTokensScript>();
        animalTokensScript.ShowBeeToken();
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        if (blockPlacingScript.numberOfBlocks <= 0 && !isCreated)
        {
            SetupButterflyGirl();
            completed = true;
            isCreated = true;
        }
        return completed;
        //return blockPlacingScript.numberOfBlocks <= 0;
    }

    public override void RunStartUpLogicForObjective()
    {
        player = GameObject.Find("Player");
        blockPlacingScript = player.GetComponent<BlockPlacing>();
        blockPlacingScript.CanPlaceBlocksNow();
        FindObjectOfType<TriggerOnBeeObjective>().TriggerTutorial();
    }

    public override void RunTearDownLogicForObjective()
    {
        blockPlacingScript.CanNotPlaceBlocksNow();
    }

    private void SetupButterflyGirl()
    {
        Instantiate(butterflyGirl, new Vector3(34, -6, 0), Quaternion.identity);
        GameObject NPCInstance = GameObject.Find("ButterflyGirlNPC(Clone)");
        talkingNPCScript = NPCInstance.GetComponent<WanderingTalkingNPC>();
    }



}
