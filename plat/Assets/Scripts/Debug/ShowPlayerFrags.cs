using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameTitle.Debug
{
    public class ShowPlayerFrags : MonoBehaviour
    {
        [SerializeField]
        Text t;

        PlayerInput pi;

        void Start()
        {
            pi = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerInput>();
        }

        void Update()
        {
            t.text = $"Shootable: {pi.Shootable}, IsRotating: {pi.IsRotating}";
        }
    }
}