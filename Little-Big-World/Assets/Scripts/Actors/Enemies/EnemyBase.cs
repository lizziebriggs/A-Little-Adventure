using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBase : MonoBehaviour
{
    // == Character Information Variables ==
    [Header("Information")]
    [SerializeField] protected Color colour = Color.white;

    // == Movement Variables ==
    [Header("Movement")]
    [SerializeField] protected float speed = 5;

    protected Rigidbody rb;
}
