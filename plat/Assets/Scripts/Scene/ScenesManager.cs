using UnityEngine;
using UnityEngine.SceneManagement;

namespace Toon
{
    public class ScenesManager : MonoBehaviour
    {
        public void ToMainScene() => SceneManager.LoadScene(constant.Main);
        public void ToTitleScene() => SceneManager.LoadScene(constant.Title);
    }
}
