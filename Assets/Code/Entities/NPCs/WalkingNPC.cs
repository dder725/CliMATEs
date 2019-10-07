using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingNPC : Entity
{

    private Rigidbody2D myRigidbody2D;
    public bool isWalking;
    public float walkTime;
    //0 = up, 1 = right, 2 = down, 3 = left
    public int direction;

    // Update is called once per frame
    void Update()
    {

        if (isWalking)
        {
            walkTime -= Time.deltaTime;
            switch (direction)
            {
                case 0:
                    myRigidbody2D.velocity = new Vector2(0, speed);
                    break;

                case 1:
                    myRigidbody2D.velocity = new Vector2(0, speed);
                    break;

                case 2:
                    myRigidbody2D.velocity = new Vector2(0, speed);
                    break;

                case 3:
                    myRigidbody2D.velocity = new Vector2(0, speed);
                    break;
            }

            if(walkTime < 0)
            {
                isWalking = false;
            }
        }

    }
}
