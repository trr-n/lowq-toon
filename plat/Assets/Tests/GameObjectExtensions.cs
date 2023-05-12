using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon.Extend
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// GameObjectに座標を直接設定する
        /// </summary>
        /// <param name="thisObject"></param>
        /// <param name="position">設定したい座標</param>
        public static void SetPosition(this GameObject thisObject, Vector3 position)
        {
            thisObject.transform.position = position;
        }
    }
}
