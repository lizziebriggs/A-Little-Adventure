using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MouseBehaviour : AIEnemyBase
{
    public enum MouseState
    {
        Waiting,
        Following
    }

    [SerializeField] Transform spawnPoint = null;

    [Header("Behaviour")]
    public MouseState currentState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        GetComponent<Renderer>().material.color = colour;

        agent.speed = speed;

        transform.position = spawnPoint.position;

        target = spawnPoint;
        currentState = MouseState.Waiting;
    }


    void Update()
    {
        switch (currentState)
        {
            case MouseState.Waiting:
                agent.SetDestination(spawnPoint.position);
                break;

            case MouseState.Following:
                agent.SetDestination(target.position);
                break;

            default:
                break;
        }
    }


    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.position == target.position)
        {
            currentState = MouseState.Following;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.position == target.position)
        {
            currentState = MouseState.Waiting;
        }
    }
}
