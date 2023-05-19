using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toon.Test
{
    public class CurrentMaxText : MonoBehaviour
    {
        int currentValue;
        [SerializeField]
        Text currentValueText;

        int maxValue;
        [SerializeField]
        Text maxValueText;

        public void SetCurrentValue(int value)
        {
            currentValue = value;
            currentValueText.text = value.ToString();
        }

        public void SetMaxValue(int value)
        {
            maxValue = value;
            maxValueText.text = value.ToString();
        }
    }
}
