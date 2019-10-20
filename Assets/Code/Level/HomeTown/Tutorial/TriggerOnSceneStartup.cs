using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnSceneStartup : MonoBehaviour
{
    public Tutorial tutorial;

    void Start()
    {
        //tutorial.name = "Bernt";
        //tutorial.sentences[0] = "test1";
        //tutorial.sentences[1] = "test2";
        //tutorial.sentences[2] = "test3";

        FindObjectOfType<TutorialManager>().StartTutorial(tutorial);
    }

}
