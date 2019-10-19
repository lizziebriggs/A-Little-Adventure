using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private List<CharacterController> playableCharacters;
    [SerializeField] private CameraController mainCamera;

    private CharacterController currentCharacter;
    private int currentCharacterIndex;


    void Start()
    {
        currentCharacterIndex = 0;
    }


    void Update()
    {
        currentCharacter = playableCharacters[currentCharacterIndex];
        currentCharacter.isCurrentCharacter = true;

        if(Input.GetKeyDown(KeyCode.Tab))
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

        mainCamera.ChangeCharacterToFollow();
    }
}
