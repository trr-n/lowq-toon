using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static GameObject camObj;
    static Vector3 self;
    static Rigidbody rb;

    new Player.Camera camera;
    Movement move;

    void Start()
    {
        Get();
    }

    void Update()
    {
        camera.Pos(gap: .5f);
        // move.Move(addition: 5);
        // move.Jump(power: 5);
    }

    void Get()
    {
        camObj = GameObject.FindGameObjectWithTag(MyApp.Tags.CAM);
        self = this.gameObject.transform.position;
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    class Camera : Player
    {
        new GameObject camObj;

        public void Pos(float gap)
        {
            Vector3 camPos = camObj.transform.position;
            camPos = new(self.x, self.y, self.z + gap);
            transform.Translate(camPos);
        }
    }

    class Movement : Player
    {
        public void Move(float addition)
        {
            float h = Input.GetAxis(MyApp.Keys.HORIZONTAL);
            Vector3 widen = new(h, 0, 0);
            transform.Translate(widen * addition);
        }

        public void Jump(float power)
        {
            if (Input.GetButton(MyApp.Keys.JUMP))
            {
                rb.AddForce(Vector3.up * power, ForceMode.Impulse);
            }
        }
    }
}