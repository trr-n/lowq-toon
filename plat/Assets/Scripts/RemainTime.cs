using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon
{
    public class RemainTime : MonoBehaviour
    {
        [SerializeField]
        Text tt;
        [SerializeField]
        GameObject manager;
        Manager m;

        void Start()
        {
            m = manager.GetComponent<Manager>();
        }

        void Update()
        {
            tt.text = "REMAINING TIME".newline() + m.Remaining;
        }
    }
}
