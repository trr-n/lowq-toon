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

        const int mute = 0, min = 1, mid = 2, max = 3;

        void Start()
        {
            spk = speaker.GetComponent<Speaker>();

            image.sprite = icons[mute];
        }

        void Update()
        {
            volume = spk.Volume;
            // mute: lower - 0
            if (volume <= 0)
            {
                image.sprite = icons[mute];
            }
            // min: 0 - 0.125
            else if (volume <= 0.125f && volume >= 0)
            {
                image.sprite = icons[min];
            }
            // mid: 0.125 - 0.2
            else if (volume <= 0.125f && volume >= 0.2f)
            {
                image.sprite = icons[mid];
            }
            // max: 0.2 - upper
            else if (volume >= 0.2f)
            {
                image.sprite = icons[max];
            }
        }
    }
}
