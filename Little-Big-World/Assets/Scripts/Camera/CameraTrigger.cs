using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private int index;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            cameraManager.ChangeWorldPosition(index);
            Debug.Log("Collided with player");
        }
    }
}
