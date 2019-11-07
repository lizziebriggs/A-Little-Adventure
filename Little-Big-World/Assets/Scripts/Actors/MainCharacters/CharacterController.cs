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
    [SerializeField] private float jumpHeight = 1;
    [SerializeField] private float jumpSpeed;

    private float currentSpeed = 1;
    private Vector3 directionToMove = Vector3.zero;
    private Vector3 directionVector = Vector3.zero;
    private bool isGrounded = true;

    // == Character Management Variables ==
    [Header("Management")]
    public bool isCurrentCharacter;
    private bool canMove;

    // == Camera Variables ==
    [Header("Camera")]
    // Only needed when using FollowingCamera function
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


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }


    private void MoveCharacter()
    {
        // Character running transition
        if(Input.GetKey(KeyCode.LeftShift))
            SpeedUp();
        else
            SlowDown();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();

        transform.Rotate(0, Input.GetAxis("Horizontal") * currentSpeed, 0);
        directionToMove.z = Input.GetAxis("Vertical");
        directionVector = (rb.transform.right * directionToMove.x) + (rb.transform.forward * directionToMove.z);
        
        // Player moves in direction of where they're facing
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


    private void Jump()
    {
        rb.AddForce(new Vector3(0, jumpHeight, 0) * jumpSpeed, ForceMode.Impulse);
        isGrounded = false;
    }
}
