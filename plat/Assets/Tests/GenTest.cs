using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon.Test
{
    public class GenTest : MonoBehaviour
    {
        [SerializeField] GameObject tests;

        void Start()
        {
            StartCoroutine(generate());
        }

        IEnumerator generate()
        {
            while (true)
            {
                GameObject test = tests.ins(transform.position, Quaternion.identity);
                test.GetComponent<Rigidbody>()
                    .AddForce(Vector3.forward * 10, ForceMode.Impulse);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
