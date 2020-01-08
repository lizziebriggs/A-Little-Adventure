using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MouseBehaviour : EnemyBase
{
    [SerializeField] Transform target;

    private NavMeshAgent agent;

    public enum MouseState
    {
        Waiting,
        Following
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        GetComponent<Renderer>().material.color = colour;
    }


    void Update()
    {
        agent.SetDestination(target.position);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CharacterController>())
        {
            Debug.Log("You got caught by a mouse!");
        }
    }
}
