using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/New Dialogue")]
public class DialogueData : Dialogue{};


[System.Serializable]
public class Dialogue : ScriptableObject
{
    public string characterName;
    public Sprite character;
    public Message[] messages;
}


[System.Serializable]
public class Message
{
    public string text;
    public Response[] responses;
}


[System.Serializable]
public class Response
{
    public int next;
    public string reply;
    public string preReq;
    public string trigger;
}
