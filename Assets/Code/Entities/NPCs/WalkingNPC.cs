using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingNPC : Entity
{
    public bool isWalking = true;
    public float walkTime;

    public int walkDirection;

    private Rigidbody2D rb;
    public Animator animator;


    // Update is called once per frame
    void Update()
    {

        animator.SetBool("isWalking", isWalking);

        if (isWalking == true)
        {
   

            //give the speed to the animator....
            // This doesn't work - says that "speed" is not a property
            // animator.SetFloat("speed", speed);

            walkTime -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0: //up
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                    break;

                case 1: //right
                    transform.Translate(Vector2.right * speed * Time.deltaTime);
                    break;
                case 2: //down
                    transform.Translate(Vector2.down * speed * Time.deltaTime);
                    break;
                case 3: //left
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
