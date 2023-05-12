using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon.Extend
{
    public static class TransformExtensions
    {
        public static void SetPositionX(this Transform thisTransform, float x)
        {
            thisTransform.position = new(
                x, thisTransform.position.y, thisTransform.position.z);
        }

        public static void MoveTo(this Transform thisTransform, Vector3 target, float moveTime)
        {
            var handle = thisTransform.gameObject.AddComponent<CoroutineHandler>();
            handle.Exec(MoveToInternal(thisTransform, target, moveTime));
        }

        static IEnumerator MoveToInternal(Transform transform, Vector3 target, float moveTime)
        {
            Vector3 start = transform.position;
            float currentTime = 0f;

            while (currentTime < moveTime)
            {
                yield return null;
                transform.position = Vector3.Lerp(start, target, currentTime / moveTime);
                currentTime += Time.deltaTime;
            }
            transform.position = target;
        }
    }
}
