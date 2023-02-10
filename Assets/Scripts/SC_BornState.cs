using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_BornState : SC_BaseState
{
    public override void OnStart(SC_StateMachine fsm)
    {
        stateMachine = fsm;
        stateMachine.isTired = false;
        fsm.delay = 2;
        Debug.Log("Im a Tyranid Grrrrrrrr");
    }
    public override void OnUpdate()
    {
        OnStateEnd();
    }

    public override void OnStateEnd()
    {
        Debug.Log("Im gonna eat everything on this Universe !");
        int rand = Random.Range(0, 2);

        if(rand == 0)
        {
            stateMachine.sleepTime = false;
            stateMachine.isTired = true;
        }
        else
        {
            stateMachine.sleepTime = false;
            stateMachine.isExploring = true;
        }
        stateMachine.OnStateEnd();
    }
    public override void OnCollision(Collider other)
    {
    }

}
