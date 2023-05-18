using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon
{
    public class Player : MonoBehaviour
    {
        [SerializeField] GameObject panel;

        float fadingSpeed = 0.0001f;
        const float MaxHP = 1;
        float currentHP = 1;
        public float CurrentHP => currentHP;
        // float alpha = 0;

        bool isDead = false;
        public bool IsDead => isDead;

        Image image;
        Manager manager;

        void Start()
        {
            HpSet();
            image = panel.GetComponent<Image>();
            manager = GameObject.FindGameObjectWithTag(constant.Manager).GetComponent<Manager>();
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
            // image.color.a.show();
            /*死んだらシーン移動*/
            if (!isDead)
            {
                return;
            }
            manager.Fading(image, fadingSpeed);
            Radish();
        }

        void Radish()
        {
            var c = GetComponent<CapsuleCollider>();
            c.isTrigger = true;
            var r = GetComponent<Rigidbody>();
            r.isKinematic = true;
            r.useGravity = false;
        }


        // IEnumerator FadeIn(GameObject panel, float duration)
        // {
        //     float timer = 0;
        //     Image image = panel.GetComponent<Image>();
        //     while (timer < duration)
        //     {
        //         timer += Time.deltaTime;
        //         alpha = Mathf.Lerp(0, 255, timer / duration);
        //         image.color = new Color(0, 0, 0, alpha);
        //         yield return null;
        //     }
        // }

        void OnCollisionEnter(Collision info)
        {
            if (info.gameObject.CompareTag(constant.Missile))
            {
                Damage(0.25f);
            }
        }
    }
}
