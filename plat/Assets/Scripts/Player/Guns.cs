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

        float lookingUpALittle = 11f;
        float firstBulletPowerScale = 100f;
        float power = 10;
        float fireRate = 0.5f;
        float timer;
        Vector3 bulletGenPosOffset = new(0, 0, 0.2f);
        PlayerInput pi;
        GameObject gun;
        Quaternion selfRotation;
        bool isShooting;
        public bool IsShooting => isShooting;
        bool rapid;
        public bool Rapid => rapid;
        bool firstShot;
        public bool FirstShot => firstShot;
        public bool Shootable { get; set; }

        void Start()
        {
            pi = gobject.find(constant.Manager).GetComponent<PlayerInput>();
            gun = gobject.find(constant.Gun);
            camera = gobject.find(constant.Camera);
        }

        void Update()
        {
            Rotate(lookUp: lookingUpALittle);
            Trigger();
        }

        void Trigger()
        {
            timer += Time.deltaTime;
            Shootable = pi.shootable && !pi.isRotating;

            firstShot = input.down(pi.Click4Shoot);
            rapid = input.pressed(pi.Click4Shoot) && timer > fireRate;

            if (!Shootable)
                return;
            // 初弾(クリックしたとき)は単発強め、二発目(長押し)から勢い弱めで連射
            if (firstShot)
            {
                isShooting = true;
                Fire2(power * firstBulletPowerScale);
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
                Fire2(power * firstBulletPowerScale);
                yield return new WaitForSeconds(1f);
            }
        }

        void Fire2(float moving)
        {
            GameObject bullet = Instantiate(
                bulletPrefabs[random.choice(bulletPrefabs.Length)],
                this.transform.position + bulletGenPosOffset,
                Quaternion.identity
            );
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * moving;
        }

        void Rotate(float lookUp)
        {
            // transform.rotation = camera.transform.rotation;
            transform.rotation = Quaternion.Euler(
                x: camera.transform.eulerAngles.x - lookUp,
                y: camera.transform.eulerAngles.y,
                z: camera.transform.eulerAngles.z
            );
        }
    }
}
