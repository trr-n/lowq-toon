using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon.Test
{
    public class ExtendTest : MonoBehaviour
    {
        public List<int> i;

        void Start()
        {
            i ??= null;
            for (int j = 1; j <= 100; j++)
                i.Add(j);
            i[i.Capacity.max()].show();
        }
    }
}
