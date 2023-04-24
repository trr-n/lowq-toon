using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mine;

public class Guns : MonoBehaviour
{
    [Tooltip("弾のプレハブ")]
    [SerializeField]
    GameObject[] bulletPrefabs;

    /// <summary>
    /// 弾速
    /// </summary>
    float power = 10;

    /// <summary>
    /// 弾の生成座標
    /// </summary>
    Vector3 generatePosition = new(0, 0, 0.2f);

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Fire");
            Fire(_moving: power);
        }
    }

    /// <summary>
    /// 発砲処理
    /// </summary>
    /// <param name="_moving">弾速</param>
    void Fire(float _moving)
    {
        var _bullet = Instantiate(
            bulletPrefabs[Script.Randint(max: bulletPrefabs.Length)],
            this.gameObject.transform.position + generatePosition,
            Quaternion.Euler(
                Script.Randfloat(max: 360),
                Script.Randfloat(max: 360),
                Script.Randfloat(max: 360)
            )
        );
        var _rb = _bullet.GetComponent<Rigidbody>();
        _rb.velocity = _moving * this.gameObject.transform.forward;

        Destroy(_bullet, 10);
    }
}
