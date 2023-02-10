using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SC_NoFoodState : SC_BaseState
{
    float delayBeforeDeath = 3.0f;
    bool dyingFromHunger = false;

    public override void OnStart(SC_StateMachine fsm)
    {
        Debug.Log("Naaaaaaann je meurs !");
        stateMachine = fsm;
    }
    public override void OnUpdate()
    {
        if (!dyingFromHunger)
        {
            stateMachine.delay = delayBeforeDeath;
        }
        if(stateMachine.delay <= 0)
        {
            Debug.Log("........");
            OnStateEnd();
        }
    }

    public override void OnStateEnd()
    {
        Debug.Log("Le Tyranid n'a pas trouvé de nourriture, il est un peu bête...");
    }
    public override void OnCollision(Collider other)
    {
    }
}
