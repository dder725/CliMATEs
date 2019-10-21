using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementMenu : MonoBehaviour
{
    public GameObject achievementMenuPanel;
    // Start is called before the first frame update
    public void openAchievementMenu(){
        if(achievementMenuPanel != null){
            achievementMenuPanel.SetActive(true);
        }
    }
}
