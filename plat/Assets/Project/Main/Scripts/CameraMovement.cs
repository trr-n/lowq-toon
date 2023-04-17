using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Vector3 posDistance = new(0, 184, -256);

    /// <summary>
    /// カメラが見る座標
    /// </summary>
    Vector3 lookAt = new(0, 100, 0);

    /// <summary>
    /// カメラが見ている座標    
    /// </summary>
    Vector3 lookingAt;
    public Vector3 LookingAt => lookingAt;

    float angleX = 0.0f, angleY = 0.0f;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Mine.Tags.Player);
    }

    void Update()
    {
        Rotation(sensiX, sensiY, deadZone);
        FollowPlayer(
            posDis: Quaternion.Euler(angleX, angleY, 0) * posDistance,
            lookAt: lookAt
        );
    }

    /// <summary>
    /// 視点移動
    /// </summary>
    /// <param name="sensiX">縦移動感度</param>
    /// <param name="sensiY">横移動感度</param>
    /// <param name="deadZone">入力感度の調整</param>
    // TODO 地面、壁のめり込み対策
    void Rotation(float sensiX, float sensiY, float deadZone)
    {
        float mx = Input.GetAxis(Mine.Keys.MX),
            my = Input.GetAxis(Mine.Keys.MY);
        Vector3 cam = this.transform.position, play = player.transform.position;

        // プレイヤーを中心に回転させる
        if (Mathf.Abs(mx) >= deadZone)
        {
            angleY += mx;
        }

        if (Mathf.Abs(my) >= deadZone)
        {
            angleX += -my;
        }
    }

    void FollowPlayer(Vector3 posDis, Vector3 lookAt)
    {
        this.transform.position =
            player.transform.position + posDis;
        lookingAt = player.transform.position + lookAt;
        this.transform.LookAt(lookingAt);
    }
}
