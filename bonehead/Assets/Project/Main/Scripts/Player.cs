using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    new GameObject camera;
    Vector3 cameraPos;

    GameObject self;
    Vector3 selfPos;
    static Rigidbody selfRb;

    // Movement movement;
    // Camera camera;

    void Start()
    {
        Get();
    }

    void Update()
    {
        // { #0ff }
        camera.transform.Translate(
            Camera.Pos(camera.transform.position, gap: .5f));

        // { #fff }
        self.transform.Translate(Movement.Move(addition: 5));
        // Movement.Jump(power: 5);

    }

    void Get()
    {
        // { #0ff }
        camera = GameObject.FindGameObjectWithTag(MyApp.Tags.CAM);
        cameraPos = camera.transform.position;

        // { #fff }
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

        public void Jump(float power)
        {
            if (Input.GetButton(MyApp.Keys.JUMP))
                selfRb.AddForce(Vector3.up * power, ForceMode.Impulse);
        }
    }
}