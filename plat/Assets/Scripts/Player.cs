using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        GameObject panel;

        [SerializeField]
        HP playerHp;

        [SerializeField]
        Manager manager;

        [SerializeField]
        UnityEvent onDead;

        [SerializeField]
        new Rigidbody rigidbody;

        [SerializeField]
        new CapsuleCollider collider;

        [SerializeField]
        Vector3 spawnPosOnRoof;

        [SerializeField]
        int bulletDamage = 25;

        void Start()
        {
            init();
            playerHp.SetMax();
        }

        void Update()
        {
            if (!playerHp.IsZero())
            {
                return;
            }
            "onDead".show();
            onDead.Invoke();
        }

        public void Radish()
        {
            manager.Controllable = false;
            collider.isTrigger = true;
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }

        void OnCollisionEnter(Collision info)
        {
            if (info.gameObject.CompareTag(constant.Bullet))
            {
                playerHp.Damage(bulletDamage);
            }
        }

        void OnTriggerEnter(Collider info)
        {
            if (info.compare(constant.Portal))
            {
                "into portal".show();
                transform.position = spawnPosOnRoof;
                manager.TimerStart = true;
            }
        }

        void init()
        {
            playerHp ??= GetComponent<HP>();
            manager ??= gobject.find(constant.Manager).GetComponent<Manager>();
            collider ??= GetComponent<CapsuleCollider>();
            rigidbody ??= GetComponent<Rigidbody>();

            manager.Controllable = true;
            collider.isTrigger = false;
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;

            onDead?.AddListener(Radish);
            onDead?.AddListener(manager.Failing);
        }
    }
}
