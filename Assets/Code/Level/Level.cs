using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int levelWidth;
    private int levelHeigth;

    public Transform grassTile;
    public Transform stoneBrickTile;

    private Color[] tileColors;

    public Color grassColor;
    public Color stoneBrickColor;
    public Color spawnPointColor;

    public Texture2D levelTexture;

    public Entity player;
    public Entity[] friendlyEntities;

    // Start is called before the first frame update
    void Start()
    {
        levelWidth = levelTexture.width;
        levelHeigth = levelTexture.height;
        loadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadLevel()
    {
        tileColors = new Color[levelHeigth * levelWidth];
        tileColors = levelTexture.GetPixels();


        for(int y = 0; y < levelHeigth; y++)
        {
            for (int x = 0; x < levelHeigth; x++)
            {
                if(tileColors[x + y * levelWidth] == grassColor)
                {
                    Instantiate(grassTile, new Vector3(x, y), Quaternion.identity);
                } else if(tileColors[x + y * levelWidth] == stoneBrickColor)
                {
                    Instantiate(stoneBrickTile, new Vector3(x, y), Quaternion.identity);
                } else if (tileColors[x + y * levelWidth] == spawnPointColor)
                {
                    player.transform.position = new Vector2(x, y);
                    Instantiate(grassTile, new Vector3(x, y), Quaternion.identity);

                    for (int i = 0; i < friendlyEntities.Length; i++)
                    {
                        friendlyEntities[i].transform.position = new Vector3(x + i + 1, y);
                    }
                }
            }
        }
    }
}
