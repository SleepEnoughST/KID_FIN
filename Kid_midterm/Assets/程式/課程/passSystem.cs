using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class passSystem : MonoBehaviour
{
   
    public UnityEvent onPass;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "�p���U") onPass.Invoke();
        print("�i�ӤF" + collision.name);
    }
}
