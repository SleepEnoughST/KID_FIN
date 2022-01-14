using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class short_attack : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator ani;

    [Header("攻擊距離"), Range(0, 5)]
    public float attackDistaance = 1.3f;
    [Header("檢查攻擊區域大小與位移")]
    public Vector3 v3AttackSize = Vector3.one;
    public Vector3 v3AttackOffset;
    [Header("攻擊力"), Range(0, 100)]
    public float attack = 35;
    private float angle = 0;
    private float timerAttack;
    public LayerMask enemylayer;
    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Attack();

        }

    }
    public void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    Attack();

        //}
    }
    private void Attack()
    {
        ani.SetTrigger("開關攻擊");
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize, 0, enemylayer);
        //print("攻擊到物件:" + hit.name);
        if (hit != null)
        {
        hit.GetComponent<enemy_blood>().EnemyHealth(-50);
        }
    }
}
