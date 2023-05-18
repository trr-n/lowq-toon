using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon.Extend;

namespace Toon
{
    public class Manager : MonoBehaviour
    {
        [SerializeField] Material skybox;
        [SerializeField][Tooltip("制限時間")] float init = 90;

        float remaining;
        public float Remaining => remaining;
        bool isCompleted = false;
        /// <summary>flag: game clear</summary>
        public bool IsCompleted => isCompleted;
        bool isDestroyed = false;

        float n = 0.1f;

        void Start()
        {
            // set skybox
#if UNITY_EDITOR
            RenderSettings.skybox = null;
#else
            RenderSettings.skybox = skybox;
#endif

            // set init time for remaining
            remaining = init;
        }

        void Update()
        {
            // current scene reloading when ur pressed 'keyCode' 
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // scene.load(scene.active());
            }
#endif

            // hide cursor
            c status;
#if UNITY_EDITOR
            status = c.show;
#else
            status = c.hide;
#endif
            visual.cursor(status);

            // set gravity
            SetGravity();

            n = n.clamping(0, 1);
            // ("n3: " + inc3(0.1f)).show();
            (n += Time.deltaTime / 10).show(); // OK
        }

        void SetGravity()
        {
            if (scene.active() == constant.Title)
            {
                Physics.gravity = new(0, 0, 0);
            }

            else if (scene.active() == constant.Main)
            {
                Physics.gravity = constant.MainGravity;
            }
        }

        void RemainTime() => remaining -= Time.deltaTime;

        void Clear()
        {
            // todo 制限時間内にステージ内のオブジェクトをすべて破壊したら isClear = true
            if (remaining >= 0.1f && isDestroyed)
            {
                isCompleted = true;
            }
        }

        float n1 = 0, n2 = 0, n3 = 0;
        public float inc1(float inc)
        {
            while (n1 <= 10)
            {
                n1 += inc * Time.deltaTime;
            }
            return n1;
        }
        public float inc2(float inc) => n2 += inc;
        public float inc3(float inc) => Mathf.Lerp(0, 1f, inc += Time.deltaTime);

        // todo fix: アルファ値が増えない
        public void Fading(Image image, float speed)
        {
            float alpha = 0;
            while (alpha <= 1)
            {
                alpha += speed;
            }
            alpha.show();
            // image.color = new(0, 0, 0, Mathf.Lerp(0f, 1f, speed));
            image.color = new(0, 0, 0, alpha);
            if (image.color.a >= 1)
            {
                scene.load(constant.Over);
            }
        }

    }
}
