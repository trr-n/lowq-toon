using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon.Extend;
using DG.Tweening;

namespace Toon
{
    public class BossCamera : MonoBehaviour
    {
        [SerializeField]
        Manager manager;

        [SerializeField]
        Camera boss;

        [SerializeField]
        Camera main;

        bool isMoving = false;
        public bool IsMoving => isMoving;
        Vector3 firstPos = new(-1.95f, 2.66f, 0.85f);
        Quaternion firstRot = Quaternion.Euler(18.5f, 90, 0);
        Vector3 lookAtTower = new(339.53f, 133.42f, 358f);
        float showTimer = 0;

        void Start()
        {
            isMoving = false;
            transform.SetPositionAndRotation(firstPos, firstRot);
            main.depth = 0;
            boss.depth = -1;
        }

        bool once = true;
        bool once1 = true;
        void Update()
        {
            if (Mathf.Approximately(transform.eulerAngles.z, lookAtTower.z) && once)
            {
                StartCoroutine(Timer());
                print(true);
                once = false;
            }

            if (showTimer >= 2 && once1)
            {
                isMoving = false;
                main.depth = 0;
                boss.depth = -1;
                manager.Controllable = true;
                manager.TimerStart = true;
                once1 = false;
            }
        }

        IEnumerator Timer()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                showTimer++;
            }
        }

        public void BossCameraMove(float duration, Text text)
        {
            isMoving = true;
            text.text = null;
            main.depth = -1;
            boss.depth = 0;
            manager.Controllable = false;
            transform.DORotate(lookAtTower, duration);
        }
    }
}
