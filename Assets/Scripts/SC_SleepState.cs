using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_SleepState : SC_BaseState
{
    bool sleep;
    Vector3 basePos = Vector3.zero;
public override void OnStart(SC_StateMachine fsm)
    {
        stateMachine = fsm;
        Debug.Log("Sommeil");
    }
    public override void OnUpdate()
    {
        if (Vector3.Distance(stateMachine.transform.position, stateMachine.nest.position) <= 3.0f)
        {
            Initialization();
            if (basePos == Vector3.zero)
                basePos = stateMachine.transform.position;
            stateMachine.agent.enabled = false;
            stateMachine.transform.position = Vector3.Lerp(stateMachine.transform.position, stateMachine.nest.position, Time.deltaTime);

            if (!sleep && stateMachine.transform.position.y <= 0.3f)
            {
                Debug.Log("Ronflement mignon");
                sleep = true;
                stateMachine.delay = 6.0f;
            }
            if (sleep && stateMachine.delay <= 0)
            {
                Debug.Log("Réveil");
                OnStateEnd();
            }
        }
        else
        {
            stateMachine.agent.SetDestination(stateMachine.nest.position);
        }
    }

    public override void OnStateEnd()
    {
        stateMachine.transform.position = Vector3.Lerp(stateMachine.transform.position, basePos, Time.deltaTime);

        if (stateMachine.transform.position.y >= basePos.y - 0.5f)
        {
            stateMachine.agent.enabled = true;
            stateMachine.isTired = false;
            stateMachine.sleepTime = true;
            stateMachine.isExploring = true;
            stateMachine.OnStateEnd();
        }
    }
    public override void OnCollision(Collider other)
    {
    }

    void Initialization()
    {
        stateMachine.body.localScale = Vector3.Lerp(stateMachine.body.localScale, Vector3.one, Time.deltaTime);
    }
}
