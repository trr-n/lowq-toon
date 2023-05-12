using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Toon.Extend
{
    public class Scene
    {
        public static void load(string name)
        => SceneManager.LoadScene(name);

        public static string active()
        => SceneManager.GetActiveScene().name;
    }
}
