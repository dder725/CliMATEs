using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStats : MonoBehaviour
{
    [Range(1,100)]
    public int attack;
    [Range(1,100)]
    public int defense;
    [Range(0,100)]
    public int health;
    public string combatName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
