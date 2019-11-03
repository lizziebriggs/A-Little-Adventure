using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // == Character Information Variables ==
    [Header ("Information")]
    [SerializeField] private Color colour;

    // == Movement Variables ==
    [Header("Movement")]
    private Rigidbody rb;

    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float runSpeed = 10;
    [SerializeField] private float acceleration = 2;
    private float currentSpeed = 1;
    private Vector3 directionToMove = Vector3.zero;
    private Vector3 directionVector = Vector3.zero;

    // == Character Management Variables ==
    [Header("Management")]
    public bool isCurrentCharacter;
    private bool canMove;

    // == Camera Variables ==
    [Header("Camera")]
    [SerializeField] private Camera mainCamera;
    private FollowingCamera cameraController;


    void Start()
    {
        if(GetComponent<Rigidbody>() != null)
        {
            rb = GetComponent<Rigidbody>();
        }

        cameraController = mainCamera.GetComponent<FollowingCamera>();

        GetComponent<Renderer>().material.color = colour;

        currentSpeed = walkSpeed;
    }


    void Update()
    {
        if (isCurrentCharacter && !cameraController.moveCamera && !cameraController.rotateCamera) canMove = true;
        else canMove = false;
    }


    private void FixedUpdate()
    {
        if(canMove) MoveCharacter();
    }


    private void MoveCharacter()
    {
        if(Input.GetKey(KeyCode.LeftShift))
            SpeedUp();
        else
            SlowDown();

        transform.Rotate(0, Input.GetAxis("Horizontal") * currentSpeed, 0);
        directionToMove.z = Input.GetAxis("Vertical");
        directionVector = (rb.transform.right * directionToMove.x) + (rb.transform.forward * directionToMove.z);

        rb.MovePosition(rb.transform.position + Time.deltaTime * currentSpeed * directionVector);

    }


    private void SlowDown()
    {
        if (currentSpeed >= walkSpeed)
            currentSpeed -= acceleration * Time.deltaTime;
    }


    private void SpeedUp()
    {
        if (currentSpeed <= runSpeed)
            currentSpeed += acceleration * Time.deltaTime;
    }
}
