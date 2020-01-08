using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CatBehaviour : AIEnemyBase
{
    public enum CatState
    {
        Patrolling,
        Attacking
    }

    [Header("Behaviour")]
    public CatState currentState;

    [Header("AI")]
    [SerializeField] Transform[] pathOne;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        GetComponent<Renderer>().material.color = colour;

        currentState = CatState.Patrolling;
    }


    void Update()
    {
        switch (currentState)
        {
            case CatState.Patrolling:
                break;

            case CatState.Attacking:
                break;

            default:
                break;
        }
    }
}
