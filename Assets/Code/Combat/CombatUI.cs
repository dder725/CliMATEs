using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    Text healthText;
    public ProgressBar playerHealthBar;
    public ProgressBar mobHealthBar;

    public Text playerDamageText;

    public Text mobDamageText;
    // Start is called before the first frame update
    void Start()
    {
        playerDamageText.enabled = false;
        mobDamageText.enabled = false;

        playerHealthBar = GameObject.Find("PlayerHealth").GetComponent<ProgressBar>();
        playerHealthBar.BarValue = GameObject.Find("Player").GetComponent<CombatStats>().health;


        mobHealthBar = GameObject.Find("MobHealth").GetComponent<ProgressBar>();
        mobHealthBar.BarValue = GameObject.Find("Monster").GetComponent<CombatStats>().health;
    }

    // Update is called once per frame
    void Update()
    {
        //Check if health of either party has changed
        if (playerHealthBar.BarValue != GameObject.Find("Player").GetComponent<CombatStats>().health)
        {
            StartCoroutine("DamagePopUp", "Player");
        }

        if (mobHealthBar.BarValue != GameObject.Find("Monster").GetComponent<CombatStats>().health)
        {
            StartCoroutine("DamagePopUp", "Monster");
        }

        // Update healthbars
        playerHealthBar.BarValue = GameObject.Find("Player").GetComponent<CombatStats>().health;
        mobHealthBar.BarValue = GameObject.Find("Monster").GetComponent<CombatStats>().health;

    }

    IEnumerator DamagePopUp(string objName)
    {
        Text damagePopUp;
        int damage = 0;

        Debug.LogFormat(objName + "'s Health CHANGED by!" + damage);


        // Determine who's health changed
        if (objName.Equals("Player"))
        {
            damagePopUp = playerDamageText;
            damage = (int)playerHealthBar.BarValue - GameObject.Find(objName).GetComponent<CombatStats>().health;
        }
        else
        {
            damagePopUp = mobDamageText;
            damage = (int)mobHealthBar.BarValue - GameObject.Find(objName).GetComponent<CombatStats>().health;

        }

        // Determine if damage or heal
        damagePopUp.enabled = true;
        if (damage > 0)
        {
            damagePopUp.text = "-" + damage.ToString() + "HP";
            damagePopUp.color = Color.red;
        }
        else
        {
            damage = damage * -1;
            damagePopUp.text = "+" + damage.ToString() + "HP";
            damagePopUp.color = new Color(.17f,.55f,.08f);
        }


        // Fading
        for (float ft = 1f; ft >= 0; ft -= 0.1f)
        {
            Color c = damagePopUp.color;
            c.a = ft;
            damagePopUp.color = c;
            yield return new WaitForSeconds(.1f);
        }
        damagePopUp.enabled = false;
    }

}
