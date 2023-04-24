using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deb2 : MonoBehaviour
{
    [SerializeField]
    GameObject player, camera;
    [SerializeField]
    Text t;

    void Update()
    {
        t.text = @$"player: {player.transform.rotation}
            camera: {camera.transform.rotation}";
    }
}
