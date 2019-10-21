using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSevenHT : Objective
{

    public Transform turtle;
    private TurtleCollider script;
    public override void GiveObjectiveRewards()
    {
    }

    public override bool ObjectiveGoalIsAchieved()
    {
        return script.IsInRange();
    }

    public override void RunStartUpLogicForObjective()
    {
        Instantiate(turtle, new Vector3(-6, -20, 0), Quaternion.identity);
        script = turtle.GetComponent<TurtleCollider>();
    }

    public override void RunTearDownLogicForObjective()
    {
    }
}
