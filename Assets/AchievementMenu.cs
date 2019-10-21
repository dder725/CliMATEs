using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementMenu : MonoBehaviour
{
    private GameObject achievementMenuPanel;
    // Start is called before the first frame update
    public void openAchievementMenu()
    {
        if (achievementMenuPanel != null)
        {
            achievementMenuPanel.SetActive(true);
        }
        else
        {
            GameObject hud = GameObject.Find("HUD");
            if(hud == null){
                hud = GameObject.Find("HUDLevel2");
            }
            achievementMenuPanel = hud.transform.Find("Achievement/AchievementMenu").gameObject;
            achievementMenuPanel.SetActive(true);
        }

    }
}

