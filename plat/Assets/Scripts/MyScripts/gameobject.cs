using UnityEngine;

namespace Toon.Extend
{
    public static class gameobject
    {
        public static GameObject ins(
            GameObject[] objects, Vector3 position, Quaternion rotation)
        => UnityEngine.MonoBehaviour.Instantiate(
            objects[random.choice(objects.Length)], position, rotation);

        public static GameObject instance(
            this GameObject[] gameObject, Vector3 position, Quaternion rotation)
        => UnityEngine.MonoBehaviour.Instantiate(
            gameObject[random.choice(gameObject.Length)], position, rotation);

    }
}
