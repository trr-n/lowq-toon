using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deb : MonoBehaviour
{
    [SerializeField]
    Text t;
    [SerializeField]
    CameraMovement cam;
    [SerializeField]
    PlayerMovement player;

    void Update()
    {
        t.text = @$"player: {player.transform.rotation}
        camera: {cam.transform.rotation}".ToString();
    }
}
