using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGateway : MonoBehaviour
{
    //public enum KindofGate
    //{
    //    Gate1,
    //    Gate2,
    //    Gate3,
    //    Gate4
    //}

    //public KindofGate kindofGate;
    //public bool CanCheckAnother;

    //private void Start()
    //{

    //    CanCheckAnother = true;

    //    GameManager.RegistPortalGateway(this);

    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 8)
    //    {

    //        if (CanCheckAnother == true)
    //        {

    //            if (GameManager.FindSameGate(this).CanCheckAnother == true)
    //            {
    //                collision.transform.position = GameManager.FindSameGate(this).transform.position;
    //                CanCheckAnother = false;
    //            }
    //        }

    //    }




    //}


    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 8)
    //        GameManager.FindSameGate(this).CanCheckAnother = true;
    //}
}
