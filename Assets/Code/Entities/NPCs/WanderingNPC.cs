using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingNPC : Entity
{

    private Rigidbody2D myRigidbody2D;

    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int walkDirection;
    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {

        if (isWalking == true)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    myRigidbody2D.velocity = new Vector2(0, speed);
                    break;
                case 1:
                    myRigidbody2D.velocity = new Vector2(speed, 0);
                    break;

                case 2:
                    myRigidbody2D.velocity = new Vector2(0, -speed);

                    break;

                case 3:
                    myRigidbody2D.velocity = new Vector2(-speed, 0);
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {

            waitCounter -= Time.deltaTime;
            myRigidbody2D.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.LogError("COllided with a forestman");
        AchievementManager.ach02Trigger = true;
    }
}
