using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective10City : Objective
{

    public Transform newEcoWorker;
    private WanderingTalkingNPC ecoWorkerScript;
    public Transform oldEcoWorker;

    public Transform tokens;
    private AnimalTokensScript animalTokensScript;
    private HUDButtons HUDButtons;

    public bool isDone;
    public override void GiveObjectiveRewards()
    {

        Debug.Log("Penguin token gained");
        HUDButtons = FindObjectOfType<HUDButtons>();
        HUDButtons.ShowAnimals();

        //animalTokensScript = FindObjectOfType<AnimalTokensScript>();
        animalTokensScript = tokens.GetComponent<AnimalTokensScript>();
        //animalTokensScript.ShowTuataraToken();
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return ecoWorkerScript.ConversationFinished() || isDone;
    }

    public override void RunStartUpLogicForObjective()
    {
        Instantiate(newEcoWorker, oldEcoWorker.position, Quaternion.identity);
        ecoWorkerScript = newEcoWorker.GetComponent<WanderingTalkingNPC>();
        Destroy(oldEcoWorker);
    }

    public override void RunTearDownLogicForObjective()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
