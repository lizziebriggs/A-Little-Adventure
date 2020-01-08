using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : EnemyBase
{

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GetComponent<Renderer>().material.color = colour;
    }


    void Update()
    {
        
    }
}
