using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SearchFoodState : SC_BaseState
{
    public SC_StateMachine stateMachine;

    public override void OnStart(SC_StateMachine fsm)
    {
        stateMachine = fsm;
        Debug.Log("Food... where is food ?");
    }

    public override void OnUpdate()
    {

    }

    public override void OnStateEnd()
    {

    }

    public void MoveToNextWaypoint()
    {

    }
}
