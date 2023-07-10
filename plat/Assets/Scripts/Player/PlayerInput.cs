using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class PlayerInput : MonoBehaviour
    {
        public bool shootable { get; set; }
        public bool isRotating { get; set; }
        public bool isSneaking { get; set; }

        [SerializeField]
        int click4shoot = 1;
        public int Click4Shoot => click4shoot;

        bool clicks;
        public bool Clicks => clicks;

        void Update()
        {
            isSneaking = SelfInput.Pressed(KeyCode.LeftShift);
            clicks = SelfInput.Pressed(click4shoot);
            if (clicks)
            {
                isRotating = true;
                shootable = true;
            }
        }
    }
}