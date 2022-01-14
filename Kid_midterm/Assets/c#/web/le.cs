using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 對話提示 : MonoBehaviour
{
    public GameObject Button;
    public GameObject talkUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
    }

    void Update()
    {
        if (Button.activeSelf && Input.GetKeyDown(KeyCode.Z))
        {
            talkUI.SetActive(true);
        }
    }
}
