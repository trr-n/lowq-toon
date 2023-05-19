using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Toon.Test
{
    public class UnityEventTest : MonoBehaviour
    {
        [SerializeField] UnityEvent OnCompleted;

        public void Exec(float wait)
        {
            StartCoroutine(TestCoroutine(wait));
        }

        IEnumerator TestCoroutine(float wait)
        {
            yield return new WaitForSeconds(wait);

            // 関数のようには呼び出せない
            OnCompleted.Invoke();
        }

    }
}
