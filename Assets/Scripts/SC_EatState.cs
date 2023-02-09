using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_EatState : SC_BaseState
{
    bool awake = false;
    float delay = 2.0f;

    public override void OnStart(SC_StateMachine fsm)
    {
        stateMachine = fsm;
        Debug.Log("Im gonna miam miam");
    }

    public override void OnUpdate()
    {
        Debug.Log("Food location fouuuuund");

        if (Vector3.Distance(stateMachine.transform.position, stateMachine.body.position) <= 2.5f)
        {
            stateMachine.agent.isStopped = true;
            if(!awake)
            {
                stateMachine.delay = delay;
                awake = true;
            }
            else if(stateMachine.delay <= 0)
            {
                stateMachine.body.localScale = Vector3.Lerp(stateMachine.body.localScale, Vector3.zero, Time.deltaTime);
            }
            if(stateMachine.body.localScale.x <= 0.01f)
            {
                OnStateEnd();
            }
        }
        else
        {
            stateMachine.agent.SetDestination(stateMachine.body.position);
        }
    }

    public override void OnStateEnd()
    {
        Debug.Log("J'AI ENCORE FAIM !");
        stateMachine.agent.isStopped = false;
        stateMachine.isHungry = false;
        stateMachine.isExploring = true;
        stateMachine.OnStateEnd();
    }

    public override void OnCollision(Collider other)
    {
    }
}
