using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 遊戲暫停 : MonoBehaviour
{
    public static bool GameIsPaued = false;
    public GameObject PauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaued)
            {
                Resume();
            } else
            {
                Pause();
            }    
        }
    }

    void Resume ()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaued = false;
    }   
    
    void Pause ()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaued = true;
    }    
}
