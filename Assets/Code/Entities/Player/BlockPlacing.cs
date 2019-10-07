using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlacing : MonoBehaviour
{
    public Transform block;
    public int numberOfBlocks;
    public Sprite[] sprites;
    private bool canPlaceBlocks = false;

    public Entity player;

    private System.Random random = new System.Random();

    public void CanPlaceBlocksNow()
    {
        canPlaceBlocks = true;
    }

    public void CanNotPlaceBlocksNow()
    {
        canPlaceBlocks = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && numberOfBlocks > 0 && canPlaceBlocks)
        {
            block.GetComponent<SpriteRenderer>().sprite = sprites[random.Next(0, sprites.Length)];
            Instantiate(block, new Vector3(player.transform.position.x, player.transform.position.y), Quaternion.identity);
            numberOfBlocks--;
        }
    }
}
