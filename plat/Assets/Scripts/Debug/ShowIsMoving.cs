using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameTitle.Debug
{
    public class ShowIsMoving : MonoBehaviour
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
