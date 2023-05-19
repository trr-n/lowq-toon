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
        HP hp;

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
            nullcheck();
            hp.SetMax();

            onDead?.AddListener(Radish);
            onDead?.AddListener(manager.Fading);
        }

        void Update()
        {
            Die();
        }

        void Die()
        {
            if (hp.IsDead)
            {
                dead = true;
            }
            if (dead) //! 死亡フラグ
            {
                return;
            }
            manager.Controllable = false;
            onDead.Invoke();
        }

        // set on inspecter
        public void Radish()
        {
            collider.isTrigger = true;
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }

        void OnCollisionEnter(Collision info)
        {
            if (info.gameObject.CompareTag(constant.Missile))
            {
                hp.Damage(25);
            }
        }

        void nullcheck()
        {
            hp ??= GetComponent<HP>();
            manager ??= GameObject.FindGameObjectWithTag(constant.Manager).GetComponent<Manager>();
            collider ??= GetComponent<CapsuleCollider>();
            rigidbody ??= GetComponent<Rigidbody>();
        }
    }
}
