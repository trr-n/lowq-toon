using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Teleporter : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("屋上の生成座標")]
        Vector3 spawnPosOnRoof;

        [SerializeField]
        Manager manager;

        void OnCollisionEnter(Collision info)
        {
            if (info.compare(constant.Player))
            {
                info.gameObject.transform.position = spawnPosOnRoof;
                manager.TimerStart = true;
            }
        }
    }
}
