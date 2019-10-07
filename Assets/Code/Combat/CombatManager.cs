using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Threading;

public class CombatManager : MonoBehaviour
{
    private Camera worldCamera;
    private Camera combatCamera;

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

    public bool ready = false;
	

    // Start is called before the first frame update
    void Start()
    {
        combatCamera = GameObject.Find("Combat Camera").GetComponent<Camera>();
        worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        EventManager.StartListening("combatStart", new UnityAction(startCombat));   
        EventManager.StartListening("combatNextTurn", new UnityAction(nextTurn));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void startCombat()
    {
        Debug.Log("Starting combat with: " + mob.name);

        // Switch cameras
        combatCamera.enabled = true;
        worldCamera.enabled = false;
        GameObject.Find("HUD").SetActive(false);
        GameObject.Find("Minimap Player Icon").SetActive(false);

        // Translate mob and remember original position
        mobOriginalPosition.position = mob.transform.position;
        mob.transform.position = mobSpawn.position;

        // Translate/freeze player and remember original position
        player = GameObject.Find("Player");
        player.GetComponent<Player>().froze = true;
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
            default:
                break;
        }

        // Check for mob death
        if (mobStats.health <= 0)
        {

        }

        // Allow mob to attack
        mobAttack();

        // Check for player death
        if (playerStats.health <= 0)
        {
            
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

    private void exitCombat(){
        //Return player to the original location
        player = GameObject.Find("Player");
        player.transform.position = playerOriginalPosition.position;
    }
}
