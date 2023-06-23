using UnityEngine;

namespace Toon
{
    [ExecuteAlways]
    public class HP : MonoBehaviour
    {
        const int max = 100;

        [SerializeField]
        [Range(0, max)]
        int current;

        public int Max => max;
        public int Current => current;
        public float Ratio => (float)current / max;
        public bool IsZero() => current <= 0;
        public void SetMax() => current = max;

        public void Heal(int healingAmount)
        {
            current = Mathf.Clamp(current, 0, max);
            current += healingAmount;
            if (current > max)
                SetMax();
        }

        public void Damage(int damageAmount)
        {
            current = Mathf.Clamp(current, 0, max);
            current -= damageAmount;
            if (current < 0)
                current = 0;
        }
    }
}