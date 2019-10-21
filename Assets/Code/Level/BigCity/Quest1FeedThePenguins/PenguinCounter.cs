using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinCounter : MonoBehaviour
{

    public int penguinCount;
    public bool enoughPenguins;

    private FollowMob penguinScript;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.StartsWith("Penguin"))
        {
            penguinCount++;
            penguinScript = collision.GetComponent<FollowMob>();

            penguinScript.atLocation = true;
            penguinScript.canFollow = false;
            penguinScript.isFollowing = false;
            penguinScript.SetWaitTime(0f);
            penguinScript.SetWalkTime(0f);
            penguinScript.speed = 0;

            if(penguinCount == 3)
            {
                enoughPenguins = true;
            }
        }
    }

    public bool CheckNumPenguins()
    {
        return enoughPenguins;
    }
}
