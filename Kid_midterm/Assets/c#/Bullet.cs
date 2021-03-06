using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator Ani;
    public float bulletDis;

    //【擊中特效 1/2】
    public ParticleSystem hitEffect;

    // 當有使用 實例化生成函式 Instantiate() 就需要使用 Awake()
    private void Start()
    {
        Destroy(gameObject, 2.0f);
    }
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Ani = GetComponent<Animator>();
        bulletDis = transform.position.magnitude;
    }

    // 設定Launch(給予力的方向＆力的大小)
    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
        float k = GetComponent<Transform>().rotation.y;
        if (k < 0)
        {
            rb.AddForce(-direction * force);
        }
    }

    // 子彈的碰撞檢測
    private void OnCollisionEnter2D(Collision2D collision)
    {
       


        //【使物件消失 1/1】
        Destroy(gameObject); //子彈消失
        //Destroy(collision.gameObject); //碰撞到的物件消失
    }

    //【未擊中目標的子彈自動銷毀 1/1】以距離來計算
    void Update()
    {
        if (transform.position.magnitude > 100)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.tag == "enemy")
        {
            enemy_blood kgGO3 = collision.GetComponent<enemy_blood>();
             print("碰到的東西是:" + collision);
            kgGO3.EnemyHealth(-10);
            Destroy(gameObject);
        }
    }
}
