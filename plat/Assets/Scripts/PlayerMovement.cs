using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    // [System.Serializable]
    class V
    {
        /// <summary>
        /// 基本の移動速度
        /// </summary>
        public float basis;
        /// <summary>
        /// 減速比
        /// </summary>
        public float reduction;
        public V(float basis, float reduction)
        {
            this.basis = basis;
            this.reduction = reduction;
        }

        /// <summary>
        /// ジャンプ力
        /// </summary>
        public float power;
        public V(float power)
        {
            this.power = power;
        }
    }

    [SerializeField]
    new GameObject camera;

    Rigidbody rb;
    CameraMovement cameraMovement;
    Quaternion q;

    // [SerializeField]
    // V v;

    V m, j;

    bool isMoving = false;
    /// <summary>
    /// 動いていたらtrue
    /// </summary>
    public bool IsMoving => isMoving;

    bool isFloating = false;
    /// <summary>
    /// 地に足がついていたらfalse
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

    Guns gun;

    void Start()
    {
        m = new(basis: 15, reduction: 0.5f);
        j = new(power: 200);

        //q = new();

        rb = this.gameObject.GetComponent<Rigidbody>();
        try
        {
            camera = GameObject.FindGameObjectWithTag(Mine.Tags.Cam);
        }
        catch(System.NullReferenceException)
        {
            camera = GameObject.Find("cam0");
        }
        cameraMovement = camera.GetComponent<CameraMovement>();
        gun = GameObject.Find("muzzle").GetComponent<Guns>();
    }

    void FixedUpdate()
    {
        Moves(m.basis, m.reduction);
    }

    void Update()
    {
        Jumps(j.power);
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
        //var a = transform.rotation;
        //a.y = camera.transform.rotation.y;
        this.transform.Rotate(new(transform.rotation.x, camera.transform.rotation.y, transform.rotation.z));

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

        // 移動か射撃していて回転y座標の差が0じゃなかったら
        if ((/*isMoving ||*/ gun.Shootable) && rotDiff != 0)
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