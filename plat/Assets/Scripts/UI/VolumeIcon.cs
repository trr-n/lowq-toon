using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toon
{
    public class VolumeIcon : MonoBehaviour
    {
        [SerializeField] Sprite[] icons;
        [SerializeField] Image image;
        [SerializeField] GameObject speaker;

        Speaker spk;

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
        }

        void Update()
        {
            volumie();
        }

        void volumie()
        {
            isMute = spk.Volume <= 0;
            isQuiet = spk.Volume <= spk.MaxVolume / 3;
            isBoring = spk.Volume <= spk.MaxVolume / 2.5f;
            isLoud = !(isMute && isQuiet && isBoring);

            if (isMute)
                image.sprite = icons[mute];
            else if (isQuiet)
                image.sprite = icons[quiet];
            else if (isBoring)
                image.sprite = icons[boring];
            else if (isLoud)
                image.sprite = icons[loud];
        }
    }
}
