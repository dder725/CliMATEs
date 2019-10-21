using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMob : Entity
{
    public Entity following;
    public float distance;

    public Transform player;
    private Inventory playerInventory;

    public bool canFollow = false;
    public bool isFollowing = false;
    public bool atLocation = false;
    public Animator animator;

    private Rigidbody2D rb;

    public Transform mob;
    private WanderingTalkingNPC wanderScript;

    private float walkTime;
    private float waitTime;
    private float wanderSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = following.GetComponent<Rigidbody2D>();
        wanderScript = mob.GetComponent<WanderingTalkingNPC>();
        walkTime = wanderScript.walkTime;
        waitTime = wanderScript.waitTime;
        wanderSpeed = wanderScript.speed;
    

        playerInventory = player.GetComponent<Inventory>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if(isFollowing)
        {
            if (following.GetComponent<Rigidbody2D>().transform.position.y > (GetComponent<Rigidbody2D>().transform.position.y + distance))
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
                animator.SetFloat("Vertical", 1); //y movement


            }
            if (following.GetComponent<Rigidbody2D>().transform.position.y < (GetComponent<Rigidbody2D>().transform.position.y - distance))
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
                animator.SetFloat("Vertical", -1); //y movement

            }
            if (following.GetComponent<Rigidbody2D>().transform.position.x > (GetComponent<Rigidbody2D>().transform.position.x + distance))
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
                animator.SetFloat("Horizontal", 1);
            }
            if (following.GetComponent<Rigidbody2D>().transform.position.x < (GetComponent<Rigidbody2D>().transform.position.x - distance))
            {
                GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
                animator.SetFloat("Horizontal", -1);
            }

       
           
        }

        //setting the animator
        if (animator != null)
        {
            Debug.Log("Animator working in FollowMob");
           // animator.SetFloat("Horizontal", rb.velocity.x); //x movement 
            //animator.SetFloat("Vertical", rb.velocity.y); //y movement
            animator.SetFloat("Speed", 2);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("Player") && playerInventory.hasFish)
        {
            Destroy(wanderScript);
           // wanderScript.speed = 0f;
            //wanderScript.walkTime = 0f;
            //wanderScript.waitTime = 0f;
            isFollowing = true;

        }
    }

    public void SetWalkTime(float walkTime)
    {
        this.walkTime = walkTime;
    }

    public void SetWaitTime(float waitTime)
    {
        this.waitTime = waitTime;
    }
}
