using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager = null;
    [SerializeField] public int dialogueCode = 0;

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        //dialogueManager.StartDialogue(dialogue);
    }


    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.Return) && !dialogueManager.playingDialogue)
        {
            if (other.gameObject.tag == "Player")
            {
                PlayerController interactee = other.GetComponent<PlayerController>();

                // The it's interacting with another character
                if (gameObject.tag == "Player")
                {
                    if (gameObject.GetComponent<PlayerController>().isCurrentCharacter)
                    {
                        dialogueManager.StartDialogue(dialogue.messages[other.GetComponent<DialogueTrigger>().dialogueCode], interactee);
                    }
                }

                // If it's interacting with an object
                else if (gameObject.tag == "Interactable" && interactee.isCurrentCharacter)
                {
                    Interactable interactor = gameObject.GetComponent<Interactable>();

                    // If it's meant to be picked up by the character interacting with it then
                    // play this dialogue
                    if(other.gameObject != interactor.toBePickedUpBy)
                        dialogueManager.StartDialogue(dialogue.messages[0], null);
                    else
                        dialogueManager.StartDialogue(dialogue.messages[1], null);

                }
            }
        }
    }
}
