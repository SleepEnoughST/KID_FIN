using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class egg_rain : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private bool isup = true;
    public float x_left;
    public float x_right;
    public GameObject a;

    public float t1;    
    private float t2;   

    private void Start()
    {
        t2 = t1;        
      rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();

    }
    private void Update()
    {
        t2 = t2 - Time.deltaTime;      

        if (t2 <= 0)
        {
            Instantiate(a, transform.position, Quaternion.identity);
            t2 = t1;                                       

        }

        Movement();
    }
    void Movement()
    {
        if (isup)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > x_right)
            {
                isup = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < x_left)
            {
                isup = true;
            }
        }
    }
}
