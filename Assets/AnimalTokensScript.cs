using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalTokensScript : MonoBehaviour
{

    public Button beeButton;
    public Button butterflyButton;
    public Button turtleButton;
    public Button polarBearButton;
    [SerializeField] private Text noAnimalsText;


    // Start is called before the first frame update
    void Start()
    {

        beeButton.gameObject.SetActive(false);
        butterflyButton.gameObject.SetActive(false);
        turtleButton.gameObject.SetActive(false);
        polarBearButton.gameObject.SetActive(false);

        noAnimalsText.gameObject.SetActive(true);



    }


    public void ShowBeeToken()
    {
        //Disable the 'no animals' text
        noAnimalsText.gameObject.SetActive(false);
        beeButton.gameObject.SetActive(true);
        beeButton.enabled = true;
    }

    public void ShowButterflyToken()
    {
        butterflyButton.gameObject.SetActive(true);
        butterflyButton.enabled = true;
    }

    public void ShowTurtleToken()
    {
        turtleButton.gameObject.SetActive(true);
        turtleButton.enabled = true;
    }

    public void ShowPolarBearToken()
    {
        polarBearButton.gameObject.SetActive(true);
        polarBearButton.enabled = true;
    }





}
