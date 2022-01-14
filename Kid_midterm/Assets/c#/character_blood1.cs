using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.Events;

public class character_blood1 : MonoBehaviour
{
    public const int maxHealth = 100;
    [Header("��e��q"), Range(0, 100)]
    public float currentHealth;
    private bool hurt = false;
    //��q��

    public RectTransform HealthBar, Hurt;
    [SerializeField] GameObject dieWindow = null;
    public UnityEvent onDead;
    private Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
        //dieWindow.SetActive(false);
        currentHealth = maxHealth;
    }

    void Update()

    {
        if (Input.GetKeyDown(KeyCode.L) && currentHealth > 1 && currentHealth < 100)
        {
            Recover();
        }
        if (currentHealth < 100 && hurt == false)
        {
            currentHealth = currentHealth += 0.002f;
        }

        //�N������P�B���e��q����

        HealthBar.sizeDelta = new Vector2(currentHealth, HealthBar.sizeDelta.y);

        //�e�{�ˮ`�q

        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)

        {

            //���ˮ`�q(������)�v���l�W��e��q

            Hurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 10;

        }
        if (Hurt.sizeDelta.x < HealthBar.sizeDelta.x)

        {

            //���ˮ`�q(������)�v���l�W��e��q

            Hurt.sizeDelta += new Vector2(3, 0) * Time.deltaTime * 10;

        }
    }
    public void ChangeHealth(int amount)
    {
        //currentHealth = currentHealth + amount;  // �[�����-1
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); //�[�����-2 ��}��
        print("Ruby ��e��q��:" + currentHealth);

        // �i�P�_�O�_���ˡj
        if (currentHealth <= 0)
        {
           
            //Thread.Sleep(2);
            //Destroy(gameObject, 1.8f);
            Die();
            hurt = true;
            score.Sc = 0;
        }
        if (amount <= -1 && currentHealth > 1)
        {
            ani.SetTrigger("����");
        }

    }
    private void Die()
    {
        ani.SetTrigger("Ĳ�o���`");
        onDead.Invoke();
    }
    void Recover()
    {
        currentHealth = currentHealth += 2f;
        ani.SetTrigger("�}���^��");
    }
}
