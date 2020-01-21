using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnieController : PlayerController
{
    // == Inventory Variables ==
    [Header("Inventory")]
    public bool hasHairGrip = false;

    // == Skills Variables ==
    [Header("Skills")]
    [SerializeField] private GameObject scarf = null;
    [SerializeField] private float dragEffector = 5;


    //public override void Start()
    //{
    //    rb = GetComponent<Rigidbody>();

    //    // Only needed when using FollowingCamera function
    //    //cameraController = mainCamera.GetComponent<FollowingCamera>();

    //    currentSpeed = walkSpeed;
    //    currentState = CharacterState.Idle;

    //    scarf.SetActive(false);
    //    popup.gameObject.SetActive(false);
    //}


    public override void Update()
    {
        // add < && !cameraController.moveCamera && !cameraController.rotateCameran > when using FollowingCamera
        if (isCurrentCharacter && !dialogueManager.playingDialogue)
            canMove = true;
        else canMove = false;

        // Paraglide if the player holds P whilst jumping
        // Increasing drag causes the object to fall slower
        if (currentState == CharacterState.Jumping)
        {
            if (Input.GetKey(KeyCode.P))
            {
                rb.drag = dragEffector;
                scarf.SetActive(true);
            }
            else
            {
                rb.drag = 0f;
                scarf.SetActive(false);
            }
        }
        else if (scarf.activeSelf)
            scarf.SetActive(false);

        if (isCurrentCharacter)
            popup.SetActive(false);
    }
}
