using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon.Test
{
    public class ActionFuncTest : MonoBehaviour
    {
        // 戻り値がある関数には使えない
        public event Action OnCompleted;

        // 引数が必要なメソッドなら
        // event Action<int, float> hoge;

        // 戻り値があればFunc
        // ジェネリックの最後に指定した型が戻り値の型になる
        // public event Func<int> hogeh;
        // public event Func<float, float> hogehoge;

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
}
