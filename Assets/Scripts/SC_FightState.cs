using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_FightState : SC_BaseState
{
    public override void OnStart(SC_StateMachine fsm)
    {
        Debug.Log("This will be wild !");
        stateMachine = fsm;
    }
    public override void OnUpdate()
    {
        stateMachine.agent.isStopped = true;

        OnStateEnd();
    }

    public override void OnStateEnd()
    {
        int rand = Random.Range(0, 2);

        switch (rand)
        {
            case 0:
                Debug.Log("Fight Win");
                stateMachine.agent.isStopped = false;
                stateMachine.isFighting = false;
                stateMachine.isExploring = true;
                stateMachine.OnStateEnd();
                break;
            case 1:
                Debug.Log("Fight Lost");
                stateMachine.isFighting = false;
                stateMachine.isDead = true;
                stateMachine.OnStateEnd();
                break;
            default:
                Debug.Log("Default");
                stateMachine.agent.isStopped = false;
                stateMachine.isFighting = false;
                stateMachine.isExploring = true;
                break;
        }
    }
    public override void OnCollision(Collider other)
    {
    }
}
