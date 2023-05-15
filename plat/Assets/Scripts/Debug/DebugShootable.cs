using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Toon.Debug
{
    public class DebugShootable : MonoBehaviour
    {
        [SerializeField]
        GameObject player;
        ThirdPersonCharacter tpc;
        [SerializeField]
        Text tt;

        void Start()
        {
            tpc = player.GetComponent<ThirdPersonCharacter>();
        }

        void Update()
        {
            tt.text = $"crab?: {tpc.WalkWhileShooting}";
            tt.color = Color.white;
        }
    }
}
