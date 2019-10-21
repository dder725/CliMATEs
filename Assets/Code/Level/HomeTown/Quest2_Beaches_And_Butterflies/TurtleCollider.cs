using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleCollider : MonoBehaviour
{

    public bool inRange;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player"))
        {
            inRange = true;
        }
    }

    public bool IsInRange()
    {
        return inRange;
    }
}
