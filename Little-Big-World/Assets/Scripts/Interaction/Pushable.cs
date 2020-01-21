using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pushable : Interactable
{
    private Rigidbody rb;
    [SerializeField] RigidbodyConstraints moveableAxis;

    public override void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.constraints = RigidbodyConstraints.FreezeAll;

        gameObject.tag = "Interactable";
        popup.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // If the character who can push the object collides with the object
        // unfreeze the axis that the object is meant to move along
        if (collision.gameObject == toBeInteractedBy)
            rb.constraints &= ~moveableAxis;
        else
            rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
