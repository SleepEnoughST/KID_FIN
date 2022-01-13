using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dorr_open : MonoBehaviour
{
    private Rigidbody2D rig;
    private bool isup = true;
    public float speed;
    public float y_down;
    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        transform.DetachChildren();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            // print("你進來了" + collision);
            // Destroy(gameObject, 1.0f);
            //transform.Translate(Vector2.down * Time.deltaTime * 1);

            //open = true;
            rig.velocity = new Vector2(rig.velocity.x, -speed);
            if (transform.position.y > y_down)
            {
                isup = false;
            }
            else
            {
                Destroy(gameObject);

            }
        }
    }
}
