using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Toon.Test
{
    public class HP : MonoBehaviour
    {
        [SerializeField] int currentValue;
        public int Current => currentValue;

        [SerializeField] int maxValue;
        public int Max => maxValue;

        [SerializeField]
        UnityEvent<int> onCurrentValueChanged;

        [SerializeField]
        UnityEvent<int> onMaxValueChanged;

        void Start()
        {
            currentValue = maxValue;
            onMaxValueChanged?.Invoke(maxValue);
            onCurrentValueChanged?.Invoke(currentValue);
        }

        public void Add(int value)
        {
            currentValue = Mathf.Clamp(currentValue, 1, maxValue);
            currentValue += value;
            if (currentValue >= maxValue)
            {
                currentValue = maxValue;
            }
            onCurrentValueChanged?.Invoke(currentValue);
        }
    }
}