using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTitle
{
    public class Guns : MonoBehaviour
    {
        [Tooltip("prefab of bullets")]
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
            playerInput = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerInput>();
            guns = GameObject.FindGameObjectsWithTag(Tags.Gun);
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
                "body turns red".show();
                player.GetComponent<PlayerMovement>().Rotate4Gun();
                // Fire(moving: power);
                Fire2(power);
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
                bulletPrefabs[rand.i(max: bulletPrefabs.Length)],
                this.transform.position + generatePosition,
                Quaternion.Euler(
                    rand.f(max: 360),
                    rand.f(max: 360),
                    rand.f(max: 360)
                )
            );
            var bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = moving * this.gameObject.transform.forward;

            // 10秒後に仮破壊
            Destroy(bullet, 10);
        }

        void Fire2(float moving = 0)
        {
            var bullet = Instantiate(
                bulletPrefabs[bulletPrefabs.Length.random()],
                this.transform.position + generatePosition,
                Quaternion.identity
            );
            var bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = moving * this.gameObject.transform.forward;

            // 10秒後に仮破壊
            // Destroy(bullet, 10);
        }
    }
}
