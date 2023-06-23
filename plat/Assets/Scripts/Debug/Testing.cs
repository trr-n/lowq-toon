using UnityEngine;
using Toon.Extend;
using System.Collections;

namespace Toon.Test
{
    public class Testing : MonoBehaviour
    {
        Vector3 move2 = new(1, 1, 1);
        void Update()
        {
            transform.move2d(10);
        }
    }
}