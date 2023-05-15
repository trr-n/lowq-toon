using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Toon
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
            var async = SceneManager.LoadSceneAsync(constant.Main);
            while (!async.isDone)
            {
                slider.value = async.progress;
                yield return null;
            }
        }
    }
}