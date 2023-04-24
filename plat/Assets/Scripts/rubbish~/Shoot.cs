using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Mine.Script;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject player;

    /// <summary>
    /// 弾速
    /// </summary>
    [SerializeField, Tooltip("弾速")]
    float power;

    /// <summary>
    /// 発射レート
    /// </summary>
    [SerializeField, Tooltip("発射レート")]
    float fireRate = 0.5f;

    /// <summary>
    /// レート管理用タイマー
    /// </summary>
    float timer;

    /// <summary>
    /// 弾を生成する座標
    /// </summary>
    Vector3 generatePos;

    [Tooltip("銃口が起点")]
    [SerializeField]
    Vector3 shift = new(0.484f, 0.1f, 0.5f);

    /// <summary>
    /// 銃口の絶対座標
    /// </summary>
    Vector3 muzzleAbsPos;

    Transform shooter;
    GameObject muzzle;

    string muzzleName = "group_0_1206582";

    void Start()
    {
        muzzle = GameObject.Find(muzzleName);
        timer = fireRate;
    }

    void Update()
    {
        print(muzzle.transform.position);
        generatePos = muzzle.transform.position + shift;

        // if (Input.GetMouseButton(0))
        {
            Fire(power, reduct: 0.9f);
        }
    }

    Rigidbody bulletRb;
    /// <summary>
    /// 発砲処理
    /// </summary>
    /// <param name="power">弾速</param>
    void Fire(float power, float reduct)
    {
        timer += Time.deltaTime;
        if (bulletRb != null)
        {
            bulletRb.velocity *= reduct;
        }

        if (timer <= fireRate)
            return;

        var bulletIns = Instantiate(bullet, generatePos, Quaternion.identity);
        print("fire");
        bulletRb = bulletIns.GetComponent<Rigidbody>();
        // bulletRb.AddForce(transform.right * power, ForceMode.Impulse);
        bulletRb.velocity = muzzle.transform.forward * power;
        Destroy(bulletIns, 10);
        timer = 0;
    }
}
