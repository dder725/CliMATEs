using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private SpriteRenderer rend;
    private Sprite boySprite, girlSprite;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        boySprite = (Sprite) Resources.Load("Sprites/Player/Boy/BoySprite");
        girlSprite = (Sprite)Resources.Load("Sprites/Player/Girl/GirlSprite");

        rend.sprite = boySprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
