using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Toon.Extend
{
    /// <summary>
    /// related 2 coordinate
    /// </summary>
    public static class coords
    {
        public static void clamped(Transform transform, float x, float y, float? z)
        {
            var tp = transform.position;
            Vector3 coordinate = new(
                x: Mathf.Clamp(tp.x, -x, x), y: Mathf.Clamp(tp.y, -y, y),
                z: Mathf.Clamp(tp.z, ((float)-z), ((float)z))
            );
            transform.position = coordinate;
        }
    }

    public class Script //: MonoBehaviour
    {
        public void FollowCursor(Transform tt, float z = 0)
        {
            var cur = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cur.z = z;
            tt.position = cur;
        }

        public void FollowCursorRay(Transform tt, float z = 0)
        {
            var cur = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            tt.position = cur.direction;
        }

        public void GetObject(Transform transform, int click = 0)
        {
            if (Input.GetMouseButtonDown(click))
            {
                Vector3 origin = transform.position, direction = new(100, 0, 0);
                RaycastHit2D hit = Physics2D.Raycast(origin, direction);
                if (hit.collider)
                {
                    var position = hit.collider.gameObject.transform.position;
                    $"position:{position}".show();
                }
            }
        }

        public static IEnumerator Animation(Sprite[] sprites, SpriteRenderer sr, float? animeTime = null)
        {
            var i = 0;
            while (true)
            {
                i = i >= sprites.Length - 1 ? 0 : i + 1;
                sr.sprite = sprites[i];
                animeTime = animeTime is null ? .05f : animeTime;
                yield return new WaitForSeconds((float)animeTime);
            }
        }
    }
}
