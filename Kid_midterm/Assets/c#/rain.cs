using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

        Destroy(gameObject, 15);           //消失
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(-transform.up * Time.deltaTime * 6);    

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("當前雨碰撞到：" + collision.gameObject);
        var hit = collision.gameObject;
        var health = hit.GetComponent<character_blood1>();
        if (health != null)
        {
            health.ChangeHealth(-10);
        }
        Destroy(gameObject);
    }
}
