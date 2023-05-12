using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Toon.Debug
{
    public class DebugIsMoving : MonoBehaviour
    {
        [SerializeField]
        Text t;
        [SerializeField]
        PlayerMovement player;

        void Update()
        {
            t.text = @$"{player.IsMoving.ToString()}";
        }
    }
}
