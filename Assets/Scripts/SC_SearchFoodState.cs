using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SC_SearchFoodState : SC_BaseState
{
    public SC_StateMachine stateMachine;
    int current = 0;

    public override void OnStart(SC_StateMachine fsm)
    {
        stateMachine = fsm;
        stateMachine.delay = 3f;
        Debug.Log("Food... where is food ?");
    }

    public override void OnUpdate()
    {
        if (Vector3.Distance(stateMachine.transform.position, stateMachine.waypoints[current].transform.position) <= stateMachine.distanceTreshold)
        {
            current = (current + 1) % (stateMachine.waypoints.Count);
            MoveToNextWaypoint();
        }

        /*else if()
        {

        }*/

    }

    public override void OnStateEnd()
    {
        Debug.Log("IIIII FOOOOUUUNNND YOUUUUUU !!!");
    }

    void MoveToNextWaypoint()
    {
        stateMachine.agent.SetDestination(stateMachine.waypoints[current].transform.position);
    }
}
