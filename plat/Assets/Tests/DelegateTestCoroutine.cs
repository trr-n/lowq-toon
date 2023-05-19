using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTestCoroutine : MonoBehaviour
{
    public delegate void PrintMethod();

    // eventをつけると追加と削除しかできなくなる、内部からしか実行できない
    public event PrintMethod OnCompleted;

    public void Exec(float wait)
    {
        StartCoroutine(TestCoroutine(wait));
    }

    IEnumerator TestCoroutine(float wait)
    {
        yield return new WaitForSeconds(wait);
        OnCompleted();
    }
}
