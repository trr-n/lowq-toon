using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject player;
    [SerializeField]
    float power;

    /// <summary>
    /// 銃口
    /// </summary>
    Vector3 nozzlePos = new(24.5f, 9, 20);

    /// <summary>
    /// 発射レート
    /// </summary>
    [SerializeField]
    float fireRate = 0.5f;

    float timer;

    void Update()
    {
        Debug.Log(timer);

        // if (Input.GetMouseButton(0))
        if (true)
        {
            Fire(power: power);
        }
        var str = ; // 銃口と弾の位置を計算
    }

    void Fire(float power)
    {
        timer += Time.deltaTime;

        if (timer <= fireRate) return;
        var bulletIns = Instantiate(bullet, transform.parent.position + nozzlePos, Quaternion.identity);
        var bulletRb = bulletIns.GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.parent.forward * power, ForceMode.Impulse);
        // bulletRb.AddForce(player.transform.forward * power, ForceMode.Impulse);
        // bulletRb.velocity = transform.right * power;

        timer = 0;
    }
}
