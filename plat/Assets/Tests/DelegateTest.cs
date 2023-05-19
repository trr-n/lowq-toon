using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTest : MonoBehaviour
{
    public void HelloWorld()
    {
        Debug.Log("Hello World");
    }

    public void TodaysWeather()
    {
        Debug.Log("今日は雨です");
    }

    delegate void PrintMethod();

    PrintMethod testMethod;

    void Start()
    {
        HelloWorld();

        // 関数を入れられる
        // testMethod = HelloWorld;
        // testMethod += HelloWorld;
        // testMethod += TodaysWeather;
        // testMethod();

        // StartCoroutine(TestCoroutine(5, testMethod));

        DelegateTestCoroutine other = GetComponent<DelegateTestCoroutine>();
        other.OnCompleted += HelloWorld;
        other.OnCompleted += TodaysWeather;
        // other.OnCompleted(); //? event をつけると外部からは実行できない
        other.Exec(10);

        // Actionのテスト
        Toon.Test.ActionFuncTest other2 = GetComponent<Toon.Test.ActionFuncTest>();
        other2.OnCompleted += HelloWorld;
        other2.OnCompleted += TodaysWeather;
        // other.OnCompleted(); //? event をつけると外部からは実行できない
        other2.Exec(10);

        // UnityEventのテスト
        Toon.Test.UnityEventTest other3 = GetComponent<Toon.Test.UnityEventTest>();
        other3.Exec(10);
    }

    IEnumerator TestCoroutine(float wait, PrintMethod method)
    {
        yield return new WaitForSeconds(wait);
        method();
    }
}
