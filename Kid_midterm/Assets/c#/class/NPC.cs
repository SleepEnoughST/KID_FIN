using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("��ܸ��")]
    public ��� dataDialogue;
    [Header("��ܨt��")]
    public ��ܨt�� dialogueSystem;
    [Header("Ĳ�o��ܪ���H")]
    public string target = "�p���U";


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
