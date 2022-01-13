using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    //だ计把计

    public static int Sc;

    //ゅUI

    public Text ShowScore;

    void Update()

    {

        //琵UIゅ籔だ计˙

        ShowScore.text = Sc.ToString("0");

    }
}
