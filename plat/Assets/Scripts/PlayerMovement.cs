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
        public float reduction;
        public V(float basis, float reduction)
        {
            this.basis = basis;
            this.reduction = reduction;
        }

        // jump
        public float power;
        public V(float power)
        {
            this.power = power;
        }
    }

    GameObject self;
    GameObject playerCamera;
    Rigidbody rb;
    CameraMovement caMove;
    Quaternion q;

    V m, j;

    Vector3 initPos = new(0, 70, 0);
    Vector3 selfPos;

    bool isMoving = false;
    /// <summary>
    /// 移動中か
    /// </summary>
    public bool IsMoving => isMoving;

    bool isFloating = false;
    /// <summary>
    /// 地に足がついているか
    /// </summary>
    public bool IsFloating => isFloating;

    /// <summary>
    /// プレイヤーの回転速度
    /// </summary>
    float rotSpeed = 10;

    float velocity;
    /// <summary>
    /// 移動速度
    /// </summary>
    public float Velocity => velocity;

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

        m = new(basis: 500, reduction: 0.5f);
        j = new(power: 500);

        q = new();

        rb = this.gameObject.GetComponent<Rigidbody>();
        playerCamera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        caMove = playerCamera.GetComponent<CameraMovement>();

    }

    void FixedUpdate()
    {
        Moves(m.basis, m.reduction);
        // Jumps(j.power);
    }

    void Initial(Vector3 position) => self.transform.position = position;

    /// <summary>
    /// プレイヤーの移動、回転処理
    /// </summary>
    /// <param name="basis">基本の移動速度</param>
    /// <param name="reductionRatio">減速の倍率</param>
    void Moves(float basis, float reductionRatio)
    {
        float h = Input.GetAxisRaw("Horizontal"), v = Input.GetAxisRaw("Vertical");
        // カメラの向きを起点に前後左右に動く
        Vector3 hv = h * playerCamera.transform.right + v * playerCamera.transform.forward;
        hv.y = 0.0f;
        velocity = hv.magnitude;
        isMoving = velocity > .01f;
        if (!isMoving)
        {
            rb.velocity *= reductionRatio;
            return;
        }
        // self.transform.position += hv.normalized * basis * Time.deltaTime;
        rb.velocity += hv * basis * Time.deltaTime;

        q.SetLookRotation(view: hv, up: Vector3.up);
        self.transform.rotation = Quaternion.Lerp(
            transform.rotation, q, rotSpeed * Time.deltaTime);
    }

    void Jumps(float power)
    {
        if (Input.GetButton(Mine.Keys.Jump))
        {
            rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        }
    }
}