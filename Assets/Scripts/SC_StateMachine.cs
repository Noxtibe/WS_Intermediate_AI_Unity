using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_StateMachine : MonoBehaviour
{
    public SC_BaseState currentState;
    bool Hungry, Inanimate, Tired, HasWin, HasLost, NoFood, EatEnough;

    void Start()
    {
        currentState.OnStart(this);
    }


    void Update()
    {
        currentState.OnUpdate();
    }

    public void OnStateEnd() 
    { 

    }


    private void OnCollisionEnter(Collision collision)
    {
        
    }

}

