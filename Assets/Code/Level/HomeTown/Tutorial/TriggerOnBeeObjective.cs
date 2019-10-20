using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnBeeObjective : MonoBehaviour
{
    public Tutorial tutorial;

    public void TriggerTutorial()
    {
        //tutorial.name = "Bernt";
        //tutorial.sentences[0] = "test1";
        //tutorial.sentences[1] = "test2";
        //tutorial.sentences[2] = "test3";

        FindObjectOfType<TutorialManager>().StartTutorial(tutorial);
    }

}
