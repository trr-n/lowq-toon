using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    [SerializeField] GameObject p;
    PlayerMovement player;
    [SerializeField]
    Text txt;

    void Start()
    {
        player = p.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        txt.text = $"player: {player.transform.position}";
    }
}
