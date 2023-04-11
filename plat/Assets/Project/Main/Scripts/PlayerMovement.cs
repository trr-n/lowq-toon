using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    class Init
    {
        public static Vector3 Pos = new(0, 70, 0);
    }

    class V
    {
        // move
        public float basis;
        public float sneak;
        public V(float basis, float sneak)
        {
            this.basis = basis;
            this.sneak = sneak;
        }

        // jump
        public float power;
        public V(float power)
        {
            this.power = power;
        }
    }

    GameObject self;
    Rigidbody rb;

    V m, j;

    static Transform now;
    public static Transform Now => now;

    // spacebar state
    bool isPressed = false;

    void Start()
    {
        GetStart();

        Initialize(position: Init.Pos);
    }

    // async Task<int> test()
    // {
    //     print(0);
    //     await Task.Delay(2000);
    //     print(1);
    //     return 0;
    // }

    void GetStart()
    {
        self = this.gameObject;

        m = new(basis: 20, sneak: 10);
        j = new(power: 500);

        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        now = this.transform;

        Moves(m.basis, m.sneak);
        Jumps(j.power);
    }

    void Initialize(Vector3 position) => self.transform.position = position;

    void Moves(float basis, float sneak)
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        Vector3 hv = new(h, 0, v);
        float add = basis;
        if (Input.GetKeyDown(KeyCode.LeftShift)) { add = sneak; }
        else { add = basis; }
        self.transform.Translate(hv * add * Time.deltaTime);
    }

    // void Jumps(float power)
    // {
    //     float charging = 0;
    //     if (Input.GetButton(Mine.Keys.Jump))
    //         charging++;
    //     else if (Input.GetButtonUp(Mine.Keys.Jump))
    //     {
    //         rb.AddForce(Vector3.up * charging, ForceMode.Impulse);
    //         charging = 0;
    //     }
    // }

    void Jumps(float power)
    {
        float charging = 0;
        print(charging);
        Mathf.Clamp(charging, 20, 600);
        if (isPressed && Input.GetButtonDown(Mine.Keys.Jump)) return;
        if (isPressed && Input.GetButton(Mine.Keys.Jump)) charging++;
        if (isPressed && Input.GetButtonUp(Mine.Keys.Jump))
            rb.AddForce(Vector3.up * charging, ForceMode.Impulse);
        charging = 0;
    }
}
