using System.Reflection.Emit;
using System.Reflection;
using System;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameTitle
{
    public static class Scenes
    {
        public static readonly string
            Main = "Main",
            Title = "Title"
            ;

        public static readonly Vector3 MainGravity = new(0, -9.81f, 0);
    }

    public static class Keys
    {
        public static readonly string
            Hor = "Horizontal",
            Ver = "Vertical",
            Jump = "Jump",
            MX = "Mouse X",
            MY = "Mouse Y",
            Volume = "Volume"
            ;
        public static readonly KeyCode Crouch = KeyCode.C;
    }

    public static class Tags
    {
        public static string
            Player = "Player",
            Ground = "Ground",
            MainCam = "MainCamera",
            Cam = "Cam",
            Gun = "Gun"
            ;
    }

    // 拡張メソッド版
    public static class Extended
    {
        public static int random(this int max) => UnityEngine.Random.Range(0, max);
        public static float random(this float max) => UnityEngine.Random.Range(0f, max);

        public static float ToSingle(this object num) => (float)num;
        public static int ToInt(this object num) => (int)num;
        // public static T cast<T>(this object obj) => (T)obj;
        public static object cast<T>(this object obj) => (T)obj;

        public static void show(this object msg)
        => UnityEngine.Debug.Log($"<color=white>{msg}</color> <size=10>{file.caller()}</size>");

        public static void warn(this object msg)
        => UnityEngine.Debug.LogWarning($"<color=orange>{msg}</color> <size=10>{file.caller()}</size>");

        public static void error(this object msg)
        => UnityEngine.Debug.LogError($"<color=red>{msg}</color> <size=10>{file.caller()}</size>");
    }

    /// <summary>
    /// random number generator
    /// </summary>
    public static class rand
    {
        public static float f(float min = 0, float max = 0)
        => UnityEngine.Random.Range(min, max);

        public static int i(int min = 0, int max = 0)
        => UnityEngine.Random.Range(min, max);

        public static int choice(int length)
        => rand.i(max: length - 1);

        public static GameObject ins(
            GameObject[] objects, Vector3 position, Quaternion rotation)
        => UnityEngine.MonoBehaviour.Instantiate(
            objects[rand.choice(objects.Length)], position, rotation);

        public static string str(int? count)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            // var charasArr = new char[(int)count];
            char[] charaArr = count != null ?
                new char[count.ToInt()] : new char[rand.i(2, 16)];
            System.Random random = new();
            for (int i = 0; i < charaArr.Length; i++)
            {
                charaArr[i] = characters[random.Next(characters.Length)];
            }
            return charaArr.ToString();
        }
    }

    public static class scene
    {
        public static void load(string name)
        => SceneManager.LoadScene(name);

        /// <summary>
        /// active scene name
        /// </summary>
        public static string active()
        => SceneManager.GetActiveScene().name;
    }

    public static class file
    {
        public static string caller(
            [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        => $"at {path}: {line}";
    }

    public enum c { hide, show }
    /// <summary>
    /// related 2 appearance
    /// </summary>
    public static class visual
    {
        public static float fps() => Mathf.Floor(1 / Time.deltaTime);

        public static string timer(int digits) => Time.time.ToString("F" + digits);

        public static void cursor(c status) => Cursor.visible = status != c.hide;
    }

    /// <summary>
    /// related 2 coordinate
    /// </summary>
    public static class coord
    {
        public static void clamped(Transform transform, float x, float y, float? z)
        {
            var tp = transform.position;
            Vector3 coordinate = new(
                x: Mathf.Clamp(tp.x, -x, x), y: Mathf.Clamp(tp.y, -y, y),
                z: Mathf.Clamp(tp.z, -z.ToSingle(), z.ToSingle())
            );
            transform.position = coordinate;
        }
    }

    public class Script //: MonoBehaviour
    {
        public static void print(object msg) => UnityEngine.Debug.Log(msg);

        public static GameObject Ins(GameObject obj, Vector3 v3, Quaternion quaternion)
        => MonoBehaviour.Instantiate(obj, v3, quaternion);

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

        public static string CurrentTime()
        {
            var now = DateTime.Now;
            var current = $"{now.Hour}:{now.Minute}:{now.Second}";
            return current.ToString();
        }

        public static IEnumerator Animation(
            Sprite[] sprites,
            SpriteRenderer sr,
            float? animeTime = null
        )
        {
            int i = 0;
            while (true)
            {
                i = i >= sprites.Length - 1 ? 0 : i + 1;
                sr.sprite = sprites[i];
                animeTime = animeTime != null ? animeTime : .05f;
                yield return new WaitForSeconds((float)animeTime);
            }
        }
    }

    // public class TestException : System.Exception
    // {
    //     public TestException(string exceptMsg = null) : base(exceptMsg) { }
    // }
}
