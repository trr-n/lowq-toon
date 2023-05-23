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

        [SerializeField]
        [Tooltip("弾速")]
        float speed;
        public float Speed => speed;

        [SerializeField]
        Manager manager;

        Vector3 muzzleLookAtPosition = new(0, 1, 0);
        Vector3 direction;
        Transform towerTransform;
        Transform self;

        float rapid = 1;
        float timer = 0;

        void Start()
        {
            // StartCoroutine(Trigger(manager.TimerStart));
        }

        void Update()
        {
            self = this.transform;
            direction = transform.position - player.transform.position;
            VerticalRotation();
            Trigger2(manager.TimerStart);
        }

        void VerticalRotation()
        {
            // プレイヤーの座標.y + 1.0f (腰のあたり)を見続ける
            self.LookAt(player.transform.position + muzzleLookAtPosition);
        }

        IEnumerator Trigger(bool canonFire)
        {
            while (canonFire)
            {
                Fire();
                yield return new WaitForSeconds(rapid);
            }
        }

        void Trigger2(bool timerStart)
        {
            timer += Time.deltaTime;
            ("canon timer: " + timer).show();
            while (timerStart && timer >= rapid)
            {
                Fire();
                timer = 0;
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
