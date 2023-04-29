using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [Serializable]
    // 設定し直しめんどくさいから生弄り
    class Values
    {
        public static float basis = 15;
        public static float reduction = 0.5f;
        public static float power = 200;
        public static float rotation = 30;
        public static float rotation4move = 10;
        public static float tolerance = 0.5f;

        // public Values(float _basis, float _reduction, float _power, float _rotation, float _rotation4move, float _tolerance)
        // {
        //     basis = _basis;
        //     reduction = _reduction;
        //     power = _power;
        //     rotation = _rotation;
        //     rotation4move = _rotation4move;
        //     tolerance = _tolerance;
        // }
    }

    [SerializeField]
    new GameObject camera;

    Rigidbody rb;
    Quaternion q;

    CameraMovement cameraMovement;
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

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        camera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        cameraMovement = camera.GetComponent<CameraMovement>();
        playerInput = gameObject.GetComponent<PlayerInput>();

        print(velocity.GetType().Name.ToString());
    }

    void FixedUpdate()
    {
        Moves(Values.basis, Values.reduction, Values.rotation4move);
    }

    void Update()
    {
        Jumps(Values.power);
        Rotate(Values.rotation, Values.tolerance);
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
    /// 回転処理
    /// </summary>
    /// <param name="rotSpeed">回転速度</param>
    /// <param name="tolerance">許容値 仮</param>
    void Rotate(float rotSpeed, float tolerance)
    {
        if (!playerInput.IsRotating)
        {
            return;
        }
        playerInput.IsRotating = true;

        float playerAngleY = this.transform.eulerAngles.y, cameraAngleY = camera.transform.eulerAngles.y;
        float angleYDiff = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

        // プレイやーのyをカメラのyにする
        transform.localEulerAngles = new(
            transform.localEulerAngles.x,
            Mathf.Lerp(playerAngleY, playerAngleY + angleYDiff, rotSpeed * Time.deltaTime),
            transform.localEulerAngles.z
        );

        // 差がtolerance(許容値)以下で回転終了
        if (Mathf.Abs(angleYDiff) <= tolerance)
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