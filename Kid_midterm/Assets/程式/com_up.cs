using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class com_up : MonoBehaviour
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
        //open = GetComponent<kg_enemy_blood>().doorDown;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("�A�i�ӤF" + collision);
            // Destroy(gameObject, 1.0f);
            //transform.Translate(Vector2.down * Time.deltaTime * 1);

            //open = true;
            rig.velocity = new Vector2(rig.velocity.x, speed);
            if (transform.position.y > y_down)
            {
                isup = false;
            }
           
        }
    }
}
