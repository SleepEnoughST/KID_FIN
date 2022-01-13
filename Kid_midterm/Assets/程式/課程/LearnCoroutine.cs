using UnityEngine;
using System.Collections;

public class LearnCoroutine : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Test());
        StartCoroutine(TestWithLoop());
    }

    private IEnumerator Test()
    {
        yield return new WaitForSeconds(1);
        print("�o�O�Ĥ@�q��r�T��");
        yield return new WaitForSeconds(2);
        print("�o�O�ĤG�q��r�T��");
        yield return new WaitForSeconds(3);
        print("�o�O�ĤT�q��r�T��");
    }


    private IEnumerator TestWithLoop()
    {
        for (int i = 0; i < 10; i++)
        {
            print("�Ʀr:" + i);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
