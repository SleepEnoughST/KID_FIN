using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.Events;

public class character_blood1 : MonoBehaviour
{
    public const int maxHealth = 100;
    [Header("當前血量"), Range(0, 100)]
    public float currentHealth;
    private bool hurt = false;
    //血量條

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

        //將綠色血條同步到當前血量長度

        HealthBar.sizeDelta = new Vector2(currentHealth, HealthBar.sizeDelta.y);

        //呈現傷害量

        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)

        {

            //讓傷害量(紅色血條)逐漸追上當前血量

            Hurt.sizeDelta += new Vector2(-1, 0) * Time.deltaTime * 10;

        }
        if (Hurt.sizeDelta.x < HealthBar.sizeDelta.x)

        {

            //讓傷害量(紅色血條)逐漸追上當前血量

            Hurt.sizeDelta += new Vector2(3, 0) * Time.deltaTime * 10;

        }
    }
    public void ChangeHealth(int amount)
    {
        //currentHealth = currentHealth + amount;  // 加血機制-1
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); //加血機制-2 改良版
        print("Ruby 當前血量為:" + currentHealth);

        // 【判斷是否受傷】
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
            ani.SetTrigger("受傷");
        }

    }
    private void Die()
    {
        ani.SetTrigger("觸發死亡");
        onDead.Invoke();
    }
    void Recover()
    {
        currentHealth = currentHealth += 2f;
        ani.SetTrigger("開關回血");
    }
}
