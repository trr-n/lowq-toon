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

        [SerializeField]
        UnityEvent onClear;

        [SerializeField]
        UnityEvent onFail;

        [SerializeField, Tooltip("制限時間")]
        float limit = 90;

        [SerializeField, Tooltip("フェードアウトの速度")]
        float fading = 10;

        float alpha;
        float remaining;
        public float Remaining => remaining;

        /// <summary>対象がすべて壊されたらtrue</summary>
        bool isTerminated = false;

        bool controllable;
        public bool Controllable { get => controllable; set => controllable = value; }

        void Start()
        {
            RenderSettings.skybox = skybox;

            remaining = limit;

            SetGravity();
            StartCoroutine(RemainTime());
        }

        void AddEvent()
        {
            onFail?.AddListener(Fading);
            onClear?.AddListener(Fading);
        }

        void Update()
        {
            c status;
#if UNITY_EDITOR
            status = c.show;
#else
            status = c.hide;
#endif
            visual.cursor(status);

            LDJudge();
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

        void ChangeClearScene() => scene.load(constant.Clear);
        void ChangeFailScene() => scene.load(constant.Fail);

        IEnumerator RemainTime()
        {
            while (true)
            {
                remaining -= 1;
                yield return new WaitForSeconds(1f);
            }
        }

        // life/death judgement
        void LDJudge()
        {
            // 制限時間内にミッションを終わらせたらクリア判定
            // if (isTerminated && remaining >= 0)
            {
                onClear.Invoke();
            }
            if (remaining <= limit)
            {
                onFail.Invoke();
            }
        }

        public void Fading()
        {
            alpha = alpha.clamping(0, 1f);
            alpha += Time.deltaTime / fading;
            fadingPanel.color = new(0, 0, 0, alpha);
            if (fadingPanel.color.a >= 1)
            {
                scene.load(constant.Fail);
            }
        }
    }
}
