using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class GenTest : MonoBehaviour
    {
        [SerializeField] GameObject[] gameObjects;

        void Start()
        {
            StartCoroutine(generate());
        }

        IEnumerator generate()
        {
            while (true)
            {
                gameObjects.instance(transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
