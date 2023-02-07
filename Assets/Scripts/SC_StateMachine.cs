using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.AI;

public class SC_StateMachine : MonoBehaviour
{
    private SC_BaseState currentState;
    [SerializeField] public List<GameObject> waypoints;
    public bool Hungry, FoundBody, Tired, HasWin, HasLost, NoFood, EatEnough;

    public NavMeshAgent agent;
    public Transform body;
    public float distanceTreshold = 2f;
    public int current = 0;
    public int delay = 2;

    void Start()
    {
        currentState = new SC_BornState();
        currentState.OnStart(this);
        agent = GetComponent<NavMeshAgent>();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint").ToList();
    }


    void Update()
    {
        currentState.OnUpdate();
    }

    public void OnStateEnd() 
    { 
        if(Hungry)
        {
            currentState = new SC_SearchFoodState();
        }

        if(FoundBody)
        {
            currentState = new SC_EatState();
        }
    }
}

