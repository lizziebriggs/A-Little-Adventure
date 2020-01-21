using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : Interactable
{
    //private void Update()
    //{
    //    if (pickedUp)
    //        toBePickedUpBy.GetComponent<RaineController>().hasRope = true;
    //}

    public override void MarkAsPickedUp()
    {
        base.MarkAsPickedUp();

        toBeInteractedBy.GetComponent<RaineController>().hasRope = true;
    }
}