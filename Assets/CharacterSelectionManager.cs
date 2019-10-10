using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{

    [SerializeField]

    private static int CharID;

    public void SelectGirlCharacter()
    {
        CharID = 1;

    }

    public void SelectBoyCharacter()
    {
        CharID = 2;

    }

    public void Continue()
    {
        SceneManager.LoadScene("HomeTown");
    }


    //Returns the id of the character the user has chosen
    public static int GetCharID()
    {
        return CharID;
    }
}
