using System.Collections;
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
    
    public void ShowCombatView() {
        UnityEngine.Debug.Log("Entering combat view!");
        CombatManager.mob = this.gameObject;
        EventManager.TriggerEvent("combatStart");
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Equals("Player"))
        {
            UnityEngine.Debug.Log("Detected collision!");
            ShowCombatView();
        }
    }
}
