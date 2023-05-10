using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameTitle
{
    public class VolumeIcon : MonoBehaviour
    {
        [SerializeField] Sprite[] icons;
        [SerializeField] Image image;
        [SerializeField] GameObject speaker;

        Speaker spk;

        float volume;
        float max_vol;
        const int mute = 0;
        const int quiet = 1;
        const int boring = 2;
        const int loud = 3;

        bool isMute;
        bool isQuiet;
        bool isBoring;
        bool isLoud;

        void Start()
        {
            spk = speaker.GetComponent<Speaker>();
            image.sprite = icons[mute];
        }

        void Update()
        {
            volumie();
        }

        void volumie()
        {
            volume = spk.Volume;
            max_vol = spk.MaxVolume;

            isMute = volume <= 0;
            isQuiet = volume <= max_vol / 4;
            isBoring = volume <= max_vol / 2;
            isLoud = !(isMute && isQuiet && isBoring);

            if (isMute)
            {
                image.sprite = icons[mute];
            }
            else if (isQuiet)
            {
                image.sprite = icons[quiet];
            }
            else if (isBoring)
            {
                image.sprite = icons[boring];
            }
            else if (isLoud)
            {
                image.sprite = icons[loud];
            }
        }
    }
}
