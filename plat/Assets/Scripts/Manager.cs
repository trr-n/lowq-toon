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

        [SerializeField]
        [Tooltip("制限時間")]
        float limit = 90;

        [SerializeField]
        [Tooltip("パネルのフェードアウトの速度")]
        float fading = 3;

        [SerializeField]
        HP towerHp;

        [SerializeField]
        HP playerHp;

        float timer;

        float alpha;
        float finishedRemainingTime = 0;
        /// <summary>クリア時の残り時間</summary>
        public float FinishedRemainingTime => finishedRemainingTime;

        float remaining;
        public float Remaining => remaining;
        public float RemainRatio => remaining / limit;

        public bool TimerStart { get; set; }

        /// <summary>対象がすべて壊されたらtrue</summary>
        bool doneTheEnd = false;
        bool notDownTheEnd = false;

        public bool Controllable { get; set; }

        void Start()
        {
            RenderSettings.skybox = null; // skybox;
            remaining = limit;
            TimerStart = false;

            SetGravity();
            // StartCoroutine(RemainTime(TimerStart));

            onClear?.AddListener(Fading);
            onFail?.AddListener(Failing);
        }

        void Update()
        {
            LDJudge();
            RemainTime2(TimerStart);
        }

        void SetGravity()
        {
            Physics.gravity = constant.MainGravity;
        }

        public void ChangeScene(string name) => scene.load(name);

        IEnumerator RemainTime(bool timerStart)
        {
            while (timerStart)
            {
                remaining -= 1;
                yield return new WaitForSeconds(1f);
            }
        }

        void RemainTime2(bool timerStart)
        {
            timer += Time.deltaTime;
            while (timerStart && timer >= 1)
            {
                remaining -= 1;
                timer = 0;
            }
        }

        void LDJudge()
        {
            doneTheEnd = towerHp.IsZero() && remaining >= 0;
            notDownTheEnd = !towerHp.IsZero() && remaining <= 0;

            // 制限時間内に終わらせたらクリア
            if (doneTheEnd)
            {
                onClear.Invoke();
            }

            // 時間内にやれなかったらアウト
            else if (notDownTheEnd)
            {
                onFail.Invoke();
            }

            // タイマー止めて記録をメモ
            if (doneTheEnd || notDownTheEnd)
            {
                TimerStart = false;
                finishedRemainingTime = remaining;
            }
        }

        public void Fading() => AddAlpha(constant.Clear);

        public void Failing() => AddAlpha(constant.Failure);

        void AddAlpha(string name)
        {
            alpha = numeric.clamp(alpha, 0, 1f);
            alpha += Time.deltaTime / fading;
            fadingPanel.color = new(0, 0, 0, alpha);
            if (fadingPanel.color.a >= 1)
            {
                "scene loading".show();
                scene.load(name);
            }
        }
    }
}
