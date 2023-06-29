using UnityEngine;
using UnityEngine.SceneManagement;

namespace Toon
{
    public class ScenesManager : MonoBehaviour
    {
        public void ToMainScene() => SceneManager.LoadScene(Constant.Main);
        public void ToTitleScene() => SceneManager.LoadScene(Constant.Title);
    }
}
