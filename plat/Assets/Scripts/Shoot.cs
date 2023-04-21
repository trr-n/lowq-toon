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
    Vector3 genPos;

    /// <summary>
    /// 銃口の絶対座標
    /// </summary>
    Vector3 nozzleAbsPos;

    Transform shooter;
    GameObject nozzle;

    string nozzleName = "group_0_1206582";

    // Player playerNum = Player.P1;
    // Manager manager;

    void Start()
    {
        nozzle = GameObject.Find(nozzleName);
        timer = fireRate;
    }

    void Update()
    {
        genPos = nozzle.transform.position + new Vector3(10, 20, 25);

        if (Input.GetMouseButton(0))
        {
            Fire(power);
        }
    }

    /// <summary>
    /// 発砲処理
    /// </summary>
    /// <param name="power">弾速</param>
    void Fire(float power)
    {
        timer += Time.deltaTime;

        if (timer <= fireRate)
            return;

        var bulletIns = Instantiate(bullet, genPos, Quaternion.identity);
        var bulletRb = bulletIns.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.right * power, ForceMode.Impulse);
        Destroy(bulletIns, 10);
        timer = 0;
    }
}
