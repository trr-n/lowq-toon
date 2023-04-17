using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    class V
    {
        // move
        public float basis;
        public V(float basis)
        {
            this.basis = basis;
        }

        // jump
        public float power;
        public V(float power, float _ = 1)
        {
            this.power = power;
        }
    }

    GameObject self;
    Rigidbody rb;
    GameObject playerCamera;

    CameraMovement caMove;
    Gun gun;

    V m, j;

    Vector3 initPos = new(0, 70, 0);

    Vector3 selfPos;

    // jumping related
    /// <summary>spacebar state</summary>
    bool isPressed = false;

    void Start()
    {
        GetStart();

        Initial(initPos);
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
        selfPos = this.gameObject.transform.position;

        m = new(basis: 200);
        j = new(power: 500);

        rb = this.gameObject.GetComponent<Rigidbody>();
        playerCamera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        caMove = GetComponent<CameraMovement>();
    }

    void Update()
    {
        Moves(m.basis);
        Jumps(j.power);

        Shooting();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="position">初期座標</param>
    void Initial(Vector3 position) => self.transform.position = position;

    /// <summary>
    /// 歩き
    /// </summary>
    /// <param name="basis">基本の移動速度</param>
    void Moves(float basis)
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        Vector3 hv = new(h, 0, v);
        self.transform.Translate(hv * basis * Time.deltaTime);
    }

    void Jumps(float power)
    {
        if (isPressed && Input.GetButton(Mine.Keys.Jump))
        {
            rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// 連射用タイマー
    /// </summary>
    float timer = 0;

    void Shooting()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            gun.Firing(
                dir: transform.right,
                shootable: true
            );
        }

        if (Input.GetKeyDown(KeyCode.R))
            gun.Reload();
    }
}
