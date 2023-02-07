using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_BornState : SC_BaseState
{
    public SC_StateMachine stateMachine;

    public override void OnStart(SC_StateMachine fsm)
    {
        stateMachine = fsm;
        stateMachine.delay = 2;
        Debug.Log("Im a Tyranid Grrrrrrrr");
    }
    public override void OnUpdate()
    {
        OnStateEnd();
    }

    public override void OnStateEnd()
    {
        //Debug.Log("Im gonna eat everything on this Universe !");
        int rand = Random ;
    }

}
