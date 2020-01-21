using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaineController : PlayerController
{
    // == Inventory Variables ==
    [Header("Inventory")]
    public bool hasRope = false;

    // == Skills Variables ==
    [Header("Skills")]
    [SerializeField] float jumpBoost = 2;

    private void BoostJump()
    {
        rb.AddForce(new Vector3(0, jumpHeight * jumpBoost, 0) * jumpSpeed, ForceMode.Impulse);
        isGrounded = false;
    }

    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Ground") && !isGrounded)
        {
            currentState = CharacterState.Idle;
            isGrounded = true;
        }
        else if (collision.gameObject.GetComponent<LanceController>() && !isGrounded)
            BoostJump();
    }
}
