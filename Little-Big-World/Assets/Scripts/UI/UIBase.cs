using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [SerializeField] protected GameObject UI = null;

    public void Show()
    {
        Time.timeScale = 0;
        UI.SetActive(true);
    }

    public void Hide()
    {
        Time.timeScale = 1;
        UI.SetActive(false);
    }
}
