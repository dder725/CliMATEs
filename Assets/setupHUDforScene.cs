using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class setupHUDforScene : MonoBehaviour
{
    private AnimalTokensScript animalTokensScript;
    private bool set = false;
    void Start()
    {
        animalTokensScript = FindObjectOfType<AnimalTokensScript>();
        animalTokensScript.ShowLevel1Tokens(); 
        // Show all successful achievements
       // GameObject prefab = (GameObject) AssetDatabase.LoadMainAssetAtPath("Assets/Prefabs/AchievementUPD.prefab");
        
        //GameObject achievements = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        //achievements.transform.parent = gameObject.transform;
        //achievements.transform.localPosition = new Vector3(-50, 200, -299);  

             

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Setup(){
        
    }
}
