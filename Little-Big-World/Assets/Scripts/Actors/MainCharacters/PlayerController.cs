using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public enum CharacterState
    {
        Idle,
        Walking,
        Running,
        Jumping,
        Speaking
    }

    // == Character Information Variables ==
    [Header("Information")]
    public string characterName;
    [SerializeField] private Color colour = Color.white;

    // == Movement Variables ==
    [Header("Movement")]
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float runSpeed = 10;
    [SerializeField] private float acceleration = 2;
    [SerializeField] private float jumpHeight = 1;
    [SerializeField] private float jumpSpeed = 5;

    private Rigidbody rb;

    private float currentSpeed = 1;
    private Vector3 directionToMove = Vector3.zero;
    private Vector3 directionVector = Vector3.zero;
    private bool isGrounded = true;

    // == Interaction Variables ==
    [Header("Interaction")]
    public GameObject interactText = null;

    // == Character Management Variables ==
    [Header("Management")]
    [SerializeField] private DialogueManager dialogueManager = null;
    public CharacterState currentState;
    public bool isCurrentCharacter;
    private bool canMove;

    // !! Only needed when using FollowingCamera function !!
    // == Camera Variables ==
    //[Header("Camera")]
    //[SerializeField] private Camera mainCamera = null;
    //private FollowingCamera cameraController;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Only needed when using FollowingCamera function
        //cameraController = mainCamera.GetComponent<FollowingCamera>();

        GetComponent<Renderer>().material.color = colour;

        currentSpeed = walkSpeed;
        currentState = CharacterState.Idle;

        interactText.gameObject.SetActive(false);
    }


    void Update()
    {
        // add < && !cameraController.moveCamera && !cameraController.rotateCameran > when using FollowingCamera
        if (isCurrentCharacter && !dialogueManager.playingDialogue)
            canMove = true;
        else canMove = false;

        if (isCurrentCharacter)
            interactText.SetActive(false);
    }


    private void FixedUpdate()
    {
        if (canMove) MoveCharacter();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("Ground") && isGrounded == false)
        {
            currentState = CharacterState.Idle;
            isGrounded = true;
        }
    }


    private void MoveCharacter()
    {
        // Character running transition
        if ((Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) && isGrounded)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                currentState = CharacterState.Running;
                SpeedUp();
            }
            else
            {
                currentState = CharacterState.Walking;
                SlowDown();
            }
        }
        else if (isGrounded)
            currentState = CharacterState.Idle;

        // Character jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            currentState = CharacterState.Jumping;
            Jump();
        }

        // Get character moving input
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


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            // If it's not the current player and they're trigger colliding with the player
            if (!isCurrentCharacter && other.gameObject.GetComponent<PlayerController>().isCurrentCharacter)
                interactText.SetActive(true);

            else
                interactText.SetActive(false);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<PlayerController>().interactText.SetActive(false);
    }
}
