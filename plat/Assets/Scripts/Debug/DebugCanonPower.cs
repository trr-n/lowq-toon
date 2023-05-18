using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toon.Test
{
    public class DebugCanonPower : MonoBehaviour
    {
        [SerializeField] Text tt;
        [SerializeField] GameObject tower;
        Canon canon;

        void Start()
        {
            canon = tower.GetComponent<Canon>();
        }

        void Update()
        {
            tt.text = canon.Power.ToString();
            tt.color = Color.white;
        }
    }
}
