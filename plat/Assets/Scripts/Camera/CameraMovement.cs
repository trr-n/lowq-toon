using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        float deadZone = .001f;
        [SerializeField]
        float sensiX = 1.2f, sensiY = 1.2f;
        [SerializeField]
        TerrainCollider terrainCol;

        Vector3 lookAt = new(0, 1, 0), cameraPlayerDistance = new(0, 2, -4);
        GameObject player;
        float angleX = 0.0f, angleY = 0.0f;
        GameObject portal;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag(Constant.Player);
            terrainCol ??= GameObject.FindGameObjectWithTag("Terrain").GetComponent<TerrainCollider>();
            portal = GameObject.FindGameObjectWithTag(Constant.Portal);
        }

        void Update()
        {
            ViewRotation(sensiX, sensiY, deadZone);
            FollowPlayer(Quaternion.Euler(angleX, angleY, 0) * cameraPlayerDistance, lookAt);
            // Raying();
        }

        bool hitOther = false;
        /// <summary>
        /// めり込み対策
        /// </summary>
        void Raying()
        {
            Ray r2 = new(transform.position, transform.forward);
            Debug.DrawRay(r2.origin, r2.direction);
            var dis = Vector3.Distance(transform.position, player.transform.position);
            hitOther = false;
            if (Physics.Raycast(r2, out var hit2, dis))
            {
                //? https://forum.unity.com/threads/physics-raycast-not-working-for-terrain.412005/
                if (!hit2.collider.Compare(Constant.Player))
                {
                    hitOther = true;
                    transform.position = hit2.point;
                }
            }
            if (!hitOther && terrainCol.Raycast(r2, out var hit3, dis))
            {
                print("hit for terrain");
                transform.position = hit3.point;
            }
        }

        /// <summary>
        /// 視点移動
        /// </summary>
        /// <param name="_sensiX">縦移動感度</param>
        /// <param name="_sensiY">横移動感度</param>
        /// <param name="_deadZone">入力感度の調整</param>
        void ViewRotation(float _sensiX, float _sensiY, float _deadZone)
        {
            float mx = Input.GetAxis(Constant.MouseX),
                my = Input.GetAxis(Constant.MouseY);

            // プレイヤーを中心に回転させる
            if (Mathf.Abs(mx) >= _deadZone)
                angleY += mx * _sensiY;

            if (Mathf.Abs(my) >= _deadZone)
                angleX -= my * _sensiX;
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

        async Task tasktest()
        {
            while (true)
            {
                await Task.Delay(1 * 1000);
                "call".show();
            }
        }
    }
}
