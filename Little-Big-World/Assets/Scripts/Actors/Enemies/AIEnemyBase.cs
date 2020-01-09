using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class AIEnemyBase : EnemyBase
{
    // == AI Variables ==
    [Header("AI")]
    protected NavMeshAgent agent;
    protected Transform target;


    protected void Move()
    {
        agent.SetDestination(target.position);
    }
}
