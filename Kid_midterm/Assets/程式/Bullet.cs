using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator Ani;
    public float bulletDis;

    //�i�����S�� 1/2�j
    public ParticleSystem hitEffect;

    // ���ϥ� ��Ҥƥͦ��禡 Instantiate() �N�ݭn�ϥ� Awake()
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

    // �]�wLaunch(�����O����V���O���j�p)
    public void Launch(Vector2 direction, float force)
    {
        rb.AddForce(direction * force);
        float k = GetComponent<Transform>().rotation.y;
        if (k < 0)
        {
            rb.AddForce(-direction * force);
        }
    }

    // �l�u���I���˴�
    private void OnCollisionEnter2D(Collision2D collision)
    {
       


        //�i�Ϫ������ 1/1�j
        Destroy(gameObject); //�l�u����
        //Destroy(collision.gameObject); //�I���쪺�������
    }

    //�i�������ؼЪ��l�u�۰ʾP�� 1/1�j�H�Z���ӭp��
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
             print("�I�쪺�F��O:" + collision);
            kgGO3.EnemyHealth(-10);
            Destroy(gameObject);
        }
    }
}
