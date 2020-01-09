using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenUI : UIBase
{
    [SerializeField] private Text message = null;

    void Start()
    {
        //UI.SetActive(false);
        animator.SetBool("IsOpen", false);
    }

    public void SetMessage(string text)
    {
        message.text = "You got caught by a " + text + "!";
    }
}
