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

        void Start()
        {
            audio = this.gameObject.GetComponent<AudioSource>();
            audio.clip = musics[0];
        }

        void Update()
        {
            // PlayMusic();
        }

        public void PlayMusic()
        {
            if (audio.isPlaying)
            {
                return;
            }
            // audio.clip = musics[Random.Randint(musics.Length)];
            audio.clip = musics[musics.Length.random()];
        }

        public void AudioVolumeChange(float _volume)
        {
            audio.volume = _volume;
        }
    }
}
