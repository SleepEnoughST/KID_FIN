using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class com_damage : MonoBehaviour
{
    public int damage; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        character_blood1 rubyGO = collision.GetComponent<character_blood1>();
        // print("碰到的東西是:" + rubyGO);
        rubyGO.ChangeHealth(-damage);   // 碰撞後刪除遊戲物件
    }
}
