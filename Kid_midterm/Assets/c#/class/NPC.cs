using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("對話資料")]
    public 對話 dataDialogue;
    [Header("對話系統")]
    public 對話系統 dialogueSystem;
    [Header("觸發對話的對象")]
    public string target = "小紅帽";


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.name == target)
        {
            dialogueSystem.StartDialogue(dataDialogue.dialogues);
        }
           
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == target)
        {
            dialogueSystem.StopDialogue();
        }
    }
}
