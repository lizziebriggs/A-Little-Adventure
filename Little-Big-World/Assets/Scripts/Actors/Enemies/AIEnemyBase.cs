using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class AIEnemyBase : MonoBehaviour
{
    // == Character Information Variables ==
    [Header("Information")]
    [SerializeField] protected Color colour = Color.white;

    // == Movement Variables ==
    [Header("Movement")]
    [SerializeField] protected float speed = 5;
    protected Rigidbody rb;

    // == AI Variables ==
    [Header("AI")]
    protected NavMeshAgent agent;
    protected Transform target;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<CharacterController>())
        {
            Debug.Log("You got caught by a " + gameObject.name + "!");
            // : Call death screen
        }
    }
}
