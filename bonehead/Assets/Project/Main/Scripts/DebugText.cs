using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    [SerializeField] GameObject p;
    Player player;
    [SerializeField]
    Text txt;
    void Start()
    {
        txt = GetComponent<Text>();
        player = p.GetComponent<Player>();
    }

    void Update()
    {
        txt.text = @$"camera: {player.Cam.transform.position}
        player: {player.Self.transform.position}";
    }
}
