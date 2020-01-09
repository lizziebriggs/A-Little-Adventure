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
    [SerializeField] private float attackSpeed;
    [SerializeField] private float swapDistance = 3;
    [SerializeField] private List<Path> paths = new List<Path>();
    public int pathIndex, waypointIndex;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        GetComponent<Renderer>().material.color = colour;

        agent.speed = speed;

        pathIndex = 0;
        waypointIndex = 0;

        target = paths[pathIndex].waypoints[waypointIndex];

        currentState = CatState.Patrolling;
    }


    void Update()
    {
        switch (currentState)
        {
            case CatState.Patrolling:
                Patrol(paths[pathIndex]);
                break;

            case CatState.Attacking:
                AttackPlayer();
                break;

            default:
                break;
        }
    }


    private void Patrol(Path path)
    {
        if(agent.remainingDistance <= swapDistance + agent.stoppingDistance)
        {
            waypointIndex++;

            if (waypointIndex > path.waypoints.Count - 1)
            {
                waypointIndex = 0;
                pathIndex++;

                if (pathIndex > paths.Count - 1)
                    pathIndex = 0;
            }

            target = path.waypoints[waypointIndex];
            agent.SetDestination(target.position);
        }
    }


    private void AttackPlayer()
    {
        agent.SetDestination(target.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.gameObject.transform;
            currentState = CatState.Attacking;
        }
    }
}
