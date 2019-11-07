using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public CharacterController characterToLookAt;


    void Update()
    {
        transform.LookAt(characterToLookAt.transform, Vector3.up);
    }


    public void ChangePosition(Transform newPosition)
    {
        transform.position = newPosition.transform.position;
    }
}
