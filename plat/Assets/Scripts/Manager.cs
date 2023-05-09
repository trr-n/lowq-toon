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

        void Start()
        {
            // set skybox material
            // RenderSettings.skybox = skybox;
        }

        void Update()
        {
            SceneReloading();

            // hide cursor
            visual.cursor(c.hide);
        }

        /// <summary>
        /// reloading current scene when reloadKey is pressed
        /// </summary>
        void SceneReloading()
        {
            if (Input.GetKeyDown(KeyCode.F1))
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
                Physics.gravity = Scenes.MainGravity;
            }
        }
    }
}
