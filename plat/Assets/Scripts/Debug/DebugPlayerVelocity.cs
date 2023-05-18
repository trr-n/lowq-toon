using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toon.Test
{
    public class DebugPlayerVelocity : MonoBehaviour
    {
        [SerializeField]
        Text t;
        GameObject player;
        [SerializeField]
        PlayerMovement pm;
        void Start()
        {
            pm = player.GetComponent<PlayerMovement>();
        }

        void Update()
        {
            t.text = pm.Velocity.ToString();
        }
    }
}
