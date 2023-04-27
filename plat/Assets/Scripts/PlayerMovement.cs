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
        public float basis;
        public float reduction;
        public float power;
        public V(float _basis, float _reduction, float _power)
        {
            basis = _basis;
            reduction = _reduction;
            power = _power;
        }
    }

    [SerializeField]
    new GameObject camera;

    Rigidbody rb;
    CameraMovement cameraMovement;
    Quaternion q;
    GameManager gameManager;

    // [SerializeField]
    // V v;

    V vv;

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

    /// <summary>
    /// プレイヤーの回転速度
    /// </summary>
    float rotSpeed = 10;

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
        vv = new(_basis: 15, _reduction: 0.5f, _power: 200);

        rb = this.gameObject.GetComponent<Rigidbody>();
        camera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        cameraMovement = camera.GetComponent<CameraMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void FixedUpdate()
    {
        Moves(vv.basis, vv.reduction);
    }

    void Update()
    {
        Jumps(vv.power);
        Rotate(100);
    }

    /// <summary>
    /// プレイヤーの移動、回転処理
    /// </summary>
    /// <param name="basis">基本の移動速度</param>
    /// <param name="reductionRatio">減速比</param>
    void Moves(float basis, float reductionRatio)
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

        rb.velocity += hv * basis * Time.deltaTime;
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
    /// 移動か発砲したら回転
    /// </summary>
    void Rotate(float speed)
    {
        // プレイヤーとカメラの角度同じならtrue
        int playerAngleY = (int)Mathf.Floor(this.transform.eulerAngles.y),
            cameraAngleY = (int)Mathf.Floor(camera.transform.eulerAngles.y);
        int rotDiff = (int)Mathf.DeltaAngle(playerAngleY, cameraAngleY);
        bool shot = Input.GetMouseButtonDown((int)gameManager.Click4Shoot);

        //// 移動か射撃していて回転y座標の差が0じゃなかったら
        // 射撃した瞬間プレイヤーとカメラのY座標の差が0じゃなかったらtrue
        if ((/*isMoving ||*/ shot) && rotDiff != 0)
        {
            return;
        }
        // プレイやーのyをカメラのyにする
        var leAngles = transform.localEulerAngles;
        leAngles.y = camera.transform.eulerAngles.y;
        //leAngles.y = Mathf.Lerp(transform.eulerAngles.y, camera.transform.eulerAngles.y, speed * Time.deltaTime);
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