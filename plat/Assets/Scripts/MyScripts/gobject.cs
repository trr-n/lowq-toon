using UnityEngine;

namespace Toon.Extend
{
    public static class gobject
    {
        public static GameObject ins(
            this GameObject[] gameObjects, Vector3 position, Quaternion rotation)
        => UnityEngine.MonoBehaviour.Instantiate(gameObjects[random.choice(gameObjects.Length)], position, rotation);

        public static GameObject ins(
            this GameObject gameObject, Vector3 position, Quaternion rotation)
        => UnityEngine.MonoBehaviour.Instantiate(gameObject, position, rotation);

        public static bool exist(this GameObject gameObject)
        => gameObject;
    }
}
