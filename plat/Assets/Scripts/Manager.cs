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
        [SerializeField] KeyCode key_reload = KeyCode.F1;

        void Start()
        {
            // set skybox
            RenderSettings.skybox = null; //skybox;
        }

        void Update()
        {
            // current scene reloading when ur pressed 'keyCode' 
            Reload(key_reload);

            // hide cursor
            visual.cursor(c.hide);

            // set gravity
            SetGravity();
        }

        void Reload(KeyCode keyCode)
        {
            if (Input.GetKeyDown(keyCode))
            {
                Scene.load(Scene.active());
            }
        }

        void SetGravity()
        {
            if (Scene.active() == Const.Title)
            {
                Physics.gravity = new(0, 0, 0);
            }

            if (Scene.active() == Const.Main)
            {
                "set".show();
                Physics.gravity = Const.MainGravity;
            }
        }
    }
}
