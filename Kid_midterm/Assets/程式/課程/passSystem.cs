using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class passSystem : MonoBehaviour
{
   
    public UnityEvent onPass;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "小紅帽") onPass.Invoke();
        print("進來了" + collision.name);
    }
}
