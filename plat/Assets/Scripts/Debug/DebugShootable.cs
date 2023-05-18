using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using Toon.Extend;

namespace Toon.Test
{
    public class DebugShootable : MonoBehaviour
    {
        [SerializeField]
        GameObject muzzle;
        Guns gun;
        [SerializeField]
        Text tt;

        void Start()
        {
            gun = muzzle.GetComponent<Guns>();
        }

        void Update()
        {
            tt.text =
                "shootable: " + gun.shootable.indent() +
                "first shot: " + gun.FirstShot.indent() +
                "rapid: " + gun.Rapid.indent();
            tt.color = Color.white;
        }
    }
}
