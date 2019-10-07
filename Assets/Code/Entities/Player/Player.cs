using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement; //stores horizontal and vertical movement
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        //Input

  
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);




        //if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //{
        //    GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //{
        //    GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
        //}
        //if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
        //}

    }

    //Called 50 times a second 
    private void FixedUpdate()
    {
        //Use movement variable to move player

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        
    }
}
