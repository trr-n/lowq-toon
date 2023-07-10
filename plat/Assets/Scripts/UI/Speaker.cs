using System;
using UnityEngine;

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

        public float Volume;
        public readonly float MaxVolume = 0.5f;

        KeyCode[] codes = new KeyCode[3] {
            KeyCode.UpArrow,
            KeyCode.DownArrow,
            KeyCode.RightShift
        };
        const int Up = 0, Down = 1, RShift = 2;
        string playing;

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

        float prev = 0f;
        int counter = 0;
        void VolumeChousei()
        {
            playing = audio.clip.name;
            var inputV = Input.GetAxisRaw(Constant.Volume) / 100;
            float vol = Mathf.Clamp(audio.volume, 0, MaxVolume);
            Volume = audio.volume;
            print(Volume);

            if (Input.GetKeyDown(codes[Up]) || Input.GetKeyDown(codes[Down]))
                vol += inputV;

            // 右シフトでBGMミュート切り替え
            if (Input.GetKeyDown(codes[RShift]))
            {
                if (counter == 0)
                {
                    counter++;
                    prev = audio.volume;
                    vol = 0;
                }
                else if (counter == 1)
                {
                    counter = 0;
                    vol = prev;
                }
            }
            audio.volume = MathF.Round(vol, 2);
        }

        public void SetVolume(float f) => audio.volume = f;
    }
}
