using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toon.Test
{

    public class GaugeView : MonoBehaviour
    {
        [Serializable]
        struct ColorChange
        {
            public float border;
            public Color color;
        }
        [SerializeField]
        ColorChange[] colorChange;

        void ChangeColor()
        {
            foreach (var _ in colorChange)
            {
                if (image.fillAmount <= _.border)
                {
                    image.color = _.color;
                    break;
                }
            }
        }

        int currentValue;
        int maxValue;

        [SerializeField]
        Image image;

        public void SetCurrentValue(int value)
        {
            currentValue = value;
            image.fillAmount = (float)currentValue / maxValue;
            ChangeColor();
        }

        public void SetMaxValue(int value)
        {
            maxValue = value;
            image.fillAmount = (float)currentValue / maxValue;
            ChangeColor();
        }
    }
}
