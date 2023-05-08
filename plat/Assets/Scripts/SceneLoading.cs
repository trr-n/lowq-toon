using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameTitle
{
    public class SceneLoading : MonoBehaviour
    {
        [SerializeField]
        GameObject panel;
        [SerializeField]
        Slider slider;
        [SerializeField]
        Button button;

        public void LoadingNext()
        {
            panel.SetActive(true);
            StartCoroutine(LoadingScene());
        }

        IEnumerator LoadingScene()
        {
            var async = SceneManager.LoadSceneAsync(Scenes.Main);

            while (!async.isDone)
            {
                slider.value = async.progress;
                yield return null;
            }
        }
    }
}

// https://nosystemnolife.com/unity_loading/