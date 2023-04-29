using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mine
{
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

        GameObject[] guns;
        Renderer r4GunBody;

        void Start()
        {
            playerInput = GameObject.FindGameObjectWithTag(Mine.Tags.Player).GetComponent<PlayerInput>();
            guns = GameObject.FindGameObjectsWithTag(Mine.Tags.Gun);
            r4GunBody = guns[1].GetComponent<Renderer>();
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
                // bulletPrefabs[Mine.Random.Randint(max: bulletPrefabs.Length)],
                bulletPrefabs[bulletPrefabs.Length.random()],
                this.transform.position + generatePosition,
                Quaternion.Euler(
                    Random.Randfloat(max: 360),
                    Random.Randfloat(max: 360),
                    Random.Randfloat(max: 360)
                )
            );
            var bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = moving * this.gameObject.transform.forward;

            // 10秒後に破壊
            Destroy(bullet, 10);
        }
    }
}
