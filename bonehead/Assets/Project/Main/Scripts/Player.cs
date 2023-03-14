using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mine;

public class Player : MonoBehaviour
{
    public class Value
    {
        public float moveSpeed = 5;
        public float jumpPower = 1;
        public Vector3 jumpDirection = Vector3.up;

        public Value(float moveSpeed, float jumpPower, Vector3 jumpDirection)
        {
            this.moveSpeed = moveSpeed;
            this.jumpPower = jumpPower;
            this.jumpDirection = jumpDirection;
        }
    }

    /*
    public class Self
    {
        public GameObject obj;
        public Vector3 position;
        public Rigidbody rb;

        public Self(GameObject obj, Vector3 position, Rigidbody rb)
        {
            this.obj = obj;
            this.position = position;
            this.rb = rb;
        }
    }
    */

    Player.Value value;
    // Player.Cam cam;
    // Player.Self self;
    Player.Movement movement;

    new GameObject camera;
    Vector3 cameraPos;
    float cameraShift = 0.5f;

    GameObject self;
    Vector3 selfPos;
    static Rigidbody selfRb;

    void Start()
    {
        GetInit();
    }

    void Update()
    {
        // movement.Move(self: self.transform, addition: value.moveSpeed);
    }

    void GetInit()
    {
        camera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        cameraPos = camera.transform.position;

        self = this.gameObject;
        selfPos = this.gameObject.transform.position;
        selfRb = this.gameObject.GetComponent<Rigidbody>();

        value = new(
            moveSpeed: 5,
            jumpPower: 5, jumpDirection: Vector3.up
        );

        // self = new(
        //     obj: this.gameObject,
        //     position: this.gameObject.transform.position,
        //     rb: this.gameObject.GetComponent<Rigidbody>()
        // );

        // movement = new(
        //     addition: value.moveSpeed,
        //     transform: self.obj.transform,
        //     power: value.jumpPower,
        //     direction: value.jumpDirection
        // );

        // obj = this.gameObject;
        // position = this.gameObject.transform.position;
        // rb = this.gameObject.GetComponent<Rigidbody>();
    }

    class Camera //: Player
    {
        // Vector3 basePos;
        // float shift;

        // public Camera(Vector3 basePos, float shift)
        // {
        //     this.basePos = basePos;
        //     this.shift = shift;
        // }

        public Vector3 Pos(Vector3 basePos, float shift)
        => new(basePos.x, basePos.y, basePos.z + shift);
    }

    class Movement //: Player
    {
        // Self self;

        // float addition;
        // Transform transform;

        // float power;
        // Vector3 direction;

        // public Movement(
        //     float addition, Transform transform,
        //     float power, Vector3 direction)
        // {
        //     this.addition = addition;
        //     this.transform = transform;

        //     this.power = power;
        //     this.direction = direction;
        // }

        public void Move(Transform self, float addition)
        {
            float x = Input.GetAxis(Mine.Keys.Horizontal);
            Vector3 horMove = new(x, 0, 0);
            self.Translate(horMove * addition);
        }

        public void Jump(Vector3 direction, float power)
        {
            if (Input.GetButton(Mine.Keys.Jump))
            {
                selfRb.AddForce(direction * power, ForceMode.Impulse);
            }
        }
    }
}