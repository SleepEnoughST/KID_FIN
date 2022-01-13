using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 角色 : MonoBehaviour
{
    public float MovementSpeed = 10;
    public float JumpForce = 15;
    public Animator animator;
    public Animator anim;
    public Rigidbody2D rb;
    public bool isAttack;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isAttack = false;
    }


    public void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, -180, 0) : Quaternion.identity;

        animator.SetFloat("走路", Mathf.Abs(movement));



        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("跳躍", true);
        }
        if (rb.velocity.y == 0)
        {
            anim.SetBool("跳躍", false);
        }
        if (rb.velocity.y > 0)
        {
            anim.SetBool("跳躍", true);
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("跳躍", true);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            isAttack = true;
            if (isAttack)
            {
            Attack();

            }
        }
    }
    
    public void Attack()
    {
        
            print("觸發");
        
    }

}
