using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    Slider slider;

    public void LoadingNext()
    {
        panel.SetActive(true);
        StartCoroutine(LoadingScene());
    }

    IEnumerator LoadingScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(
            SceneManager.GetActiveScene().name);

        while (!async.isDone)
        {
            slider.value = async.progress;
            yield return null;
        }
    }
}

// https://nosystemnolife.com/unity_loading/