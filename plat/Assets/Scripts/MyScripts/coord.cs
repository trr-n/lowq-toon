using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon.Extend
{
    public static class Coord
    {
        public static void set(this Transform transform,
            float? x = null, float? y = null, float? z = null)
        {
            // 全部空で なんもはいってへんわエクセプション 発動
            if (x == null & y == null & z == null)
            {
                throw new NanmoHaittehenwaException();
            }

            transform.position = new(
                    x != null ? x.single() : transform.position.x,
                    y != null ? y.single() : transform.position.y,
                    z != null ? z.single() : transform.position.z
            );
        }

        public static void set(this Transform transform, Vector3 position)
        => transform.position = position;

        public static void move2d(this Transform transform,
            float speed, bool multiplyTime = true, string axis1 = "Horizontal", string axis2 = "Vertical")
        {
            float h = Input.GetAxis(axis1), v = Input.GetAxis(axis2);
            Vector3 move = new(h, v);
            Vector3 move2 = move * speed;
            transform.Translate(multiplyTime ? move2 * Time.deltaTime : move2);
        }
    }
}
