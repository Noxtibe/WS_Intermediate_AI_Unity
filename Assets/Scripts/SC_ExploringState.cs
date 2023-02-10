using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_ExploringState : SC_BaseState
{
    int current = 0;
    bool awake = false;
    float delay = 2.0f;

    public override void OnStart(SC_StateMachine fsm)
    {
        stateMachine = fsm;
        Debug.Log("Food... where is food ?");
        MoveToNextWaypoint();
    }

    public override void OnUpdate()
    {
        Debug.Log("Explore");
        if (Vector3.Distance(stateMachine.transform.position, stateMachine.waypoints[current].transform.position) <= 3.0f)
        {
            if(!awake)
            {
                awake = true;
                stateMachine.delay = delay;
                Debug.Log("awake true");
            }
            else if(stateMachine.delay <= 0)
            {
                current = (current + 1) % stateMachine.waypoints.Count;
                awake = false;
                OnStateEnd();
                Debug.Log("awake false");
            }  
        }
    }

    public override void OnStateEnd()
    {
        int rand = Random.Range(0, 3);

        switch(rand)
        {
            case 0:
                Debug.Log("Where is my food ?");
                MoveToNextWaypoint();
                break;
            case 1:
                Debug.Log("Found food !");
                stateMachine.isExploring = false;
                stateMachine.isHungry = true;
                stateMachine.OnStateEnd();
                break;
            case 2:
                Debug.Log("No food...");
                stateMachine.isExploring = false;
                stateMachine.hasNoFood = true;
                stateMachine.OnStateEnd();
                break;
            default:
                Debug.Log("Default");
                MoveToNextWaypoint();
                break;
        }
    }

    public void MoveToNextWaypoint()
    {
        stateMachine.agent.SetDestination(stateMachine.waypoints[current].transform.position);
    }

    public override void OnCollision(Collider other)
    {
        if(other.tag == "Enemy")
        {
            stateMachine.isExploring = false;
            stateMachine.isFighting = true;
            Debug.Log("FIGHTING HERESY TO EAT IT !");
            stateMachine.OnStateEnd();
        }
    }
}
