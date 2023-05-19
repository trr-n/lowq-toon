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
        HP playerHP;

        float fadingSpeed = 0.0001f;
        const float MaxHP = 1;
        float currentHP = 1;
        public float CurrentHP => currentHP;
        // float alpha = 0;

        bool isDead = false;
        public bool IsDead => isDead;

        Image image;
        Manager manager;

        [SerializeField]
        UnityEvent onDead;

        void Start()
        {
            image = panel.GetComponent<Image>();
            manager = GameObject.FindGameObjectWithTag(constant.Manager).GetComponent<Manager>();

            playerHP.SetMax();
        }

        void Update()
        {
            currentHP = numeric.clamp(currentHP, 0, MaxHP);
            isDead = currentHP <= 0;
            Die();
#if UNITY_EDITOR

#endif
        }

        void HpSet() => currentHP = MaxHP;
        float HpRatio() => MaxHP / currentHP;
        float HpRemaining() => MaxHP - currentHP;
        void Damage(float damage) => currentHP -= damage;

        void Die()
        {
            if (!isDead)
            {
                return;
            }
            onDead.Invoke();
        }

        // インスペクタで設定
        public void Radish()
        {
            var collider = GetComponent<CapsuleCollider>();
            collider.isTrigger = true;
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }

        void OnCollisionEnter(Collision info)
        {
            if (info.gameObject.CompareTag(constant.Missile))
            {
                Damage(0.25f);
            }
        }
    }
}
