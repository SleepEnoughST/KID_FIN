using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class com_damage : MonoBehaviour
{
    public int damage; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        character_blood1 rubyGO = collision.GetComponent<character_blood1>();
        // print("�I�쪺�F��O:" + rubyGO);
        rubyGO.ChangeHealth(-damage);   // �I����R���C������
    }
}
