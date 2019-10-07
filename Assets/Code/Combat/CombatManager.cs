﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Threading;

public class CombatManager : MonoBehaviour
{
    private Camera worldCamera;
    private Camera combatCamera;
    private bool ready = false;

    public enum CombatStatus {
        Win,
        Lose
    }
    public static CombatStatus combatStatus;

    public static GameObject player;
    public static CombatStats playerStats;
    public Transform playerSpawn;
    public Transform playerOriginalPosition;

    public static GameObject mob;
    public static CombatStats mobStats;
    public Transform mobSpawn;
    public Transform mobOriginalPosition;


    public enum Move {
        Attack,
        Heal,
        Flee
    }
    public static Move nextMove;
	

    // Start is called before the first frame update
    void Start()
    {
        combatCamera = GameObject.Find("Combat Camera").GetComponent<Camera>();
        worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        EventManager.StartListening("combatStart", new UnityAction(startCombat));   
        EventManager.StartListening("combatNextTurn", new UnityAction(nextTurn));
        EventManager.StartListening("combatExit", new UnityAction(exitCombat));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void startCombat()
    {
        Debug.Log("Starting combat with: " + mob.name);

        GameObject.Find("HUD").SetActive(false);
        GameObject.Find("Minimap Player Icon").SetActive(false);


        // Switch cameras
        combatCamera.enabled = true;
        worldCamera.enabled = false;

        // Translate mob and remember original position
        mobOriginalPosition.position = mob.transform.position;
        mob.transform.position = mobSpawn.position;

        // Translate/freeze player and remember original position
        player = GameObject.Find("Player");
        Player.freezePlayer();
        playerOriginalPosition.position = player.transform.position;
        player.transform.position = playerSpawn.position;

        // Set stat objects
        playerStats = player.GetComponent<CombatStats>();
        mobStats = mob.GetComponent<CombatStats>();

        // Set ready state
        ready = true;
    }

    private void nextTurn() {
        Debug.Log("Executing combat turn logic with move: " + nextMove);

        // Short-circuit if not ready
        if (!ready)
            return;
        ready = false;
        
        // Execute chosen move
        switch (nextMove)
        {
            case Move.Attack:
                playerAttack();
                break;
            case Move.Heal:
                
                break;
            case Move.Flee:
                
                break;
            default:
                break;
        }

        // Check for mob death
        if (mobStats.health <= 0)
        {
            combatStatus = CombatStatus.Win;
            EventManager.TriggerEvent("combatConclusion");
            return;
        }

        // Allow mob to attack
        mobAttack();

        // Check for player death
        if (playerStats.health <= 0)
        {
            combatStatus = CombatStatus.Lose;
            EventManager.TriggerEvent("combatConclusion");
            return;
        }

        ready = true;
    }

    private void playerAttack(){
        double criticalChance = new System.Random().NextDouble();
        int multiplier = 1;
        if(criticalChance > 0.2){
            multiplier = 2;
        }
        int damage = (playerStats.attack / mobStats.defense) * multiplier;

        mobStats.health = Math.Max(0, mobStats.health - damage);
    }

    private void mobAttack(){
        double criticalChance = new System.Random().NextDouble();
        int multiplier = 1;
        if(criticalChance > 0.2){
            multiplier = 2;
        }
        int damage = (mobStats.attack / playerStats.defense) * multiplier;

        playerStats.health = Math.Max(0, playerStats.health - damage);
    }

    private void exitCombat()
    {
        // Return mob to original location if player lost
        if (combatStatus == CombatStatus.Win)
        {
            // Return player to the original location
            player.transform.position = playerOriginalPosition.position;

            // Remove mob
            Destroy(mob);
            mob = null;
        }
        else {
            // Return mob to original location
            mob.transform.position = mobOriginalPosition.position;

            // TODO: Reset player
            player.transform.position = GameObject.Find("PlayerRespawn").transform.position;
            playerStats.health = 100;
        }

        Player.unfreezePlayer();

        // Switch cameras
        GameObject.Find("Combat Camera").GetComponent<Camera>().enabled = false;
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
    }
}