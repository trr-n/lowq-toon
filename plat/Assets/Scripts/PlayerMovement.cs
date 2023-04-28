using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Serializable]
    class V
    {
        public float basis = 15;
        public float reduction = 0.5f;
        public float power = 200;
        public float rotation = 10;
        public float rotation4move = 10;

        public V(float _basis, float _reduction, float _power, float _rotation, float _rotation4move)
        {
            basis = _basis;
            reduction = _reduction;
            power = _power;
            rotation = _rotation;
            rotation4move = _rotation4move;
        }
    }

    [SerializeField]
    new GameObject camera;

    Rigidbody rb;
    CameraMovement cameraMovement;
    Quaternion q;
    GameManager gameManager;

    [SerializeField]
    V vv;

    PlayerInput playerInput;

    bool isMoving = false;
    /// <summary>
    /// 動いていたら(移動キーが押されたら)true
    /// </summary>
    public bool IsMoving => isMoving;

    bool isFloating = false;
    /// <summary>
    /// プレイヤーが空中にいたらtrue
    /// </summary>
    public bool IsFloating => isFloating;

    float velocity;
    /// <summary>
    /// プレイヤーの移動速度
    /// </summary>
    public float Velocity => velocity;

    // async Task<int> test()
    // {
    //     print(0);
    //     await Task.Delay(2000);
    //     print(1);
    //     return 0;
    // }

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        camera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        cameraMovement = camera.GetComponent<CameraMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        Moves(vv.basis, vv.reduction, vv.rotation4move);
    }

    void Update()
    {
        Jumps(vv.power);
        Rotate(vv.rotation);
    }

    /// <summary>
    /// プレイヤーの移動、回転処理
    /// </summary>
    /// <param name="basis">基本の移動速度</param>
    /// <param name="reductionRatio">減速比</param>
    void Moves(float basis, float reductionRatio, float rotSpeed)
    {
        float h = Input.GetAxisRaw("Horizontal"), v = Input.GetAxisRaw("Vertical");
        // カメラの向きを起点に前後左右に動く
        Vector3 hv = h * camera.transform.right + v * camera.transform.forward;
        hv.y = 0.0f;
        velocity = hv.magnitude;
        isMoving = velocity > .01f;
        if (!isMoving)
        {
            // 減速
            rb.velocity *= reductionRatio;
            return;
        }

        rb.velocity += basis * Time.deltaTime * hv;
        q.SetLookRotation(view: hv, up: Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, q, rotSpeed * Time.deltaTime);
    }

    /// <summary>
    /// (銃用)プレイヤーとカメラのy座標を同期
    /// </summary>
    public void Rotate4Gun()
    {
        var a = transform.rotation;
        a.y = camera.transform.rotation.y;

        //transform.rotation = camera.transform.rotation;
    }

    /// <summary>
    /// 回転
    /// </summary>
    void Rotate(float rotSpeed)
    {
        if (!playerInput.IsRotating)
        {
            return;
        }
        float playerAngleY = this.transform.eulerAngles.y, cameraAngleY = camera.transform.eulerAngles.y;
        float angleYDiff = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

        // プレイやーのyをカメラのyにする
        transform.localEulerAngles = new(
            transform.localEulerAngles.x,
            y: Mathf.Lerp(playerAngleY, playerAngleY + angleYDiff, rotSpeed * Time.deltaTime),
            transform.localEulerAngles.z
        );

        // 差が0.1以下だったら回転終了
        if (Mathf.Abs(angleYDiff) <= 0.1)
        {
            playerInput.IsRotating = false;
        }
    }

    /// <summary>
    /// ジャンプ
    /// </summary>
    /// <param name="power">脚力</param>
    void Jumps(float power)
    {
        if (!isFloating && Input.GetButton("Jump"))
        {
            rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Ground"))
        {
            isFloating = false;
        }
    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Ground"))
        {
            isFloating = true;
        }
    }
}