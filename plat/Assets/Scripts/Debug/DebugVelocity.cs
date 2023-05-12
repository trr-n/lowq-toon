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
            float x = MathF.Round(tpc.Rigidbody.velocity.x, 1), z = MathF.Round(tpc.Rigidbody.velocity.z, 1);
            t.text = @$"x: {x}
y: {z}";
            t.color = new Color(1, 1, 1);
        }
    }
}
