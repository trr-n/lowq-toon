using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toon.Test
{
    public class DebugVolumeControl : MonoBehaviour
    {
        [SerializeField]
        Text t;
        [SerializeField]
        GameObject speaker;
        Speaker spk;

        void Start()
        {
            spk = speaker.GetComponent<Speaker>();
        }

        void Update()
        {
            t.text = spk.InputV.ToString();
        }
    }
}
