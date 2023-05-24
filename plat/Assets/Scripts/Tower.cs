using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Tower : MonoBehaviour
    {
        [SerializeField]
        GameObject player;

        [SerializeField]
        HP hp;

        [SerializeField]
        int damage;

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
            Vector3 direction =
                new Vector3(transform.position.x, 0, transform.position.z) -
                new Vector3(player.transform.position.x, 0, player.transform.position.z);
            transform.rotation = Quaternion.LookRotation(-direction, Vector3.up);
        }

        void OnCollisionEnter(Collision info)
        {
            if (info.gameObject.CompareTag(constant.Missile))
            {
                "tower hit".show();
                hp.Damage(damage);
            }
        }
    }
}
