using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
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

        PlayerInput pi;
        GameObject gun;

        float fireRate = 0.5f;
        float timer;

        void Start()
        {
            pi = GameObject.FindGameObjectWithTag(Const.Player).GetComponent<PlayerInput>();
            gun = GameObject.FindGameObjectWithTag(Const.Gun);
        }

        void Update()
        {
            Trigger();
        }

        void Trigger()
        {
            timer.show();
            timer += Time.deltaTime;
            bool shootable = pi.Shootable && !pi.IsRotating && timer > fireRate;
            if (shootable)
            {
                Fire2(power);
                pi.Shootable = false;
                timer = 0;
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

        void Fire2(float moving)
        {
            var bullet = Instantiate(
                // bulletPrefabs[bulletPrefabs.Length.random()],
                bulletPrefabs[Rand.om(max: bulletPrefabs.Length)],
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
