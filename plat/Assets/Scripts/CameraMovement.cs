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
    Vector3 posDistance = new(0, 1.84f, -2.56f);

    /// <summary>
    /// カメラが見る座標
    /// </summary>
    Vector3 lookAt = new(0, 1, 0);

    /// <summary>
    /// カメラが見ている座標    
    /// </summary>
    Vector3 lookingAt;
    public Vector3 LookingAt => lookingAt;

    float angleX = 0.0f, angleY = 0.0f;

    GameObject player;

    PlayerMovement playerMovement;

    Quaternion rotation;
    public Quaternion Rotation => rotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag(Mine.Tags.Player);
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        rotation = this.transform.rotation;
        ViewRotation(sensiX, sensiY, deadZone);
        FollowPlayer(
            _posDis: Quaternion.Euler(angleX, angleY, 0) * posDistance,
            _lookAt: lookAt
        );
    }

    /// <summary>
    /// 視点移動
    /// </summary>
    /// <param name="_sensiX">縦移動感度</param>
    /// <param name="_sensiY">横移動感度</param>
    /// <param name="_deadZone">入力感度の調整</param>
    void ViewRotation(float _sensiX, float _sensiY, float _deadZone)
    {
        float mx = Input.GetAxis(Mine.Keys.MX),
            my = Input.GetAxis(Mine.Keys.MY);

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
    /// <param name="_posDistance">プレイヤーとカメラの距離</param>
    /// <param name="_lookAt">カメラがみる座標</param>
    void FollowPlayer(Vector3 _posDis, Vector3 _lookAt)
    {
        this.transform.position = player.transform.position + _posDis;
        lookingAt = player.transform.position + _lookAt;
        this.transform.LookAt(lookingAt);
    }
}
