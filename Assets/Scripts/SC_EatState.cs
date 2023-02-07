using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class SC_EatState : SC_BaseState
{
    public SC_StateMachine stateMachine;

    public override void OnStart(SC_StateMachine fsm)
    {
        stateMachine = fsm;
        Debug.Log("Im gonna miam miam");

    }

    public override void OnUpdate()
    {
        Debug.Log("Food location fouuuuund");

        if (Vector3.Distance(stateMachine.transform.position, stateMachine.body.position) <= stateMachine.distanceTreshold)
        {
            stateMachine.agent.isStopped = true;
            stateMachine.body.localScale = Vector3.Lerp(stateMachine.body.localScale, Vector3.zero, Time.deltaTime);
        }
        else
        {
            stateMachine.agent.SetDestination(stateMachine.body.position);
        }
        //stateMachine.agent.GetComponent<NavMeshAgent>().
    }

    public override void OnStateEnd()
    {
        
    }

  
}
