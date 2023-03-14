using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mine;

public class Player : MonoBehaviour
{
    class Value
    {
        public float moveSpeed = 5;
        // public float jumpPower = 1;
        // public Vector3 jumpDirection = Vector3.up;

        public Value(float moveSpeed) { this.moveSpeed = moveSpeed; }
    }

    // public class Self
    // {
    //     public GameObject obj;
    //     public Vector3 position;
    //     public Rigidbody rb;

    //     public Self(GameObject obj, Vector3 position)
    //     {
    //         this.obj = obj;
    //         this.position = position;
    //     }

    //     public Self(Rigidbody rb) { this.rb = rb; }
    // }

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
        GetStart();
    }

    void GetStart()
    {
        camera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        selfRb = this.gameObject.GetComponent<Rigidbody>();

        value = new(moveSpeed: 5);
    }

    void Update()
    {
        GetUpdate();

        self.transform.Translate(Movement.Move(additional: value.moveSpeed));
    }

    void GetUpdate()
    {
        cameraPos = camera.transform.position;

        self = this.gameObject;
        selfPos = this.gameObject.transform.position;
    }

    class Camera //: Player
    {
        public Vector3 Pos(Vector3 basePos, float shift) =>
            new(basePos.x, basePos.y, basePos.z + shift);
    }

    class Movement
    {
        //* static にしないと動かない
        public static Vector3 Move(float additional)
        {
            Vector3 move = new(Input.GetAxis(Mine.Keys.Horizontal), 0, 0);
            return additional * Time.deltaTime * move;
        }

        public static void Jump(Vector3 direction, float power)
        {
            selfRb.AddForce(direction * power, ForceMode.Impulse);
        }
    }
}