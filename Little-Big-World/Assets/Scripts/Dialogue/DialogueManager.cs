using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public DialogueUI dialogueUI;
    public Animator animator;

    private Queue<string> lines;
    private Queue<Sprite> images;
    public PlayerController speaker;
    public bool playingDialogue;

    void Start()
    {
        lines = new Queue<string>();
        images = new Queue<Sprite>();

        dialogueUI.endOfLine.gameObject.SetActive(false);
    }

    void Update()
    {
        if(playingDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                DisplayNextLine();
        }
    }

    public void StartDialogue(Message dialogue, PlayerController _speaker)
    {
        if(_speaker)
        {
            speaker = _speaker;
            speaker.currentState = PlayerController.CharacterState.Speaking;
        }

        animator.SetBool("IsOpen", true);
        playingDialogue = true;

        lines.Clear();
        images.Clear();

        foreach (string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }

        foreach (Sprite image in dialogue.characterEmotions)
        {
            images.Enqueue(image);
        }

        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        dialogueUI.endOfLine.gameObject.SetActive(false);

        if(lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        // If the dialogue doesn't have any images (i.e. interactables/not enough
        //images per line set the image transparency to 0 so no image is displayed
        if (images.Count != lines.Count)
        {
            // Set the image to be transparent
            SetDialogueImageColour(0f);
        }
        else
        {
            Sprite dialogueImage = images.Dequeue();
            SetDialogueImageColour(1f);
            dialogueUI.dialogueImage.sprite = dialogueImage;
        }

        string line = lines.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeLine(line));

    }

    IEnumerator TypeLine(string line)
    {
        dialogueUI.dialogueText.text = "";

        foreach (char letter in line.ToCharArray())
        {
            dialogueUI.dialogueText.text += letter;
            yield return null;
        }

        dialogueUI.endOfLine.gameObject.SetActive(true);
    }

    public void EndDialogue()
    {
        if(speaker)
            speaker.currentState = PlayerController.CharacterState.Idle;

        animator.SetBool("IsOpen", false);
        playingDialogue = false;
    }


    private void SetDialogueImageColour(float alpha)
    {
        Color tempColour = dialogueUI.dialogueImage.color;
        tempColour.a = alpha;
        dialogueUI.dialogueImage.color = tempColour;
    }
}
