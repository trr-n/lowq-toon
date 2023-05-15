using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Canon : MonoBehaviour
    {
        GameObject player;
        readonly Vector3 towerPosition = new(8.731677f, 3.177724f, -7.152449f);

        void Start()
        {
            player = GameObject.FindGameObjectWithTag(constant.Player);
            transform.set(towerPosition);
        }

        void Update()
        {
            LookingAtPlayer();
        }

        void LookingAtPlayer()
        {
            transform.rotation = Quaternion.LookRotation(new(
                transform.rotation.x,
                transform.position.y - player.transform.position.y,
                transform.rotation.z
            ));
        }
    }
}
