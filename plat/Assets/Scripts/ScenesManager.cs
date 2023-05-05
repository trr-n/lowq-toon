using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameTitle
{
    public class ScenesManager : MonoBehaviour
    {
        public void ToMainScene()
        {
            SceneManager.LoadScene(Scenes.Main);
        }

        public void ToTitleScene()
        {
            SceneManager.LoadScene(Scenes.Title);
        }
    }
}
