using Toon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toon.Test
{
    public class DebugIsFloating : MonoBehaviour
    {
        [SerializeField]
        GameObject player;
        PlayerMovement pm;
        [SerializeField]
        Text t;

        private void Start()
        {
            pm = player.GetComponent<PlayerMovement>();
        }

        void Update()
        {
            t.text = pm.IsFloating.ToString();
        }
    }
}
