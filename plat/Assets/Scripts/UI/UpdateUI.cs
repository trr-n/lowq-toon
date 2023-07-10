using UnityEngine;
using UnityEngine.UI;

namespace Toon
{
    public class UpdateUI : MonoBehaviour
    {
        [SerializeField]
        GameObject view;

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
        (bool boo, int index) mute, quiet, boring, loud;

        void Start()
        {
            spk ??= GameObject.FindGameObjectWithTag(Constant.Speaker).GetComponent<Speaker>();
            view.SetActive(false);
        }

        void Update()
        {
            pText.text = pHp.Current.ToString();
            remain.fillAmount = manager.RemainRatio;
            tower.fillAmount = tHp.Ratio;
            GaugeGradation2(pImage, pHp.Ratio);
            VolumeIcon();
            if (manager.TimerStart)
                view.SetActive(true);
        }

        const int b = 0;
        float remainR = 0;
        float remainG = 0;

        void GaugeGradation2(Image image, float ratio)
        {
            image.fillAmount = ratio;
            image.color = new(remainR, remainG, b, alpha);
            if (ratio >= 0.5f)
                remainG = ratio;
            else if (ratio < 0.5f)
            {
                var _r = 1 - ratio;
                remainR = _r;
            }
        }

        void VolumeIcon()
        {
            mute = (spk.Volume <= 0, 0);
            quiet = (spk.Volume <= spk.MaxVolume / 3, 1);
            boring = (spk.Volume <= spk.MaxVolume / 2.5f, 2);
            loud = (!(mute.boo && quiet.boo && boring.boo), 3);
            if (mute.boo) volume.sprite = volIcons[mute.index];
            else if (quiet.boo) volume.sprite = volIcons[quiet.index];
            else if (boring.boo) volume.sprite = volIcons[boring.index];
            else if (loud.boo) volume.sprite = volIcons[loud.index];
        }
    }
}
