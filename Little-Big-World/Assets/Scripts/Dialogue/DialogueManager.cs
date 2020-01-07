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
    public CharacterController speaker;
    public bool playingDialogue;

    void Start()
    {
        lines = new Queue<string>();
        images = new Queue<Sprite>();
    }

    void Update()
    {
        if(playingDialogue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                DisplayNextLine();
        }
    }

    public void StartDialogue(Message dialogue, CharacterController _speaker)
    {
        //Debug.Log("Start conversation");
        speaker = _speaker;
        speaker.currentState = CharacterController.CharacterState.Speaking;

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
        if(lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        Sprite dialogueImage = images.Dequeue();
        dialogueUI.dialogueImage.sprite = dialogueImage;

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
    }

    public void EndDialogue()
    {
        speaker.currentState = CharacterController.CharacterState.Idle;

        animator.SetBool("IsOpen", false);
        playingDialogue = false;

        //Debug.Log("End conversation");
    }
}
