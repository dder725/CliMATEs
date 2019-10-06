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
        beeButton.enabled = true;
    }

    public void ShowButterflyToken()
    {
        butterflyButton.enabled = true;
    }

    public void ShowTurtleToken()
    {
        turtleButton.enabled = true;
    }

    public void ShowPolarBearToken()
    {
        polarBearButton.enabled = true;
    }





}
