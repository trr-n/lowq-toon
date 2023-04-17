using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    /// <summary>
    /// 弾のプレハブ
    /// </summary>
    [SerializeField]
    Bullet bullet;

    /// <summary>
    /// 発射レート
    /// </summary>
    [SerializeField]
    float fireRate;

    /// <summary>
    /// 装弾数
    /// </summary>
    [SerializeField]
    int cap;

    /// <summary>
    /// 残弾数
    /// </summary>
    [SerializeField]
    int remain;
    public int Remain => remain;

    /// <summary>
    /// 弾速
    /// </summary>
    [SerializeField]
    float power;

    /// <summary>
    /// 発砲処理
    /// </summary>
    /// <param name="dir">方向</param>
    /// <param name="shootable">発砲可能か</param>
    public void Firing(Vector3 dir)
    {
        if (remain != 0)
        {
            var b = Instantiate(bullet, transform.position, Quaternion.identity);
            b.Fire(dir * power);
            remain--;
        }
    }

    /// <summary>
    /// リロード処理
    /// </summary>
    public void Reload() => remain = cap;
}
