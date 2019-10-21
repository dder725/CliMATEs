using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class NexLevelScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("BigCity_magnus");
        PrefabUtility.SaveAsPrefabAsset(GameObject.Find("Achievement"), "Assets/Prefabs/AchievementUPD.prefab");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }


}
