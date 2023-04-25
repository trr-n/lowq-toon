using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mine;
using Unity.VisualScripting;

public class Guns : MonoBehaviour
{
    [Tooltip("弾のプレハブ")]
    [SerializeField]
    GameObject[] bulletPrefabs;

    [SerializeField]
    GameObject player;

    /// <summary>
    /// 弾速
    /// </summary>
    float power = 10;

    /// <summary>
    /// 弾の生成座標
    /// </summary>
    Vector3 generatePosition = new(0, 0, 0.2f);

    bool shootable = false;
    /// <summary>
    /// 発砲したらtrue
    /// </summary>
    public bool Shootable => shootable;

    enum Clicks
    {
        Left = 0, 
        Right = 1
    }
    [SerializeField]
    Clicks clicks = Clicks.Left;

    void Update()
    {
        shootable = Input.GetMouseButtonDown((int)clicks);
        Trigger();
    }

    void Trigger()
    {
        if (shootable)
        {
            print("called");
            player.GetComponent<PlayerMovement>().Rotate4Gun();
            Fire(moving: power);
        }
    }

    /// <summary>
    /// 発砲処理
    /// </summary>
    /// <param name="moving">弾速</param>
    void Fire(float moving)
    {
        var bullet = Instantiate(
            bulletPrefabs[Script.Randint(max: bulletPrefabs.Length)],
            this.transform.position + generatePosition,
            Quaternion.Euler(
                Script.Randfloat(max: 360),
                Script.Randfloat(max: 360),
                Script.Randfloat(max: 360)
            )
        );
        var bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = moving * this.gameObject.transform.forward;

        // 10秒後に破壊
        Destroy(bullet, 10);
    }
}
