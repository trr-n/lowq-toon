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
        [Tooltip("フェードアウトの速度")]
        float fading = 3;

        [SerializeField]
        HP towerHp;

        [SerializeField]
        HP playerHp;

        [SerializeField]
        c state = c.show;

        float alpha;
        float remaining;
        public float Remaining => remaining;

        public float RemainRatio => remaining / limit;

        /// <summary>対象がすべて壊されたらtrue</summary>
        bool doneTheEnd = false;
        bool notDownTheEnd = false;

        public bool Controllable { get; set; }

        void Start()
        {
            RenderSettings.skybox = null; // skybox;

            remaining = limit;
            

            SetGravity();
            StartCoroutine(RemainTime());
            AddEvent();
        }

        void AddEvent()
        {
            onClear?.AddListener(Fading);
            onFail?.AddListener(Failing);
        }

        void Update()
        {
            visual.cursor(state);

            LDJudge();

            // タワーのHPが0以下で残り時間が0じゃなかったらクリア判定
            notDownTheEnd = !towerHp.IsZero() && remaining <= 0;

            // ("Player isZero: " + playerHp.IsZero()).show();
            // ("Tower isZero: " + towerHp.IsZero()).show();
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

        public void ChangeScene(string name) => scene.load(name);

        IEnumerator RemainTime()
        {
            while (true)
            {
                remaining -= 1;
                yield return new WaitForSeconds(1f);
            }
        }

        void LDJudge()
        {
            // 制限時間内に終わらせたらクリア
            if (towerHp.IsZero() && remaining >= 0)
            {
                onClear.Invoke();
            }

            // 時間内にやれなかったらアウト
            else if (notDownTheEnd)
            {
                onFail.Invoke();
            }
        }

        public void Fading() => AddAlpha(constant.Title);

        public void Failing() => AddAlpha(constant.Failure);

        void AddAlpha(string name)
        {
            alpha = alpha.clamping(0, 1f);
            alpha += Time.deltaTime / fading;
            fadingPanel.color = new(0, 0, 0, alpha);
            if (fadingPanel.color.a >= 1)
            {
                scene.load(name);
            }
        }
    }
}
