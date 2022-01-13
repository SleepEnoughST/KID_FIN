using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 敵人 : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private CircleCollider2D CircleCollider;
    [SerializeField] private LayerMask PlayerLayer;

    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("觸發攻擊");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(CircleCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,new Vector3(CircleCollider.bounds.size.x * range, CircleCollider.bounds.size.y, CircleCollider.bounds.size.z), 0, Vector2.left, 0, PlayerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(CircleCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(CircleCollider.bounds.size.x * range, CircleCollider.bounds.size.y, CircleCollider.bounds.size.z));
    }
}