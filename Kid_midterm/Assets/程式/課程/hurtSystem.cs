using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class hurtSystem : MonoBehaviour
{
    [Header("血條")]
    public Image imgHpBar;
    [Header("血量")]
    public float hp = 100;
    [Header("動畫參數")]
    public string die = "觸發死亡";
    [Header("死亡事件")]
    public UnityEvent onDead;

    private float hpMax;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hpMax = hp;
    }
    public void Hurt(float damage)
    {
        hp -= damage;
        imgHpBar.fillAmount = hp / hpMax;
        if (hp <= 0) Die();
    }

    private void Die()
    {
        anim.SetTrigger(die);
        onDead.Invoke();
    }
}
