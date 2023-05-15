using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon.Extend
{
    public static class coord
    {
        public static void set(this Transform transform,
            double? x = null, double? y = null, double? z = null)
        {
            // 全部空で なんもはいってへんわエクセプション 発動
            // nullチェックに==は重い?らしい
            if (x is null && y is null && z is null)
            {
                throw new NanmoHaittehenwaException();
            }

            transform.position = new(
                    x is not null ? x.single() : transform.position.x,
                    y is not null ? y.single() : transform.position.y,
                    z is not null ? z.single() : transform.position.z
            );
        }

        public static void set(this Transform transform, Vector3 position)
        => transform.position = position;

        public static void setr(this Transform transform,
            double? eulerX = null, double? eulerY = null, double? eulerZ = null)
        {
            // 全部空で なんもはいってへんわエクセプション 発動
            if (eulerX is null && eulerY is null && eulerZ is null)
            {
                throw new NanmoHaittehenwaException();
            }

            transform.rotation = Quaternion.Euler(new(
                    eulerX is not null ? eulerX.single() : transform.rotation.x,
                    eulerY is not null ? eulerY.single() : transform.rotation.y,
                    eulerZ is not null ? eulerZ.single() : transform.rotation.z
            ));
        }

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
