using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class hurtSystem : MonoBehaviour
{
    [Header("���")]
    public Image imgHpBar;
    [Header("��q")]
    public float hp = 100;
    [Header("�ʵe�Ѽ�")]
    public string die = "Ĳ�o���`";
    [Header("���`�ƥ�")]
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
