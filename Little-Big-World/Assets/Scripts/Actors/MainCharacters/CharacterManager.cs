using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<CharacterController> playableCharacters = new List<CharacterController>();
    [SerializeField] private CameraManager cameraManager = null;

    private CharacterController currentCharacter;
    private int currentCharacterIndex;


    void Start()
    {
        currentCharacterIndex = 0;
    }


    void Update()
    {
        currentCharacter = playableCharacters[currentCharacterIndex];
        cameraManager.ChangeCharacterToLookAt(currentCharacter);
        currentCharacter.isCurrentCharacter = true;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ChangeCurrentCharacter();
        }
    }

    
    private void ChangeCurrentCharacter()
    {
        currentCharacter.isCurrentCharacter = false;
        currentCharacterIndex++;

        if (currentCharacterIndex > playableCharacters.Count - 1)
            currentCharacterIndex = 0;
    }
}
