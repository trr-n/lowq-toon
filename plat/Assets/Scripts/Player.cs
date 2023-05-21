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

        bool dead = false;

        void Start()
        {
            init();
            playerHp.SetMax();

            onDead?.AddListener(Radish);
        }

        void Update()
        {
            manager.Controllable.show();
            Die();
        }

        void Die()
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
            if (info.gameObject.CompareTag(constant.Missile))
            {
                playerHp.Damage(25);
            }
        }

        void init()
        {
            playerHp ??= GetComponent<HP>();
            manager ??= GameObject.FindGameObjectWithTag(constant.Manager).GetComponent<Manager>();
            collider ??= GetComponent<CapsuleCollider>();
            rigidbody ??= GetComponent<Rigidbody>();

            manager.Controllable = true;
            collider.isTrigger = false;
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
        }
    }
}
