using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    public Transform cloud;
    public Sprite[] sprites;

    private int spriteIndex;
    private System.Random rnd = new System.Random();
    int speed;
    int yPosition;

    // Start is called before the first frame update
    void Start()
    {
        speed = rnd.Next(1, 13);
        yPosition = rnd.Next(-30, 30);
    }

    // Update is called once per frame
    void Update()
    {
        if (cloud.transform.position.x > -60)
        {
            cloud.transform.position += Vector3.left * speed * Time.deltaTime;

        } else
        {
            speed = rnd.Next(1, 13);
            yPosition = rnd.Next(-30, 30);
            spriteIndex++;
            if (spriteIndex > 2)
            {
                spriteIndex = 0;
            }
            cloud.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];
            cloud.transform.position = new Vector3(100, yPosition, 0);
        }
    }
}
