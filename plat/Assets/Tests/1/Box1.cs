using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon.Test
{
    public class Box1 : MonoBehaviour
    {
        float current;
        // Health health;
        const float Max = 1f;
        float damage = 0.5f;

        void Start()
        {
            // health = GameObject.FindGameObjectWithTag(constant.ScriptableFile).GetComponent<Health>();
            current = Max;
        }

        void Update()
        {
            Die();
        }

        void Die()
        {
            if (current <= 0)
            {
                "dead".show();
                gameObject.SetActive(false);
            }
        }

        void OnCollisionEnter(Collision info)
        {
            if (info.gameObject.CompareTag(Constant.Test))
            {
                "hit".show();
                current -= damage;
                Destroy(info.gameObject);
            }
        }
    }
}
