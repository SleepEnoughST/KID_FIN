using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public void LoadScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
        score.Sc = 0;
    }
    public void Quit()
    {
        Application.Quit();
        print("Â÷¶}¹CÀ¸");
    }
}
