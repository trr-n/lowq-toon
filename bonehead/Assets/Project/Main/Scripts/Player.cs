using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Mine;

public class Player : MonoBehaviour
{
    class V
    {
        public float h;
        public float v;
        public float power;
        public Vector3 direction;
        public float shift;

#nullable enable
        public V(float h, float v, float power, Vector3 direction, float shift)
        {
            this.h = h;
            this.v = v;
            this.power = power;
            this.direction = direction;
            this.shift = shift;
        }
    }
#nullable disable

    // class Self
    // {
    //     public GameObject obj;
    //     public Vector3 position;
    //     public static Rigidbody rb;

    //     // public Self(GameObject obj, Rigidbody rb)
    //     // {
    //     //     this.obj = obj;
    //     //     this.rb = rb;
    //     // }
    //     // public Self(Vector3 position) { this.position = position; }
    // }

    // class Cam
    // {
    //     public GameObject obj;
    //     public Vector3 position;
    //     public float shift;
    // }

    // Player.Cam cam;
    // Player.Self self;
    Player.Movement movement;
    Player.V hoge;

    new GameObject camera;
    Vector3 cameraPos;

    GameObject self;
    Vector3 selfPos;
    static Rigidbody selfRb;

    public GameObject Cam => camera;
    public GameObject Self => self;

    void Start()
    {
        Settings();
    }

    void Update()
    {
        Sum();

        self.transform.Translate(Movement.Move(
            hWalk: hoge.h, vWalk: hoge.v,
            hRun: null, vRun: null));

        camera.transform.position = Camera.Pos(
            playerPos: selfPos, x: selfPos.x, y: selfPos.y, z: hoge.shift);
    }

    void Settings()
    {
        camera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        selfRb = this.gameObject.GetComponent<Rigidbody>();
        hoge = new(h: 5, v: 4, power: 5, direction: Vector3.up, shift: 0.5f);
    }

    void Sum()
    {
        cameraPos = camera.transform.position;
        self = this.gameObject;
        selfPos = self.transform.position;
    }

    class Camera //: Player
    {
        public static Vector3 Pos(Vector3 playerPos, float x, float y, float z)
        => new(playerPos.x + x, playerPos.y + y, playerPos.z + z);
    }

    class Movement
    {
        public static Vector3 Move(float hWalk, float vWalk, float? hRun, float? vRun)
        {
            Vector3 move = new(
                Input.GetAxis(Mine.Keys.Horizontal) * hWalk,
                0,
                Input.GetAxis(Mine.Keys.Vertical) * vWalk
            );
            return Time.deltaTime * move;
        }

        public static void Jump(Vector3 direction, float power)
        => selfRb.AddForce(direction * power, ForceMode.Impulse);
    }
}