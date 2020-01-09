using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : UIBase
{
    void Start()
    {
        UI.SetActive(false);
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
                Show();
            else if (Time.timeScale == 0)
                Hide();
        }
    }
}
