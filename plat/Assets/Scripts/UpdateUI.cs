using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon
{
    public class UpdateUI : MonoBehaviour
    {
        [SerializeField]
        HP pHp;

        [SerializeField]
        HP tHp;

        [SerializeField]
        Text pText;

        [SerializeField]
        Image tImage;

        const float alpha = 1;
        float r = 0;
        float g = 0;
        const float b = 0;
        Color color = new(0, 1, b, alpha);

        void Update()
        {
            pText.text = pHp.Current.ToString();

            GaugeGradation();
            tImage.fillAmount = tHp.Ratio;
        }

        void GaugeGradation()
        {
            color = new(r, g, b, alpha);
            tImage.color = color;
            if (tHp.Ratio >= 0.5f)
            {
                g = tHp.Ratio;
            }
            else if (tHp.Ratio < 0.5f)
            {
                var _r = 1 - tHp.Ratio;
                r = _r;
            }
        }
    }
}
