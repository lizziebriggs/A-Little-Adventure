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
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (other.gameObject.tag == "Player")
            {
                if (gameObject.tag == "Player")
                {
                    PlayerController interactee = other.GetComponent<PlayerController>();

                    if (gameObject.GetComponent<PlayerController>().isCurrentCharacter)
                    {
                        dialogueManager.StartDialogue(dialogue.messages[other.GetComponent<DialogueTrigger>().dialogueCode], interactee);
                    }
                }

                else if (gameObject.tag == "Interactable")
                    dialogueManager.StartDialogue(dialogue.messages[0], null);
            }
        }
    }
}
