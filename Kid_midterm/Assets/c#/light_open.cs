using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_open : MonoBehaviour
{
    public GameObject light1;
    // Start is called before the first frame update
    void Start()
    {
        light1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            light1.SetActive(true);
        }

    }
}
