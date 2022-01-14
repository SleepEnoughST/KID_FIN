using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class passSystem : MonoBehaviour
{
    private int score1;
    public UnityEvent onPass;
    private void Update()
    {
        score1 = score.Sc;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "小紅帽")
        {
            if (score1 == 15)
            {
            onPass.Invoke();

            }
        } 
       // print("進來了" + collision.name);
    }
}
