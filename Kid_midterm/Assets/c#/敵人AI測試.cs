using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 敵人AI測試 : MonoBehaviour
{
    public float WalkSpeed;
    [HideInInspector]
    public bool mustPatrol;

    private bool mustTurn;
    public Rigidbody2D rb;
    public Transform GroundCheckPos;
    public LayerMask GroundLayer;
    public Collider2D bodyCollider;

    public static bool isAttacking = false;
    public Animator anim;


    void Start()
    {
        mustPatrol = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

        if (isAttacking)
            anim.SetBool("觸發攻擊", true);
        else
            anim.SetBool("觸發攻擊", false);
    }
    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(GroundCheckPos.position, 0.1f, GroundLayer);
        }
    }

    void Patrol()
    {
        if(mustTurn || bodyCollider.IsTouchingLayers(GroundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(WalkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        WalkSpeed *= -1;
        mustPatrol = true;
    }
}
