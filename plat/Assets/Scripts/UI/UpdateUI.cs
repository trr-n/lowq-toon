using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon
{
    public class UpdateUI : MonoBehaviour
    {
        [SerializeField]
        GameObject view;

        [SerializeField]
        Text setumeiT;

        [SerializeField]
        HP pHp;

        [SerializeField]
        Text pText;

        [SerializeField]
        Image pImage;

        [SerializeField]
        Manager manager;

        [SerializeField]
        Image remain;

        [SerializeField]
        HP tHp;

        [SerializeField]
        Image tower;

        [SerializeField]
        Sprite[] volIcons;

        [SerializeField]
        Image volume;

        [SerializeField]
        Speaker spk;

        [SerializeField]
        Image fading;

        const float alpha = 1f;

        bool isMute, isQuiet, isBoring, isLoud;
        const int mute = 0, quiet = 1, boring = 2, loud = 3;

        void Start()
        {
            spk ??= GameObject.FindGameObjectWithTag(constant.Speaker)
                .GetComponent<Speaker>();

            view.SetActive(false);
        }

        void Update()
        {
            pText.text = pHp.Current.ToString();

            GaugeGradation2(remain, manager.RemainRatio);
            GaugeGradation2(pImage, pHp.Ratio);
            GaugeGradation2(tower, tHp.Ratio);

            VolumeIcon();
            //TowerTowel();

            if (manager.TimerStart)
            {
                view.SetActive(true);

                setumeiT.text = null;
            }
        }

        void TowerTowel()
        {
            tower.fillAmount = tHp.Ratio;
        }

        const int b = 0;
        float remainR = 0;
        float remainG = 0;

        void GaugeGradation2(Image image, float ratio)
        {
            image.fillAmount = ratio;
            image.color = new(remainR, remainG, b, alpha);

            if (ratio >= 0.5f)
            {
                remainG = ratio;
            }

            else if (ratio < 0.5f)
            {
                var _r = 1 - ratio;
                remainR = _r;
            }
        }

        //void GaugeGradation(Image image, float ratio)
        //{
        //    remain.fillAmount = manager.RemainRatio;
        //    remainColor = new(remainR, remainG, b, alpha);
        //    remain.color = remainColor;

        //    if (manager.RemainRatio >= 0.5f)
        //    {
        //        remainG = manager.RemainRatio;
        //    }

        //    else if (manager.RemainRatio < 0.5f)
        //    {
        //        var _r = 1 - manager.RemainRatio;
        //        remainR = _r;
        //    }

        //    tower.fillAmount = thp.Ratio;
        //    towerColor = new(towerR, towerG, b, talpha);
        //    tower.color = towerColor;

        //    if (thp.Ratio >= 0.5f)
        //    {
        //        towerG = thp.Ratio;
        //    }

        //    else if (thp.Ratio < 0.5f)
        //    {
        //        var _r = 1 - thp.Ratio;
        //        towerR = _r;
        //    }
        //}

        void VolumeIcon()
        {
            isMute = spk.Volume <= 0;
            isQuiet = spk.Volume <= spk.MaxVolume / 3;
            isBoring = spk.Volume <= spk.MaxVolume / 2.5f;
            isLoud = !(isMute && isQuiet && isBoring);

            if (isMute)
            {
                volume.sprite = volIcons[mute];
            }

            else if (isQuiet)
            {
                volume.sprite = volIcons[quiet];
            }

            else if (isBoring)
            {
                volume.sprite = volIcons[boring];
            }

            else if (isLoud)
            {
                volume.sprite = volIcons[loud];
            }
        }
    }
}
