using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameTitle
{
    public class Guns : MonoBehaviour
    {
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

        GameObject gun;

        void Start()
        {
            playerInput = GameObject.FindGameObjectWithTag(Tags.Player).GetComponent<PlayerInput>();
            gun = GameObject.FindGameObjectWithTag(Tags.Gun);
        }

        void Update()
        {
            Trigger();
        }

        void Trigger()
        {
            // if (playerInput.Shootable && !playerInput.IsRotating && Input.GetMouseButton(0))
            if (Input.GetMouseButtonDown(0))
            {
                "fire".show();
                // Fire(moving: power);
                Fire2(power);
            }
        }

        // void Fire(float moving)
        // {
        //     var bullet = Instantiate(
        //         bulletPrefabs[rand.i(max: bulletPrefabs.Length)],
        //         this.transform.position + generatePosition,
        //         Quaternion.Euler(
        //             rand.f(max: 360),
        //             rand.f(max: 360),
        //             rand.f(max: 360)
        //         )
        //     );
        //     var bulletRb = bullet.GetComponent<Rigidbody>();
        //     bulletRb.velocity = moving * this.gameObject.transform.forward;

        //     // 10秒後に仮破壊
        //     Destroy(bullet, 10);
        // }

        void Fire2(float moving = 0)
        {
            var bullet = Instantiate(
                bulletPrefabs[rand.choice(bulletPrefabs.Length)],
                this.transform.position + generatePosition,
                Quaternion.identity
            );
            var rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = moving * this.gameObject.transform.forward;

            // 10秒後に仮破壊
            // Destroy(bullet, 10);
        }
    }
}
