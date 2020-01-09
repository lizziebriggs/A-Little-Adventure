using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [SerializeField] protected GameObject UI = null;
    [SerializeField] protected Animator animator = null;

    public void Show()
    {
        //UI.SetActive(true);
        animator.SetBool("IsOpen", true);
        Time.timeScale = 0;
    }

    public void Hide()
    {
        animator.SetBool("IsOpen", false);
        Time.timeScale = 1;
        //UI.SetActive(false);
    }
}
