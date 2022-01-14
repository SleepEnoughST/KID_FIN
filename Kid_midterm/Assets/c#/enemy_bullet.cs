using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        Destroy(gameObject, 4.0f);                      //消失
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(-transform.right * Time.deltaTime * 2);    //移动    

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("當前子彈碰撞到：" + collision.gameObject);
        var hit = collision.gameObject;
        var health = hit.GetComponent<character_blood1>();
        if (health != null)
        {
            health.ChangeHealth(-10);
        }
        Destroy(gameObject);
    }
}
