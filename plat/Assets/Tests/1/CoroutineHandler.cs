using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon.Extend
{
    public class CoroutineHandler : MonoBehaviour
    {
        public void Exec(IEnumerator method)
        {
            StartCoroutine(Do(method));
        }

        IEnumerator Do(IEnumerator method)
        {
            while (method.MoveNext())
            {
                yield return null;
            }
            Destroy(this);
        }
    }
}
