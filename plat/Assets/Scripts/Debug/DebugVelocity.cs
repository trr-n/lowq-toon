using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using Toon.Extend;

namespace Toon.Debug
{
    public class DebugVelocity : MonoBehaviour
    {
        [SerializeField] Text t;
        [SerializeField] GameObject player;
        ThirdPersonCharacter tpc;

        void Start()
        {
            tpc = player.GetComponent<ThirdPersonCharacter>();
        }

        void Update()
        {
            // t.text = "x: " + MathF.Round(tpc.Rigidbody.velocity.x, 1) + "\r\ny: " + MathF.Round(tpc.Rigidbody.velocity.z, 1);
            t.text = "x: " + MathF.Round(tpc.Rigidbody.velocity.x, 1).indent() + "y: " + MathF.Round(tpc.Rigidbody.velocity.z, 1);
            t.color = Color.white;
        }
    }
}
