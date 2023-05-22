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
                "shootable: " + gun.Shootable.newline() +
                "first shot: " + gun.FirstShot.newline() +
                "rapid: " + gun.Rapid.newline();
            tt.color = Color.white;
        }
    }
}
