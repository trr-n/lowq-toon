using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon.Test
{
    public class GenTest : MonoBehaviour
    {
        [SerializeField]
        GameObject tests;

        new Rigidbody rigidbody;

        void Start()
        {
            // StartCoroutine(generate());
            rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            float h = Input.GetAxis(constant.Horizontal), v = Input.GetAxis(constant.Vertical);
            var hv = h * Vector3.right + v * Vector3.forward;
            rigidbody.velocity = hv * 10;
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
