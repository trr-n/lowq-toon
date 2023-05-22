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

        [SerializeField]
        new GameObject camera;

        [SerializeField]
        [Tooltip("初弾の加速の倍率")]
        float firstBulletScale = 1.5f;

        public bool shootable { get; set; }

        /// <summary>
        /// 弾速
        /// </summary>
        float power = 10;

        /// <summary>
        /// 弾の生成座標
        /// </summary>
        Vector3 ofs = new(0, 0, 0.2f);

        PlayerInput pi;
        GameObject gun;

        float fireRate = 0.5f;
        float timer;

        bool isShooting;
        public bool IsShooting => isShooting;

        bool rapid;
        public bool Rapid => rapid;

        bool firstShot;
        public bool FirstShot => firstShot;

        Quaternion selfRotation;

        void Start()
        {
            pi = GameObject.FindGameObjectWithTag(constant.Manager)
                .GetComponent<PlayerInput>();
            gun = GameObject.FindGameObjectWithTag(constant.Gun);
            camera ??= GameObject.FindGameObjectWithTag(constant.Camera);
            // StartCoroutine(TestFire());
        }

        void Update()
        {
            Rotate();
            Trigger();
        }

        void Trigger()
        {
            timer += Time.deltaTime;
            shootable = pi.shootable && !pi.isRotating;

            firstShot = input.down(pi.Click4Shoot);
            rapid = input.pressed(pi.Click4Shoot) && timer > fireRate;

            if (!shootable)
            {
                return;
            }

            // 初弾(クリックしたとき)は単発強め、二発目(長押し)から勢い弱めで連射
            if (firstShot)
            {
                isShooting = true;
                Fire2(power * firstBulletScale);
                pi.shootable = false;
            }

            else if (rapid && !firstShot)
            {
                isShooting = true;
                Fire2(power);
                pi.shootable = false;
                timer = 0;
            }

            isShooting = false;
        }

        IEnumerator TestFire()
        {
            while (true)
            {
                Fire2(power);
                yield return new WaitForSeconds(0.5f);
            }
        }

        void Fire2(float moving)
        {
            GameObject bullet = Instantiate(
                bulletPrefabs[random.choice(bulletPrefabs.Length)],
                this.transform.position + ofs,
                Quaternion.identity
            );
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * moving;
            transform.forward.show();
        }

        void Rotate()
        {
            Debug.DrawRay(transform.position, transform.forward * 100, Color.white, 0.02f, true);
            transform.rotation = camera.transform.rotation;
        }
    }
}
