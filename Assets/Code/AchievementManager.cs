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

    public ScrollRect achListView;
    public GameObject achListContent;
    public GameObject achListItemPrefab;

    //Achievement 01 -- First CliMATE
    public GameObject ach01Image;

    public static bool ach01Trigger;
    public bool ach01Triggered = false;

    //Achievement 02 -- Forest man
    public GameObject ach02Image;
    public static bool ach02Trigger;
    public bool ach02Triggered = false;

    //Achievement 03 -- Surf Up
    public GameObject ach03Image;
    public static bool ach03Trigger;
    public bool ach03Triggered = false;

    //Achievement 04 -- You do not talk about Fight Club
    public GameObject ach04Image;
    public static bool ach04Trigger;
    public bool ach04Triggered = false;
    // Update is called once per frame
    void Update()
    {
        if (ach01Trigger & !ach01Triggered)
        {
            Debug.Log("Achievement 1 unlocking!");
            StartCoroutine(Trigger01Ach());
        }

        if (ach02Trigger & !ach02Triggered)
        {
            Debug.Log("Achievement 2 unlocking!");
            StartCoroutine(Trigger02Ach());
        }
        if (ach03Trigger & !ach03Triggered)
        {
            Debug.Log("Achievement 3 unlocking!");
            StartCoroutine(Trigger03Ach());
        }
        if (ach03Trigger & !ach03Triggered)
        {
            Debug.Log("Achievement 3 unlocking!");
            StartCoroutine(Trigger03Ach());
        }
        if (ach04Trigger & !ach04Triggered)
        {
            Debug.Log("Achievement 4 unlocking!");
            StartCoroutine(Trigger04Ach());
        }
    }

    IEnumerator Trigger01Ach()
    {
        achActive = true;
        ach01Triggered = true;

        achTitle.GetComponent<Text>().text = "First CliMATE!";
        achDescription.GetComponent<Text>().text = "Your first buddy has joined your adventure";
        updateAchievementList("First CliMATE!", "Your first buddy has joined your adventure", ach01Image);

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

    IEnumerator Trigger02Ach()
    {
        achActive = true;
        ach02Triggered = true;

        achTitle.GetComponent<Text>().text = "The Hermitage";
        achDescription.GetComponent<Text>().text = "You found the forest hermit";
        updateAchievementList(achTitle.GetComponent<Text>().text, achDescription.GetComponent<Text>().text, ach02Image);

        achTitle.SetActive(true);
        achDescription.SetActive(true);
        // Add achievement to the list
        achSound.Play();
        ach02Image.SetActive(true);

        achNotification.SetActive(true);
        yield return new WaitForSeconds(7);


        //Resetting
        achNotification.SetActive(false);
        ach02Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }

    IEnumerator Trigger03Ach()
    {
        achActive = true;
        ach03Triggered = true;

        achTitle.GetComponent<Text>().text = "Surf Up!";
        achDescription.GetComponent<Text>().text = "You helped Surfer Dude";
        updateAchievementList(achTitle.GetComponent<Text>().text, achDescription.GetComponent<Text>().text, ach03Image);

        achTitle.SetActive(true);
        achDescription.SetActive(true);
        // Add achievement to the list
        achSound.Play();
        ach03Image.SetActive(true);

        achNotification.SetActive(true);
        yield return new WaitForSeconds(7);


        //Resetting
        achNotification.SetActive(false);
        ach03Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }

       IEnumerator Trigger04Ach()
    {
        achActive = true;
        ach04Triggered = true;

        achTitle.GetComponent<Text>().text = "Fight Club";
        achDescription.GetComponent<Text>().text = "You won your first fight!";
        updateAchievementList(achTitle.GetComponent<Text>().text, achDescription.GetComponent<Text>().text, ach04Image);

        achTitle.SetActive(true);
        achDescription.SetActive(true);
        // Add achievement to the list
        achSound.Play();
        ach04Image.SetActive(true);

        achNotification.SetActive(true);
        yield return new WaitForSeconds(7);


        //Resetting
        achNotification.SetActive(false);
        ach03Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDescription.GetComponent<Text>().text = "";
        achActive = false;
    }

    private void updateAchievementList(string title, string description, GameObject image)
    {
        Debug.Log("Updating the list");
        if (achListView.transform.Find("EmptyAchievementsText") != null)
        {
            Destroy(achListView.transform.Find("EmptyAchievementsText").gameObject);
        }
        else
        {
            Debug.Log("Could not find the empty achievements text");
        }
        GameObject achievementItem = Instantiate(achListItemPrefab);
        GameObject itemTitle = achievementItem.transform.Find("AchievementTitle").gameObject;
        itemTitle.GetComponent<Text>().text = title;
        GameObject itemDescription = achievementItem.transform.Find("AchievementDescription").gameObject;
        itemDescription.GetComponent<Text>().text = description;
        GameObject itemImage = achievementItem.transform.Find("achImage").gameObject;
        itemImage.GetComponent<RawImage>().texture = image.GetComponent<RawImage>().texture;
        achievementItem.transform.SetParent(achListContent.transform, false);

    }


}
