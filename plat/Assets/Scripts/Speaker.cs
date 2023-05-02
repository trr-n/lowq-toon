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

        [SerializeField, Range(0.01f, 0.1f)]
        float initVolume = 0.05f;

        [SerializeField]
        float vChange = 0.02f;

        public float Volume;

        void Start()
        {
            audio = this.gameObject.GetComponent<AudioSource>();
            audio.clip = musics[musics.Length.random()];
            audio.volume = initVolume;
            audio.Play();
        }

        void Update()
        {
            Volume = audio.volume;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audio.volume += vChange;
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audio.volume -= vChange;
            }
        }
    }
}
