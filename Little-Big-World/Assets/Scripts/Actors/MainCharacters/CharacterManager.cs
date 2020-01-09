using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<CharacterController> playableCharacters = new List<CharacterController>();
    [SerializeField] private CameraManager cameraManager = null;
    [SerializeField] private MouseManager mouseManager = null;

    private CharacterController currentCharacter;
    private int currentCharacterIndex;


    void Start()
    {
        currentCharacterIndex = 0;
        currentCharacter = playableCharacters[currentCharacterIndex];

        mouseManager.ChangeTarget(currentCharacter.transform);
    }


    void Update()
    {
        cameraManager.ChangeCharacterToLookAt(currentCharacter);
        currentCharacter.isCurrentCharacter = true;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeCurrentCharacter();

            if (mouseManager)
                mouseManager.ChangeTarget(currentCharacter.transform);
        }
    }

    
    private void ChangeCurrentCharacter()
    {
        currentCharacter.isCurrentCharacter = false;
        currentCharacterIndex++;

        if (currentCharacterIndex > playableCharacters.Count - 1)
            currentCharacterIndex = 0;

        currentCharacter = playableCharacters[currentCharacterIndex];
    }
}
