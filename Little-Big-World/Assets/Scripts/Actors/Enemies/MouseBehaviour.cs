using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MouseBehaviour : EnemyBase
{
    public enum MouseState
    {
        Waiting,
        Following
    }

    [SerializeField] Transform spawnPoint = null;
    [SerializeField] Transform target = null;

    private NavMeshAgent agent;
    public MouseState currentState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        GetComponent<Renderer>().material.color = colour;

        transform.position = spawnPoint.position;

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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CharacterController>())
        {
            Debug.Log("You got caught by a mouse!");
        }
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
