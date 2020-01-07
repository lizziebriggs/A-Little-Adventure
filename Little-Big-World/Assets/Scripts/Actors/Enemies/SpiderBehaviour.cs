using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBehaviour : EnemyBase
{
    public enum SpiderState
    {
        Waiting,
        Dropping,
        Rising
    }

    [Header("Behaviour")]
    [SerializeField] private float[] dropSpeeds = null;
    [SerializeField] private float dropTimer = 3;
    public SpiderState currentState;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 dropPosition;
    private int dropSpeedIndex;
    private float timeTillDrop;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        GetComponent<Renderer>().material.color = colour;

        startPosition = transform.position;
        dropPosition = new Vector3(startPosition.x, 0, startPosition.z);

        dropSpeedIndex = 0;

        timeTillDrop = dropTimer;
        currentState = SpiderState.Waiting;
    }

    void Update()
    {
        switch (currentState)
        {
            case SpiderState.Waiting:
                Wait();
                break;

            case SpiderState.Dropping:
                Drop();
                break;

            case SpiderState.Rising:
                Rise();
                break;

            default:
                break;
        }
    }

    private void Wait()
    {
        timeTillDrop -= Time.deltaTime;

        if (timeTillDrop < 0)
            currentState = SpiderState.Dropping;
    }

    
    private void Drop()
    {
        transform.position = Vector3.MoveTowards(transform.position, dropPosition, dropSpeeds[dropSpeedIndex] * Time.deltaTime);
    }

    private void Rise()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);

        if(transform.position == startPosition)
        {
            currentState = SpiderState.Waiting;
            timeTillDrop = dropTimer;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<CharacterController>())
        {
            Debug.Log("You got caught by a spooder!");
        }

        if (collision.gameObject.tag == ("Ground"))
        {
            dropSpeedIndex++;
            if (dropSpeedIndex == dropSpeeds.Length) dropSpeedIndex = 0;

            currentState = SpiderState.Rising;
        }
    }
}
