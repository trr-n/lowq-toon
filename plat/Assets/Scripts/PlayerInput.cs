using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTitle
{
    public class PlayerInput : MonoBehaviour
    {
        bool shootable;
        public bool Shootable { get => shootable; set => shootable = value; }

        bool isRotating;
        public bool IsRotating { get => isRotating; set => isRotating = value; }

        [SerializeField]
        int click4shoot = 0;
        public int Click4Shoot => click4shoot;

        void Update()
        {
            var clicks = Input.GetMouseButtonDown(click4shoot);

            if (clicks)
            {
                isRotating = true;
                shootable = true;
            }
        }
    }
}