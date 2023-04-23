using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deb : MonoBehaviour
{
    [SerializeField]
    Text t;
    [SerializeField]
    PlayerMovement player;

    void Update()
    {
        t.text = player.IsMoving.ToString();
    }
}
