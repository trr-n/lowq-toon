using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class PlayerInput : MonoBehaviour
    {
        public bool shootable { get; set; }
        public bool isRotating { get; set; }

        [SerializeField]
        int click4shoot = 0;
        public int Click4Shoot => click4shoot;

        bool clicks;
        public bool Clicks => clicks;

        void Update()
        {
            clicks = input.pressed(click4shoot);
            if (clicks)
            {
                isRotating = true;
                shootable = true;
            }
        }
    }
}