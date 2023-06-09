using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon
{
    public class Destruct : MonoBehaviour
    {
        [Tooltip("破壊までの時間")]
        [SerializeField]
        float life = 10;

        void Start()
        {
            Destroy(this.gameObject, life);
        }
    }
}
