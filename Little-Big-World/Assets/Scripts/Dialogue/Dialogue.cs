using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/New Dialogue")]

[System.Serializable]
public class Dialogue : ScriptableObject
{
    [Header("Conversations")]
    public Message[] messages;
}


[System.Serializable]
public class Message
{
    public Sprite[] characterEmotions;
    [TextArea(3, 5)]
    public string[] lines;
}
