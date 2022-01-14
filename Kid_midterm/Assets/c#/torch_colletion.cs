using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class torch_colletion : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            score.Sc = score.Sc + 1;
            this.GetComponent<Collider2D>().enabled = false;
        }
    }

}