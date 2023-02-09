using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_StateMachine : MonoBehaviour
{
    SC_BaseState currentState;
    public List<Transform> waypoints;
    public NavMeshAgent agent { get; private set; }

    public bool isHungry, isExploring, isTired, sleepTime, isFighting, hasNoFood, hasEatEnough, isDead;

    public Transform body;
    public Transform nest;

    public float delay = 0f;

    private void Awake()
    {
        currentState = new SC_BornState();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        currentState.OnStart(this);
    }

    void Update()
    {
        if(delay <= 0f)
        {
            currentState.OnUpdate();
        }
        delay -= Time.deltaTime;
    }

    public void OnStateEnd() 
    { 
        if(isExploring)
        {
            currentState = new SC_ExploringState();
        }

        if(isHungry)
        {
            currentState = new SC_EatState();
        }

        if(isTired)
        {
            currentState = new SC_SleepState();
        }

        if (hasNoFood)
        {
            currentState = new SC_NoFoodState();
        }

        if (isFighting)
        {
            currentState = new SC_FightState();
        }

        if(hasEatEnough)
        {
            currentState = new SC_EatEnoughState();
        }

        if(isDead)
        {
            currentState = new SC_DieState();
        }

        currentState.OnStart(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        currentState.OnCollision(other);
    }
}

