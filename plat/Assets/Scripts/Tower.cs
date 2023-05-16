using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] GameObject player;
        // [SerializeField]
        public static Vector3 ofs1 = new(1.7f, 0f, 0f);

        readonly Vector3 TowerPosition = new(8.731677f, 3.177724f, -7.152449f);

        void Update()
        {
            LookingAtPlayer();
        }

        void ClampingMe()
        {
            Quaternion rotation = transform.rotation;
            rotation.y = numeric.clamp(rotation.y, 225, 283);
            transform.rotation = rotation;

            transform.position = TowerPosition;
        }

        void LookingAtPlayer()
        {
            // init diff x: 17.98, y: 2.65, z: -1.63
            // 上下は発砲時の力で調節するからY座標は無視
            Vector3 direction =
                new Vector3(transform.position.x, 0, transform.position.z) -
                new Vector3(player.transform.position.x, 0, player.transform.position.z);
            Quaternion lookAt = Quaternion.LookRotation(-direction, Vector3.up);
            Quaternion offset = Quaternion.FromToRotation(Vector3.forward + ofs1, Vector3.forward);
            transform.rotation = lookAt * offset;
        }
    }
}
