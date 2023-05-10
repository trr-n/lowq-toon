using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameTitle
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
                scene.load(scene.active());
            }
        }

        void SetGravity()
        {
            if (scene.active() == Scenes.Title)
            {
                Physics.gravity = new(0, 0, 0);
            }

            if (scene.active() == Scenes.Main)
            {
                "set".show();
                Physics.gravity = Scenes.MainGravity;
            }
        }
    }
}
