using UnityEngine;

namespace Toon
{
    public class PlayerMovement : MonoBehaviour
    {
        // [Serializable]
        class Values
        {
            // static 
            public float basis = 15;
            public float floating;
            public float reduction = 0.5f;
            public float power = 200;
            public float rotation = 30;
            public float rotation4move = 10;
            public float tolerance = 0.5f;

            public Values(float _basis, float _floating, float _reduction, float _power, float _rotation, float _rotation4move, float _tolerance)
            {
                basis = _basis;
                floating = _floating;
                reduction = _reduction;
                power = _power;
                rotation = _rotation;
                rotation4move = _rotation4move;
                tolerance = _tolerance;
            }
        }

        [SerializeField] new GameObject camera;

        Rigidbody rb;
        Quaternion q;
        CameraMovement cameraMovement;
        PlayerInput playerInput;

        // [SerializeField]
        // Values value;
        readonly Values value = new(
            _basis: 15,
            _floating: 10,
            _reduction: 0.5f,
            _power: 100,
            _rotation: 30,
            _rotation4move: 10,
            _tolerance: 0.5f
        );

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
            playerInput = gameObject.GetComponent<PlayerInput>();
            camera = GameObject.FindGameObjectWithTag(constant.Camera);
            cameraMovement = camera.GetComponent<CameraMovement>();
        }

        void FixedUpdate()
        {
            Moves(value.basis, value.reduction, value.rotation4move);
        }

        void Update()
        {
            Jumps(value.power);
            Rotate(value.rotation, value.tolerance);
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
                // 入力が0.01未満だったら毎フレームreductionRatioずつ減速
                rb.velocity *= reductionRatio;
                return;
            }
            //rb.velocity += basis * Time.deltaTime * hv;

            // 0.5x speed if you are jumping
            rb.velocity += (isFloating ? value.floating : basis) * Time.deltaTime * hv;
            q.SetLookRotation(view: hv, up: Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, rotSpeed * Time.deltaTime);
        }

        // /// <summary>
        // /// (銃用)プレイヤーとカメラのy座標を同期
        // /// </summary>
        // public void Rotate4Gun()
        // {
        //     var a = transform.rotation;
        //     a.y = camera.transform.rotation.y;
        // }

        /// <summary>
        /// 回転処理
        /// </summary>
        /// <param name="rotSpeed">回転速度</param>
        /// <param name="tolerance">許容値 仮</param>
        void Rotate(float rotSpeed, float tolerance)
        {
            if (!playerInput.isRotating)
                return;
            playerInput.isRotating = true;

            float playerAngleY = this.transform.eulerAngles.y,
                cameraAngleY = camera.transform.eulerAngles.y;
            float angleYDiff = Mathf.DeltaAngle(playerAngleY, cameraAngleY);

            // camera y is syncing player y
            transform.localEulerAngles = new(
                transform.localEulerAngles.x,
                Mathf.Lerp(playerAngleY, playerAngleY + angleYDiff, rotSpeed * Time.deltaTime),
                transform.localEulerAngles.z
            );

            // 差がtolerance(許容値)以下で!IsRotating
            if (Mathf.Abs(angleYDiff) <= tolerance)
                playerInput.isRotating = false;
        }

        /// <summary>
        /// ジャンプ
        /// </summary>
        /// <param name="power">脚力</param>
        void Jumps(float power)
        {
            if (!isFloating && Input.GetButtonDown(constant.Jump))
                rb.AddForce(Vector3.up * power, ForceMode.Impulse);
        }

        void OnCollisionEnter(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.CompareTag(constant.Ground))
                isFloating = false;
        }

        void OnCollisionExit(Collision collisionInfo)
        {
            if (collisionInfo.gameObject.CompareTag(constant.Ground))
                isFloating = true;
        }
    }
}