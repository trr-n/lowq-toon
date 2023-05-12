using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;
using DG.Tweening;

namespace Toon
{
    public class ExtensionsTest : MonoBehaviour
    {
        void Start()
        {
            gameObject.SetPosition(new(-5, 0, 0));
            transform.SetPositionX(-5);

            // dotween
            // var s = DOTween.Sequence();
            // s.Append(transform.DOMove(new(5, 0, 0), 5).SetEase(Ease.InCubic));
            // s.Append(transform.DOMove(new(-5, 0, 0), 5).SetEase(Ease.OutCubic));
            // s.Play();

            transform.MoveTo(new(5, 0, 0), 3);
        }
    }
}
