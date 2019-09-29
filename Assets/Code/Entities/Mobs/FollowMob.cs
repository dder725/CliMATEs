using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMob : Entity
{
    public Entity following;
    public float distance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (following.GetComponent<Rigidbody2D>().transform.position.y > (GetComponent<Rigidbody2D>().transform.position.y + distance)) {
            GetComponent<Rigidbody2D>().transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.y < (GetComponent<Rigidbody2D>().transform.position.y - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.x > (GetComponent<Rigidbody2D>().transform.position.x + distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (following.GetComponent<Rigidbody2D>().transform.position.x < (GetComponent<Rigidbody2D>().transform.position.x - distance))
        {
            GetComponent<Rigidbody2D>().transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
