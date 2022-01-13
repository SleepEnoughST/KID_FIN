using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ene_3 : MonoBehaviour
{
    #region 欄位
    [Header("檢查追蹤區域大小與位移")]
    public Vector3 v3TrackSize = Vector3.one;
    public Vector3 v3TrackOffset;
    [Header("移動速度")]
    public float speed = 1.5f;
    [Header("目標圖層")]
    public LayerMask layerTarget;
    [Header("動畫參數")]
    public string enemyWalk = "開關走路";
    public string enemyAttack = "觸發攻擊";
    [Header("面向目標物件")]
    public Transform target;
    [Header("攻擊距離"), Range(0, 10)]
    public float attackDistance = 1.5f;
    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float attackCD = 2.8f;
    [Header("檢查攻擊區域大小與位移")]
    public Vector3 v3AttackSize = Vector3.one;
    public Vector3 v3AttackIOffset;

    private float angle = 0;
    private Rigidbody2D rb;
    private Animator anim;
   
    public GameObject a;
    public float t1;
    [SerializeField]
    private float t2;
    #endregion

    #region 事件
    private void Start()
    {
        t2 = t1;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnDrawGizmos()
    {
        //指定圖示的顏色
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        //繪製立方體(中心，尺寸)
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize);

        Gizmos.color = new Color(0, 1, 0, 0.3f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3AttackIOffset), v3AttackSize);
    }

    private void Update()
    {
        CheckTargetInArea();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 檢查目標是否在區域內
    /// </summary>
    private void CheckTargetInArea()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.TransformDirection(v3TrackOffset), v3TrackSize, 0, layerTarget);

        if (hit)
        {
            Move();
        }
        else
        {
            anim.SetBool(enemyWalk, false);
        }
    }
    private void Move()
    {
        //如果 目標的 X 小於 敵人的 X 就代表在左邊 角度 0
        //如果 目標的 X 大於 敵人的 X 就代表在右邊 角度 180
        if (target.position.x > transform.position.x)
        {
            // 右邊 angle = 180
        }
        else if (target.position.x < transform.position.x)
        {
            // 左邊 angle = 0
        }

        //三元運算子語法：布林值 ? (當布林值 為 true) : (當布林值 為 false) ;
        angle = target.position.x > transform.position.x ? 180 : 0;

        transform.eulerAngles = Vector3.up * angle;

        rb.velocity = transform.TransformDirection(new Vector2(-speed, rb.velocity.y));
        anim.SetBool(enemyWalk, true);

        float distance = Vector3.Distance(target.position, transform.position);
        //print(distance);

        if (distance <= attackDistance)
        {
            rb.velocity = Vector3.zero;
            Attack();
            anim.SetBool("開關走路", false);
        }
        else
        {
            t2 = t1;
        }
    }


    private void Attack()
    {
        t2 = t2 - Time.deltaTime;
        if (t2 <= 0)
        {
            anim.SetTrigger(enemyAttack);
            GameObject projectileOnject = Instantiate(a, rb.position, Quaternion.identity);
            enemy_bullet bullet = projectileOnject.GetComponent<enemy_bullet>();
            float k = GetComponent<Transform>().rotation.y;
            if (k < 0)
            {
                bullet.Launch(transform.TransformDirection(v3AttackIOffset), 300);
            }
            t2 = t1;
        }
       
    }
    #endregion
}
