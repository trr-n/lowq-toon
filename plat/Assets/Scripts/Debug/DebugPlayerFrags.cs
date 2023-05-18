using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon;

namespace Toon.Test
{
    public class DebugPlayerFrags : MonoBehaviour
    {
        [SerializeField]
        Text t;

        PlayerInput pi;

        void Start()
        {
            pi = GameObject.FindGameObjectWithTag(constant.Player).GetComponent<PlayerInput>();
        }

        void Update()
        {
            t.text = $"Shootable: {pi.shootable}, IsRotating: {pi.isRotating}";
        }
    }
}