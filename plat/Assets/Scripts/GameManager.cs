using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameTitle
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] Material skybox;

        void Start()
        {
            // set main gravity
            Physics.gravity = Scenes.MainGravity;

            // set skybox material
            RenderSettings.skybox = skybox;
        }

        void Update()
        {
            SceneReloading();

            // hide cursor
            visual.cursor(c.hide);

            "show".show();
            "warn".warn();
            "error".error();
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
    }
}
