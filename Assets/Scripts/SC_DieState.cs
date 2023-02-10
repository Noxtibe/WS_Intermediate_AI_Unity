using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_DieState : SC_BaseState
{
    public override void OnStart(SC_StateMachine fsm)
    {
        Debug.Log("J'ai était vaincu !");
        stateMachine = fsm;
    }
    public override void OnUpdate()
    {
        OnStateEnd();
    }

    public override void OnStateEnd()
    {
        Debug.Log("Le Tyranid est mort de ses blessures au combat...");
    }
    public override void OnCollision(Collider other)
    {
    }
}
