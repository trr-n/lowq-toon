using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class CameraMovement : MonoBehaviour
    {
        /// <summary>
        /// デッドゾーン
        /// </summary>
        [SerializeField]
        float deadZone = .001f;

        /// <summary>
        /// 視点移動の感度
        /// </summary>
        [SerializeField]
        float sensiX = 1.2f, sensiY = 1.2f;

        /// <summary>
        /// プレイヤーとカメラの距離
        /// </summary>
        // Vector3 posDistance = new(0, 2, -4);
        Vector3 posDistance = new(0, 2, 0);

        /// <summary>
        /// カメラが見る座標
        /// </summary>
        [SerializeField]
        Vector3 lookAt = new(0, 1, 0);

        /// <summary>
        /// カメラが見ている座標    
        /// </summary>
        Vector3 lookingAt;
        public Vector3 CameraLookingAt => lookingAt;

        float angleX = 0.0f, angleY = 0.0f;
        float lerping = 15;
        float rayLength = 0.1f;

        GameObject player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag(constant.Player);
        }

        void Update()
        {
            ViewRotation(sensiX, sensiY, deadZone);
            FollowPlayer(
                _posDis: Quaternion.Euler(angleX, angleY, 0) * posDistance,
                _lookAt: lookAt
            );
            Raying();
        }

        /// <summary>
        /// カメラめり込み対策
        /// todo 地面にはめりこんでまう
        /// </summary>
        void Raying()
        {
            Ray r2 = new(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward);
            Vector3 chousei = Vector3.zero;
            if (Physics.Raycast(r2, out RaycastHit hit2, Vector3.Distance(transform.position, player.transform.position) + 2))
            {
                if (hit2.collider.compare(constant.Player))
                {
                    return;
                }
                chousei = hit2.point;
            }
            transform.position = chousei;
        }

        /// <summary>
        /// 視点移動
        /// </summary>
        /// <param name="_sensiX">縦移動感度</param>
        /// <param name="_sensiY">横移動感度</param>
        /// <param name="_deadZone">入力感度の調整</param>
        void ViewRotation(float _sensiX, float _sensiY, float _deadZone)
        {
            float mx = Input.GetAxis(constant.MouseX),
                my = Input.GetAxis(constant.MouseY);

            // プレイヤーを中心に回転させる
            if (Mathf.Abs(mx) >= _deadZone)
            {
                angleY += mx * _sensiY;
            }

            if (Mathf.Abs(my) >= _deadZone)
            {
                angleX -= my * _sensiX;
            }
        }

        /// <summary>
        /// プレイヤーを追随
        /// </summary>
        /// <param name="_posDis">プレイヤーとカメラの距離</param>
        /// <param name="_lookAt">カメラがみる座標</param>
        void FollowPlayer(Vector3 _posDis, Vector3 _lookAt)
        {
            this.transform.position = player.transform.position + _posDis;
            this.transform.LookAt(player.transform.position + _lookAt);
        }
    }
}
