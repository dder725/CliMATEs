﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Plant flowers objective
public class ObjectiveThreeHT : Objective
{
    private GameObject player;
    private BlockPlacing blockPlacingScript;


    public Transform butterflyGirl;
    public Transform bee;

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

            //Spawn the bees to show the environment has changed 
            SpawnBees();
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

    private void SpawnBees()
    {

        Instantiate(bee, new Vector3(34, 6, 0), Quaternion.identity);
        GameObject beeClone = GameObject.Find("Bee(Clone)");
        SpriteRenderer beeSprite = (SpriteRenderer)beeClone.GetComponent("SpriteRenderer");
        beeSprite.flipX = false;

        Instantiate(bee, new Vector3(37, 5, 0), Quaternion.identity);
        GameObject beeClone1 = GameObject.Find("Bee(Clone)");
        
        Instantiate(bee, new Vector3(32, 11, 0), Quaternion.identity);
        GameObject beeClone2 = GameObject.Find("Bee(Clone)");

        Instantiate(bee, new Vector3(29, 6, 0), Quaternion.identity);
        GameObject beeClone3 = GameObject.Find("Bee(Clone)");
        SpriteRenderer bee3Sprite = (SpriteRenderer)beeClone3.GetComponent("SpriteRenderer");
        bee3Sprite.flipX = false;




    }



}
