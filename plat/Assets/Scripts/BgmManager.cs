using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmManager : MonoBehaviour
{
    [SerializeField]
    Slider bgmVolumeSlider;

    float bgmVolume;
    public float BgmVolume => bgmVolume;

    public void BGM()
    {
        bgmVolumeSlider.value = bgmVolume;
    }

    void Update()
    {
        print(bgmVolume);
    }
}
