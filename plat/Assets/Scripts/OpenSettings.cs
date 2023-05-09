using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameTitle
{
    public class OpenSettings : MonoBehaviour
    {
        [SerializeField]
        Renderer URP_Mine;

        static readonly string[] Changes = new string[2] {
            "Project/Quality",
            "Project/Graphics"
        };

        [MenuItem("Settings/OpenProject")]
        private static void OpenProject()
        {
            var a = SettingsService.OpenProjectSettings(Changes[0]);
            a.show();
        }

        void Start()
        {
            // QualitySettings.renderPipeline = null;
            // Graphics
        }
    }
}
