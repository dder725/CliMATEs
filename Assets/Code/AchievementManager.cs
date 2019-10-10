using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    // General Variables
    public GameObject achNotification;
    public AudioSource achSound;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDescription;

    //Achievement 01 -- First CliMATE
    public GameObject ach01Image;
    
    public static bool ach01Trigger;
    public bool ach01Triggered = false;
    // Update is called once per frame
    void Update()
    {
        if(ach01Trigger & !ach01Triggered){
            Debug.Log("Achievement unlocking!");
            StartCoroutine(Trigger01Ach());
        }
    }

    IEnumerator Trigger01Ach(){
        achActive = true;
        ach01Triggered = true;

        achTitle.GetComponent<Text>().text = "First CliMATE!";
        achDescription.GetComponent<Text>().text = "Your first buddy has joined your adventure";
        achTitle.SetActive(true);
        achDescription.SetActive(true);

        achSound.Play();
        ach01Image.SetActive(true);
      
        achNotification.SetActive(true);
        yield return new WaitForSeconds(7);

        //Resetting
        achNotification.SetActive(false);
        ach01Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }
}
