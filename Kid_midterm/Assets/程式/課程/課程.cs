using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 課程 : MonoBehaviour
{
    #region 欄位:公開
    [Header("移動速度"), Range(0, 500)]
    public float speed = 10.0f;
    [Header("跳躍高度"), Range(0, 1500)]
    public float jump = 300;
    [Header("檢查地板尺寸與位移"), Range(0, 1)]
    public float checkGroundRadius = 0.1f;
    public Vector3 checkGroundOffset;
    [Header("跳躍按鍵與可跳躍圖層")]
    public KeyCode keyjump = KeyCode.Space;
    public LayerMask canJumpLayer;
    public string parameterWalk = "角色走路";
    public string parameterJump = "角色跳躍";
    public bool isAttack = false;
    public GameObject projectilePrefab;
    [Header("檢查攻擊區域大小與位移")]
    public Vector3 v3AttackSize = Vector3.one;
    public Vector3 v3AttackOffset;
    #endregion

    #region 欄位:私人
    private Rigidbody2D rb2D;
    private Animator anim;
    [SerializeField]
    private bool IsGround;
    [SerializeField]
    private int jumpCount;
    [SerializeField]
    private bool jumpPress;
    #endregion

    #region 事件
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 20, 0.5f);
        Gizmos.DrawSphere(transform.position + transform.TransformDirection(checkGroundOffset), checkGroundRadius);
        Gizmos.color = new Color(0, 1, 20, 0.5f);
        Gizmos.DrawCube(transform.position + transform.TransformDirection(v3AttackOffset), v3AttackSize);
    }

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpCount = 0;
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Flip();
        CheckGround();
        Jump();
        Attack();
        rush();
    }
    #endregion

    #region 方法
    public void Move()
    {
        float M = Input.GetAxis("Horizontal");
        //print("玩家左右按鍵值:" + M);

        rb2D.velocity = new Vector2(M * speed, rb2D.velocity.y);

        anim.SetBool(parameterWalk, M != 0);
    }
    private void Flip()
    {
        float M = Input.GetAxis("Horizontal");

        if (M < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (M > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    private void CheckGround()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position + transform.TransformDirection(checkGroundOffset), checkGroundRadius, canJumpLayer);
        //print("碰到的物件:" + hit.name);
        IsGround = hit;

        anim.SetBool(parameterJump, !IsGround);
    }

    private void Jump()
    {

        if (IsGround)
        {
            if (Input.GetKeyDown(keyjump))
            {
                rb2D.AddForce(new Vector2(0, jump));
                jumpCount = jumpCount + 1;
                jumpPress = true;
            }
        }
        else if (jumpPress == true && jumpCount != 0)
        {
            if (Input.GetKeyDown(keyjump) && jumpCount == 1)
            {
                rb2D.AddForce(new Vector2(0, jump));
                jumpCount = jumpCount + 1;
                jumpPress = true;
            }

            if (Input.GetKeyDown(keyjump) && jumpCount == 2)
            {
                jumpPress = false;
                jumpCount = 0;
            }
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            isAttack = true;
            //print("gg");
            GameObject projectileOnject = Instantiate(projectilePrefab,
      rb2D.position, Quaternion.identity);
            anim.SetBool("遠程攻擊", true);

            // 在 Bullet.cs 中 我們設置了一個 Launch() 方法 並透過 受力的方法 來移動
            // 所以這邊需要為此設立一個 Bullet 型態的變量 作為乘載此力的施壓容器
            Bullet bullet = projectileOnject.GetComponent<Bullet>();

            // 上面接收完畢後 便可透過自帶的 Launch() 方法來實現 受力的方法
            // 我們在 Bullet.cs 中定義的 Launch() 方法需要給兩個參數:方向&力道
            bullet.Launch(Vector2.right, 300);  // 300 數值越大 速度越快
            float k = GetComponent<Transform>().rotation.y;
            if (k < 0)
            {
                bullet.Launch(transform.TransformDirection(v3AttackOffset), 300);
            }
        }
        else
        {
            isAttack = false;
            anim.SetBool("遠程攻擊", false);
        }
    }
    void rush()
    {
        if (Input.GetKey(KeyCode.I))
        {
            anim.SetBool("開關衝刺", true);
            anim.SetBool("角色走路", false);
            speed = 15;
         }
        else
        {
            speed = 10.0f;
            anim.SetBool("開關衝刺", false);
        }
    }
    
    #endregion
}
