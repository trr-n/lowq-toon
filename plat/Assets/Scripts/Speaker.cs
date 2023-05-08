using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTitle
{
    [RequireComponent(typeof(AudioSource))]
    public class Speaker : MonoBehaviour
    {
        [SerializeField]
        AudioClip[] musics;
        new AudioSource audio;

        /// <summary>
        /// 初期の音量
        /// </summary>
        float initVolume = 0.05f;

        float inputV;
        public float InputV => inputV;
        public float Volume;

        KeyCode[] codes = new KeyCode[3] {
            KeyCode.UpArrow,
            KeyCode.DownArrow,
            KeyCode.RightShift
        };
        const int Up = 0, Down = 1, RShift = 2;

        void Start()
        {
            audio = this.gameObject.GetComponent<AudioSource>();
            audio.clip = musics[rand.i(musics.Length.arr())];
            audio.volume = initVolume;
            audio.Play();
        }

        void Update()
        {
            inputV = Input.GetAxisRaw(Keys.Volume) / 100;
            float preMuteVolume = 0;
            float vol = Mathf.Clamp(audio.volume, 0, 0.1f);
            Volume = audio.volume;

            if (func(codes[Up]) || func(codes[Down]))
            {
                vol += inputV;
            }

            if (func(codes[RShift]) && func(codes[Down]))
            {
                preMuteVolume = audio.volume;
                vol = 0;
            }

            else if (func(codes[RShift]) && func(codes[Up]))
            {
                vol = preMuteVolume;
            }
            audio.volume = vol;
        }

        bool func(KeyCode keyCode)
        {
            return Input.GetKeyDown(keyCode);
        }
    }
}
