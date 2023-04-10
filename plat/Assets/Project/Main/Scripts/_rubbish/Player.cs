using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    class Value
    {
        public float hor;
        public float ver;
        public float power;
        public Vector3 direction;

        public Value(float h, float v, float pow, Vector3 dir)
        {
            this.hor = h;
            this.ver = v;
            this.power = pow;
            this.direction = dir;
        }
        // #nullable disable
    }

    Player.Movement movement;
    Player.Value v;

    new GameObject camera;
    Vector3 cameraPos;

    GameObject self;
    Vector3 selfPos;
    static Rigidbody selfRb;

    // Global
    public GameObject Cam => camera;
    public GameObject Self => self;

    void Settings()
    {
        camera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        selfRb = this.gameObject.GetComponent<Rigidbody>();

        v = new(
            // Move
            h: 1,
            v: .8f,

            // Jump
            pow: 5,
            dir: Vector3.up
        );
    }

    void Start() => Settings();

    void Update()
    {
        Sum();

        self.transform.Translate(
            Movement.Move(hWalk: v.hor, vWalk: v.ver, hRun: null, vRun: null));
        Movement.Jump(direction: Vector3.up, power: v.power);

        // camera.transform.position = Camera.Pos(
        //     playerPos: selfPos, x: selfPos.x, y: selfPos.y, z: selfPos.z);
    }

    void Sum()
    {
        self = this.gameObject;
        selfPos = self.transform.position;
        cameraPos = camera.transform.position;
    }

    class Camera
    {
        public static Vector3 Pos(Vector3 playerPos, float x, float y, float z)
        => new(playerPos.x + x, playerPos.y + y, playerPos.z + z);

        public static Vector3 Rot(float x, float y, float z)
        => new();
    }

    class Movement
    {
        public static Vector3 Move(float hWalk, float vWalk, float? hRun, float? vRun)
        {
            Vector3 move = new(
                Input.GetAxis(Mine.Keys.Hor) * hWalk,
                0,
                Input.GetAxis(Mine.Keys.Ver) * vWalk
            );
            return Time.deltaTime * move;
        }
        public static Vector3 Mov()
        {
            return new();
        }

        public static void Jump(Vector3 direction, float power)
        {
            if (Input.GetButtonDown(Mine.Keys.Jump))
                selfRb.AddForce(direction * power, ForceMode.Impulse);
        }
    }
}