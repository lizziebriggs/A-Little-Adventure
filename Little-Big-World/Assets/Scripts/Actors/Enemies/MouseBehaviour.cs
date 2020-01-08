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

    [SerializeField] Transform target = null;

    private NavMeshAgent agent;
    public MouseState currentState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        GetComponent<Renderer>().material.color = colour;

        currentState = MouseState.Following;
    }


    void Update()
    {
        switch (currentState)
        {
            case MouseState.Waiting:
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
}
