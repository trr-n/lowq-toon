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
    /// <summary>
    /// 残弾数, getter
    /// </summary>
    public int Remain => remain;

    /// <summary>
    /// 発砲処理
    /// </summary>
    public void Firing(Vector3 dir)
    {
        var b = Instantiate(bullet, transform.position, Quaternion.identity);
        b.Fire(dir);
    }

    /// <summary>
    /// リロード処理
    /// </summary>
    public void Reload() => remain = cap;
}
