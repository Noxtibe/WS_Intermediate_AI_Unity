using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SC_BaseState
{
    public SC_StateMachine stateMachine;
    abstract public void OnStart(SC_StateMachine fsm);

    abstract public void OnUpdate();

    abstract public void OnStateEnd();

    abstract public void OnCollision(Collider other);
}

