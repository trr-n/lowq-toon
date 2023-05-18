using UnityEngine;
using Toon.Extend;

namespace Toon.Test
{
    [CreateAssetMenu]
    public class Health : ScriptableObject
    {
        [SerializeField] string test = "test";
        public string Test => test;

        [SerializeField] float maxhp;
        public float MaxHP => maxhp;

        [SerializeField] float damage;
        public float Damage => damage;

        public void Die(float current)
        {
            if (current <= 0)
            {
                "dead".show();
            }
        }
    }
}
