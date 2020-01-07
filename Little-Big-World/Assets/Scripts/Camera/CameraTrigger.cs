using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager = null;
    [SerializeField] private int index = 0;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            cameraManager.ChangeWorldPosition(index);
            //Debug.Log("Collided with player");
        }
    }
}
