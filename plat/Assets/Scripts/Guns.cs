using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mine;

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

    PlayerInput playerInput;

    Renderer r4GunBody;

    void Start()
    {
        playerInput = GameObject.Find("player0").GetComponent<PlayerInput>();

        r4GunBody = GameObject.Find("body").GetComponent<Renderer>();
    }

    void Update()
    {
        Trigger();
    }

    void Trigger()
    {
        if (playerInput.Shootable && !playerInput.IsRotating && Input.GetMouseButton(0))
        {
            r4GunBody.material.color = Color.red;
            print("body turns red");
            player.GetComponent<PlayerMovement>().Rotate4Gun();
            Fire(moving: power);
        }
        r4GunBody.material.color = Color.white;
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
