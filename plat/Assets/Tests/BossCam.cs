using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;
using DG.Tweening;

namespace Toon.Test
{
    public class BossCam : MonoBehaviour
    {
        Vector3 initRot = Vector3.zero;
        Vector3 targetRot = new(90.11f, 0, 0);

        bool rotFlag = false;

        void Start()
        {
            transform.rotation = Quaternion.Euler(initRot);

            transform.DORotate(targetRot, 4); //.SetEase(Ease.OutCubic);
        }

        bool once = false;
        void Update()
        {
            $"{transform.eulerAngles.x}".show();

            if (targetRot.x.AlmostSame(transform.eulerAngles.x) && !once)
            {
                "finished".show();

                once = true;
            }
        }
    }
}
