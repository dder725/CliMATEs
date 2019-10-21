using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class nextLevelShortCut : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("COllided with a beehive");
        //PrefabUtility.SaveAsPrefabAsset(GameObject.Find("Achievement"), "Assets/Prefabs/AchievementUPD.prefab");
        SceneManager.LoadScene("NextLevelScreen");
    }
}
