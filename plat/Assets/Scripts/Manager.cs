using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Toon.Extend;

namespace Toon
{
    public class Manager : MonoBehaviour
    {
        [SerializeField]
        Material skybox;
        [SerializeField]
        Image fadingPanel;

        [SerializeField, Tooltip("制限時間")]
        float init = 90;
        [SerializeField, Tooltip("フェードアウトの速度")]
        float fading = 10;
        [SerializeField]
        float limit;

        [SerializeField]
        UnityEvent onClear;

        [SerializeField]
        UnityEvent onFail;

        float alpha;
        float remaining;
        public float Remaining => remaining;
        bool terminated = false;

        void Start()
        {
            // set skybox
            RenderSettings.skybox = skybox;

            // set init time for remaining
            remaining = init;

            // set gravity
            SetGravity();

            StartCoroutine(RemainTime());
        }

        void Update()
        {
            // hide cursor
            c status;
#if UNITY_EDITOR
            status = c.show;
#else
            status = c.hide;
#endif
            visual.cursor(status);

            GameManage();
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


        IEnumerator RemainTime()
        {
            while (true)
            {
                remaining.show();
                remaining -= 1;
                yield return new WaitForSeconds(1f);
            }
        }

        void GameManage()
        {
            // 制限時間内にミッションを終わらせたらクリア判定
            if (terminated && remaining >= 0)
            {
                onClear.Invoke();
            }
            else if (remaining >= limit)
            {
                onFail.Invoke();
            }
        }

        public void Fading()
        {
            alpha = alpha.clamping(0, 1f);
            alpha += Time.deltaTime / fading;
            alpha.show();
            fadingPanel.color = new(0, 0, 0, alpha);
            if (fadingPanel.color.a >= 1)
            {
                scene.load(constant.GameOver);
            }
        }
    }
}
