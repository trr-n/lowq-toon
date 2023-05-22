using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Canon : MonoBehaviour
    {
        [SerializeField]
        GameObject[] canons;
        [SerializeField]
        GameObject player;

        [SerializeField, Tooltip("弾速")]
        float speed;
        public float Speed => speed;

        /// <summary>砲口が見る方向</summary>
        Vector3 muzzleLookAtPosition = new(0, 1, 0);
        /// <summary>プレイヤーの向き?</summary>
        Vector3 direction;

        Transform towerTransform;
        Transform self;

        bool isHaving;
        float rapid = 1;
        float distance;
        public float Distance => distance;
        float power = 0;
        public float Power => power;

        void Start()
        {
            StartCoroutine(Trigger());
        }

        void Update()
        {
            self = this.transform;
            direction = transform.position - player.transform.position;
            VerticalRotation();
        }

        void VerticalRotation()
        {
            // プレイヤーの座標.y + 1.0f (腰のあたり)を見続ける
            self.LookAt(player.transform.position + muzzleLookAtPosition);

            // test ray
            // Debug.DrawRay(transform.position, -direction);
        }

        IEnumerator Trigger(bool canonFire = true)
        {
            while (canonFire)
            {
                Fire();
                yield return new WaitForSeconds(rapid);
            }
        }

        void Fire()
        {
            var canon = canons.ins(transform.position, Quaternion.identity);
            var canonRb = canon.GetComponent<Rigidbody>();
            canonRb.AddForce(transform.forward * speed, ForceMode.Impulse);
        }
    }
}
