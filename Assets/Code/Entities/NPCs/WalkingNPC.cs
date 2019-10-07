using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingNPC : Entity
{
    public bool isWalking = true;
    public float walkTime;

    public int walkDirection;
 

    // Update is called once per frame
    void Update()
    {
        if (isWalking == true)
        {

            walkTime -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                    break;

                case 1:
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    break;
                case 2:
                    transform.Translate(Vector2.down * speed * Time.deltaTime);
                    break;
                case 3:
                    transform.Translate(Vector2.left * speed * Time.deltaTime);
                    break;
            }

            if(walkTime < 0)
            {
                isWalking = false;
            }
        }
        
    }
}
