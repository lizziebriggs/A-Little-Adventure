using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private List<CharacterController> charactersToFollow;
    [SerializeField] private float transitionSpeed = 2;

    private int currentCharacterIndex;
    private Transform currentPosition;

    public bool moveCamera, rotateCamera;


    void Start()
    {
        currentPosition = charactersToFollow[currentCharacterIndex].transform.GetChild(0);
    }


    void Update()
    {
        if (!moveCamera && !rotateCamera)
        {
            transform.position = currentPosition.transform.position;
            transform.LookAt(charactersToFollow[currentCharacterIndex].transform, Vector3.up);
        }
        else
        {
            MoveCamera();
            RotateCamera();
        }
    }


    public void ChangeCharacterToFollow()
    {
        currentCharacterIndex++;

        if (currentCharacterIndex > charactersToFollow.Count - 1)
            currentCharacterIndex = 0;

        moveCamera = true;
        rotateCamera = true;
    }


    private void MoveCamera()
    {
        Transform newCameraPosition = charactersToFollow[currentCharacterIndex].transform.GetChild(0);

        transform.position = Vector3.MoveTowards(transform.position, newCameraPosition.position, transitionSpeed * Time.deltaTime);

        if (transform.position == newCameraPosition.position)
        {
            currentPosition = newCameraPosition;
            moveCamera = false;
        }
    }


    private void RotateCamera()
    {
        var newCharacterToFollow = Quaternion.LookRotation(charactersToFollow[currentCharacterIndex].transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newCharacterToFollow, transitionSpeed / 3 * Time.deltaTime);

        if (transform.rotation == newCharacterToFollow)
            rotateCamera = false;
    }
}
