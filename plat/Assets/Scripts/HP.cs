using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class HP : MonoBehaviour
    {
        [SerializeField]
        int max = 100;

        [SerializeField]
        int current;

        public int Max => max;
        public int Current => current;

        public float Ratio => current / max;

        public void SetMax() => current = max;

        public bool IsDead => current <= 0;

        public void Heal(int healingAmount)
        {
            current = current.clamping(0, max);
            current += healingAmount;
            if (current > max)
            {
                SetMax();
            }
        }

        public void Damage(int damageAmount)
        {
            current = current.clamping(0, max);
            current -= damageAmount;
            if (current < 0)
            {
                current = 0;
            }
        }
    }
}