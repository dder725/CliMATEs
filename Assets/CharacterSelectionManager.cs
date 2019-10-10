using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{

    [SerializeField]

    //private GameObject girlCharacter;
    //private GameObject boyCharacter;



    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void SelectGirlCharacter()
    {

    }


    public void SelectBoyCharacter()
    {

    }


    public void Continue()
    {
        SceneManager.LoadScene("HomeTown");
    }
}
