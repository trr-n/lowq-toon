using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Toon;

namespace Toon.Debug
{
    public class DebugPlayerFrags : MonoBehaviour
    {
        [SerializeField]
        Text t;

        PlayerInput pi;

        void Start()
        {
            pi = GameObject.FindGameObjectWithTag(Const.Player).GetComponent<PlayerInput>();
        }

        void Update()
        {
            t.text = $"Shootable: {pi.Shootable}, IsRotating: {pi.IsRotating}";
        }
    }
}