using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static GameObject cam;

    static Vector3 self;

    void Start()
    {
        Get();
    }

    void Update()
    {
        Camera.Moves();
    }

    void Get()
    {
        cam = GameObject.FindGameObjectWithTag(App.Name.Tags.MAINCAMERA);
        self = this.gameObject.transform.position;
    }

    class Camera : Player
    {
        public static void Moves()
        {
            var camPos = cam.transform.position;
            Debug.Log(camPos);
            Debug.Log(self);
        }
    }


}