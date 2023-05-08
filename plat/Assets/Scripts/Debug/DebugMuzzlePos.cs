using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameTitle.Debug
{
    public class DebugMuzzlePos : MonoBehaviour
    {
        [SerializeField]
        GameObject player, muzzle;
        [SerializeField]
        Text t;

        void Update()
        {
            t.text = @$"player: {player.transform.position}, muzzle: {muzzle.transform.position}
        diff: {Vector3.Distance(player.transform.position, muzzle.transform.position)}";
        }
    }
}
