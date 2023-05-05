using System;
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
        public static float random(this float max) => UnityEngine.Random.Range(0f, max).ToInt();

        public static float ToSingle(this object num) => (float)num;
        public static int ToInt(this object num) => (int)num;
        // public static T TypeCast<T>(this object obj) => (T)obj;

        public static void show(this object msg) => UnityEngine.Debug.Log(msg);
    }

    public static class Random
    {
        public static float Randfloat(float min = 0, float max = 0)
        => UnityEngine.Random.Range(min, max);

        public static int Randint(int min = 0, int max = 0)
        => UnityEngine.Random.Range(min, max);

        public static GameObject Randins(
            GameObject[] objects, Vector3 position, Quaternion rotation)
        => UnityEngine.MonoBehaviour.Instantiate(
            // objects[Random.Randint(max: objects.Length)], position, rotation);
            objects[objects.Length.random()], position, rotation);
    }

    public class Script : MonoBehaviour
    {
        public static string Randstring(int? count)
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            // var charasArr = new char[(int)count];
            char[] charaArr = count != null ?
                new char[count.ToInt()] : new char[Random.Randint(2, 16)];
            System.Random random = new();
            for (int i = 0; i < charaArr.Length; i++)
            {
                charaArr[i] = characters[random.Next(characters.Length)];
            }
            return charaArr.ToString();
        }


        public static GameObject Ins(
            GameObject obj, Vector3 v3, Quaternion quaternion)
        => Instantiate(obj, v3, quaternion);

        public void FollowCursor(Transform transform, float z = 0)
        {
            var cursor = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursor.z = z;
            transform.position = cursor;
        }

        /// <summary>
        /// クリックでオブジェクト取得
        /// <param name="click">0: left, 1: right</param>
        /// </summary>
        public void GetObject(Transform transform, int click = 0)
        {
            if (Input.GetMouseButtonDown(click))
            {
                Vector3 origin = transform.position, direction = new(100, 0, 0);
                RaycastHit2D h = Physics2D.Raycast(origin, direction);
                if (h.collider)
                {
                    var pos = h.collider.gameObject.transform.position;
                    $"position:{pos}".show();
                }
            }
        }

        public static float ComputeFps() => Mathf.Floor(1 / Time.deltaTime);

        public static string Timer(int digits) => Time.time.ToString("F" + digits);

        public static void VisibleCursor(bool isVisible = false)
        => Cursor.visible = isVisible;

        public static void AudioSlider(AudioSource audioSource, float volume = .01f)
        => audioSource.volume = volume;

        public static void LimitRange(Transform transform, float x, float y, float? z)
        {
            var tp = transform.position;
            Vector3 coords = new(
                Mathf.Clamp(tp.x, -x, x),
                Mathf.Clamp(tp.y, -y, y),
                Mathf.Clamp(tp.z, (float)-z, (float)z)
            );
            transform.position = coords;
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

        public static void ReloadScene(string name)
        {
            SceneManager.LoadScene(
                name != null ? name : SceneManager.GetActiveScene().name);
        }
    }

    // public class TestException : System.Exception
    // {
    //     public TestException(string exceptMsg = null) : base(exceptMsg) { }
    // }
}
