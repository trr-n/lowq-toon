using System.Collections;
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

        const float lookingUpALittle = 11f;
        float basePower = 10f, firstBulletPowerScale = 70f;
        float fireRate = 0.5f, timer = 0f;
        Vector3 bulletGenPosOffset = new(0, 0, 0.2f);
        PlayerInput pinput;
        GameObject gun;
        Quaternion selfRotation;
        bool isShooting, rapid, firstShot;
        public bool Shootable { get; set; }

        void Start()
        {
            pinput = gobject.find(constant.Manager).GetComponent<PlayerInput>();
            gun = gobject.find(constant.Gun);
            camera = gobject.find(constant.Camera);
        }

        void Update()
        {
            Rotate(lookUp: lookingUpALittle);
            Trigger();
        }

        System.Diagnostics.Stopwatch stopwatch = new();
        public void Trigger()
        {
            stopwatch.Start();
            timer += Time.deltaTime;
            Shootable = pinput.shootable && !pinput.isRotating;
            firstShot = input.down(pinput.Click4Shoot);
            // rapid = input.pressed(pinput.Click4Shoot) && timer > fireRate;
            rapid = input.pressed(pinput.Click4Shoot) &&
                stopwatch.Elapsed.TotalSeconds > fireRate;

            if (!Shootable)
                return;

            if (firstShot)
            {
                isShooting = true;
                Fire2(basePower * firstBulletPowerScale);
                pinput.shootable = false;
            }
            else if (rapid && !firstShot)
            {
                isShooting = true;
                Fire2(basePower);
                pinput.shootable = false;
                // timer = 0;
                stopwatch.Restart();
            }
            isShooting = false;
        }

        IEnumerator TestFire()
        {
            while (true)
            {
                Fire2(basePower * firstBulletPowerScale);
                yield return new WaitForSeconds(1f);
            }
        }

        void Fire2(float moving)
        {
            GameObject bullet =
                Instantiate(bulletPrefabs[random.choice(bulletPrefabs.Length)], transform.position + bulletGenPosOffset, Quaternion.identity);
            var brb = bullet.GetComponent<Rigidbody>();
            brb.velocity = transform.forward * moving;
        }

        void Rotate(float lookUp)
        {
            var r = transform.eulerAngles;
            r.x = camera.transform.eulerAngles.x - lookUp;
            transform.eulerAngles = r;
        }
    }
}
