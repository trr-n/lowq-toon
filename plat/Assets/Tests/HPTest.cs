using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon.Test
{
    public class HPTest : MonoBehaviour
    {
        HP hp;

        void Start()
        {
            hp = GetComponent<HP>();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                hp.Add(1);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                hp.Add(-1);
            }
        }
    }
}
