using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private LookAtCamera mainCamera = null;
    [SerializeField] private List<Transform> worldPlaceholders;

    void Start()
    {
        mainCamera.ChangePosition(worldPlaceholders[0]);
    }


    void Update()
    {
        
    }


    public void ChangeWorldPosition(int newPosition)
    {
        mainCamera.ChangePosition(worldPlaceholders[newPosition]);
    }


    public void ChangeCharacterToLookAt(CharacterController newCharacter)
    {
        mainCamera.characterToLookAt = newCharacter;
    }
}
