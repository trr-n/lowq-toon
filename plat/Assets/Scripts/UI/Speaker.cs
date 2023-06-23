using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    [RequireComponent(typeof(AudioSource))]
    public class Speaker : MonoBehaviour
    {
        [SerializeField]
        AudioClip music;

        new AudioSource audio;

        /// <summary>
        /// 初期の音量
        /// </summary>
        float initVolume = 0.05f;

        float inputV;
        public float InputV => inputV;
        public float Volume;
        public readonly float MaxVolume = 0.5f;

        KeyCode[] codes = new KeyCode[3] {
            KeyCode.UpArrow,
            KeyCode.DownArrow,
            KeyCode.RightShift
        };
        const int Up = 0, Down = 1, RShift = 2;

        int playing;
        public int Playing => playing;

        string nowPlaying;
        public string NowPlaying => nowPlaying;

        void Start()
        {
            audio = GetComponent<AudioSource>();
            audio.clip = music;
            audio.volume = initVolume;
            audio.loop = true;
            audio.Play();
        }

        void Update()
        {
            VolumeChousei();
        }

        void VolumeChousei()
        {
            nowPlaying = audio.clip.name;
            inputV = Input.GetAxisRaw(constant.Volume) / 100;
            float preMuteVolume = 0;
            float vol = Mathf.Clamp(audio.volume, 0, MaxVolume);
            Volume = audio.volume;

            if (methods(codes[Up]) || methods(codes[Down]))
                vol += inputV;

            if (methods(codes[RShift]) && methods(codes[Down]))
            {
                preMuteVolume = audio.volume;
                vol = 0;
            }
            else if (methods(codes[RShift]) && methods(codes[Up]))
                vol = preMuteVolume;
            audio.volume = vol;
        }

        bool methods(KeyCode keyCode) => Input.GetKeyDown(keyCode);
    }
}
