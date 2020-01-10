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
    public SpiderState currentState;
    [SerializeField] private float speed = 5;
    [SerializeField] private float[] dropSpeeds = null;
    [SerializeField] private float dropTimer = 3;
    private Vector3 startPosition = Vector3.zero;
    private Vector3 dropPosition;
    private int dropSpeedIndex;
    private float timeTillDrop;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

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
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("You got caught by a " + enemyName + "!");
            deathScreen.SetMessage(gameObject.name);
            deathScreen.Show();
        }

        if (collision.gameObject.tag == ("Ground"))
        {
            dropSpeedIndex++;
            if (dropSpeedIndex == dropSpeeds.Length) dropSpeedIndex = 0;

            currentState = SpiderState.Rising;
        }
    }
}
