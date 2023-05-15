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

        public bool shootable { get; set; }

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

        bool isShooting;
        public bool IsShooting => isShooting;

        void Start()
        {
            pi = GameObject.FindGameObjectWithTag(constant.Player).GetComponent<PlayerInput>();
            gun = GameObject.FindGameObjectWithTag(constant.Gun);
        }

        void Update()
        {
            Trigger();
        }

        void Trigger()
        {
            timer += Time.deltaTime;
            shootable = pi.shootable && !pi.isRotating && timer > fireRate;
            if (shootable)
            {
                isShooting = true;
                Fire2(power);
                pi.shootable = false;
                timer = 0;
                return;
            }
            isShooting = false;
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
            GameObject bullet = Instantiate(
                bulletPrefabs[random.choice(bulletPrefabs.Length)],
                this.transform.position + generatePosition,
                Quaternion.identity
            );
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = moving * gameObject.transform.forward;
        }
    }
}
