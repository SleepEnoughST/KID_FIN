using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    //宣告分數參數

    public static int Sc;

    //宣告文字UI

    public Text ShowScore;

    void Update()

    {

        //讓UI文字與分數同步

        ShowScore.text = Sc.ToString("0");

    }
}
