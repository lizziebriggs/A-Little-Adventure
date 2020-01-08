using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu = null;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1) Show();

            else if (Time.timeScale == 0) Hide();
        }
    }

    public void Show()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void Hide()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
