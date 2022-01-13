using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_blood : MonoBehaviour
{
    public Slider slider;
    public int hp = 250;
    public int hpHolder;
    public RectTransform e_HealthBar, e_Hurt;
    private Rigidbody2D rig;
    
    // Start is called before the first frame update
    void Start()
    {
        hpHolder = hp;
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //將綠色血條同步到當前血量長度

        e_HealthBar.sizeDelta = new Vector2(hpHolder, e_HealthBar.sizeDelta.y);




    }
    public void EnemyHealth(int amount)
    {
        hpHolder = hpHolder + amount;  // 加血機制-1
                                       //currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); //加血機制-2 改良版

        if (hpHolder <= 0)
        {
            Destroy(gameObject);
            
        }
    }
}
