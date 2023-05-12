using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toon.Debug
{
    public class DebugBGMVolume : MonoBehaviour
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
            t.text = spk.Volume.ToString();
        }
    }
}
