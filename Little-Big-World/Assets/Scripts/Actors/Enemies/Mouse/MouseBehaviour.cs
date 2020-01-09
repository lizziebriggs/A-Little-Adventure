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
    public Transform playerToAttack;

    [Header("Behaviour")]
    public MouseState currentState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();

        GetComponent<Renderer>().material.color = colour;

        // Set position in world as its spawn
        transform.position = spawnPoint.position;

        target = spawnPoint;
        currentState = MouseState.Waiting;
    }


    void Update()
    {
        switch (currentState)
        {
            case MouseState.Waiting:
                //Idle
                if (transform != spawnPoint)
                    Move();
                break;

            case MouseState.Following:
                Move();
                break;

            default:
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the mouse's detection then start following
        // the player
        if (other.gameObject.transform.position == playerToAttack.position)
        {
            target = playerToAttack;
            currentState = MouseState.Following;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        // If the player leaves the the mouse's detection the mouse return
        // to spawn and wait
        if (other.gameObject.transform.position == target.position)
        {
            target = spawnPoint;
            currentState = MouseState.Waiting;
        }
    }
}
