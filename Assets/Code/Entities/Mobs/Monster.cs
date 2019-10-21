﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public bool enter = true;

    public bool defeated = false;
	
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        UnityEngine.Debug.Log("Detected collision!");
        CombatManager.mob = this.gameObject;
        CombatManager.collision = other;
        EventManager.TriggerEvent("combatStart");
    }
}
