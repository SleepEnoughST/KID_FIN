using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{
    //�ŧi���ưѼ�

    public static int Sc;

    //�ŧi��rUI

    public Text ShowScore;

    void Update()

    {

        //��UI��r�P���ƦP�B

        ShowScore.text = Sc.ToString("0");

    }
}
