using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon.Extend
{
    public static class random
    {
        public static int max(this int max) => UnityEngine.Random.Range(0, max);
        public static float max(this float max) => UnityEngine.Random.Range(0f, max);

        public static float f(float min = 0, float max = 0)
         => UnityEngine.Random.Range(min, max);

        public static int i(int min = 0, int max = 0)
        => UnityEngine.Random.Range(min, max);

        public static int choice(int length)
        => i(max: length - 1);

        [System.Obsolete("cannot execute")]
        public static string str(int? count)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] charaArr = count is null ? new char[i(2, 16)] : new char[((int)count)];
            for (int i = 0; i < charaArr.Length; i++)
                charaArr[i] = characters[new System.Random().Next(characters.Length)];
            return charaArr.ToString();
        }
    }
}
