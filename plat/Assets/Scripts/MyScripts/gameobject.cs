using UnityEngine;

namespace Toon.Extend
{
    public static class Objects
    {
        public static GameObject ins(
            GameObject[] objects, Vector3 position, Quaternion rotation)
        => UnityEngine.MonoBehaviour.Instantiate(
            objects[Rand.choice(objects.Length)], position, rotation);

        // extended
        public static GameObject ins2(
            this GameObject[] gameObject, Vector3 position, Quaternion rotation)
        => UnityEngine.MonoBehaviour.Instantiate(
            gameObject[Rand.choice(gameObject.Length)], position, rotation);

    }
}
