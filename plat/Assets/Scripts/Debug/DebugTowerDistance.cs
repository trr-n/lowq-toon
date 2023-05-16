using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon.Debug
{
    public class DebugTowerDistance : MonoBehaviour
    {
        [SerializeField] GameObject point;
        [SerializeField] Text tt;

        Canon canon;

        void Start()
        {
            canon = point.GetComponent<Canon>();
        }

        void Update()
        {
            tt.text = canon.ChangeFirePower().ToString();
            tt.color = Color.white;
        }
    }
}
