using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // {#fff}
    public class Temp
    {
        public static float JumpingPower = 1;
        public static Vector3 JumpingDirection = Vector3.up;
        //
        public static float MovingSpeed = 20f;
    }


    new GameObject camera;
    Vector3 cameraPos;

    GameObject self;
    Vector3 selfPos;
    static Rigidbody selfRb;

    /*
    Movement movement;
    Camera camera;
    */

    void Start()
    {
        Get();
    }

    void Update()
    {
        print(Temp.JumpingPower);

        camera.transform.Translate(
            Camera.Pos(camera.transform.position, gap: .5f));

        // Move
        self.transform.Translate(Movement.Move(addition: 5));

        // Jump
        Movement.Jump(power: 5, direction: Vector3.up);
        // selfRb.AddForce();

    }

    void Get()
    {
        camera = GameObject.FindGameObjectWithTag(MyApp.Tags.CAM);
        cameraPos = camera.transform.position;

        selfPos = gameObject.transform.position;
        self = gameObject;
        selfRb = gameObject.GetComponent<Rigidbody>();
    }

    class Camera //: Player
    {
        public static Vector3 Pos(Vector3 basePos, float gap)
        => new(basePos.x, basePos.y, basePos.z + gap);
    }

    class Movement //: MonoBehaviour
    {
        public static Vector3 Move(float addition)
        {
            float h = Input.GetAxis(MyApp.Keys.HORIZONTAL);
            Vector3 widen = new(h, 0, 0);
            return widen * addition;
        }

        public static void Jump(float power, Vector3 direction)
        {
            if (Input.GetButton(MyApp.Keys.JUMP))
                selfRb.AddForce(direction * power, ForceMode.Impulse);
        }
    }
}