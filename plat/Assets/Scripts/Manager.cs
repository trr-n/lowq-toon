using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] Material skybox;

        void Start()
        {
            // set skybox
            // RenderSettings.skybox = null;
            RenderSettings.skybox = skybox;

            // float f = 1.23f;
            // (f.cast<double>()).show();
        }

        void Update()
        {
            // current scene reloading when ur pressed 'keyCode' 
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
            {
                scene.load(scene.active());
            }
#endif

            // hide cursor
            c status;
#if UNITY_EDITOR
            status = c.show;
#else
            status = c.hide;
#endif
            visual.cursor(status);

            // set gravity
            SetGravity();
        }

        void SetGravity()
        {
            if (scene.active() == constant.Title)
            {
                Physics.gravity = new(0, 0, 0);
            }

            else if (scene.active() == constant.Main)
            {
                Physics.gravity = constant.MainGravity;
            }
        }
    }
}
