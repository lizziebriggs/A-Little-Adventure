using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairGrip : Interactable
{
    public override void MarkAsPickedUp()
    {
        toBeInteractedBy.GetComponent<ConnieController>().hasHairGrip = true;
    }
}
