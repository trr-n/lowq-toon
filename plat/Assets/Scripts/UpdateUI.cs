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
        Text pText;

        [SerializeField]
        Manager manager;

        [SerializeField]
        Image remain;

        [SerializeField]
        HP thp;

        [SerializeField]
        Image tower;

        const float alpha = 0.5f;
        const float talpha = 1f;
        float remainR = 0;
        float towerR = 0;
        float remainG = 0;
        float towerG = 0;
        const float b = 0;
        Color remainColor = new(0, 1, b, alpha);
        Color towerColor = new(0, 1, b, talpha);

        void Update()
        {
            pText.text = pHp.Current.ToString();
            GaugeGradation();
        }

        void GaugeGradation()
        {
            remain.fillAmount = manager.RemainRatio;
            remainColor = new(remainR, remainG, b, alpha);
            remain.color = remainColor;

            if (manager.RemainRatio >= 0.5f)
            {
                remainG = manager.RemainRatio;
            }
            else if (manager.RemainRatio < 0.5f)
            {
                var _r = 1 - manager.RemainRatio;
                remainR = _r;
            }

            tower.fillAmount = thp.Ratio;
            towerColor = new(towerR, towerG, b, alpha);
            tower.color = towerColor;

            if (thp.Ratio >= 0.5f)
            {
                towerG = thp.Ratio;
            }
            else if (thp.Ratio < 0.5f)
            {
                var _r = 1 - thp.Ratio;
                towerR = _r;
            }
        }
    }
}
