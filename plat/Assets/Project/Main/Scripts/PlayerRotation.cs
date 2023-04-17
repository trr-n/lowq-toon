using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//// https://nekojara.city/unity-rotate-to-movement-direction#%E6%BB%91%E3%82%89%E3%81%8B%E3%81%AB%E5%9B%9E%E8%BB%A2%E3%81%95%E3%81%9B%E3%82%8B
public class PlayerRotation : MonoBehaviour
{
    /// <summary>
    /// 回転速度
    /// </summary>
    [SerializeField]
    float maxAng = Mathf.Infinity;

    /// <summary>
    /// 回転速度
    /// </summary>
    [SerializeField]
    float rotSpeed = 0.1f;

    /// <summary>
    /// 前フレームの座標
    /// </summary>
    Vector3 prePos;

    float currentAng;

    Transform self;

    void Start()
    {
        self = transform;
        prePos = self.position;
    }

    void Update()
    {
        var position = self.position;
        var delta = position - prePos;
        prePos = position;

        if (delta == Vector3.zero)
            return;

        var targetRot = Quaternion.LookRotation(delta, Vector3.up);
        var diff = Vector3.Angle(self.forward, delta);

        var rotAngle = Mathf.SmoothDampAngle(
            0,
            diff,
            ref currentAng,
            rotSpeed,
            maxAng
        );

        var rot = Quaternion.RotateTowards(
            self.rotation,
            targetRot,
            rotAngle
        );

        self.rotation = rot;
    }
}