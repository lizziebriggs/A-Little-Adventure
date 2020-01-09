using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private LookAtCamera mainCamera = null;
    [SerializeField] private List<Transform> worldPlaceholders = new List<Transform>();

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


    public void ChangeCharacterToLookAt(PlayerController newCharacter)
    {
        mainCamera.characterToLookAt = newCharacter;
    }
}
