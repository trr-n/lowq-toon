using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Canon : MonoBehaviour
    {
        [SerializeField] GameObject[] canons;
        [SerializeField] GameObject towerDeco;
        [SerializeField] GameObject player;
        [SerializeField] float scale;

        Vector3 direction;
        Transform towerT;

        bool isHaving;
        float rapid = 1;
        float distance;
        public float Distance => distance;
        float power = 0;
        public float Power => power;
        float min = 2, max = 20;

        void Start()
        {
            StartCoroutine(Trigger());
        }

        void Update()
        {
            direction = transform.position - player.transform.position;
            ChangeFirePower().show();
        }

        // todo 距離によって力を変動させる
        // closest point: 10.54776f, 10.59995f
        float[] x = new float[3] { 10, 10, 27 };
        public float ChangeFirePower()
        {
            power = numeric.clamp(power, 0.5f, 100);
            Vector3 self = transform.position, play = player.transform.position;
            distance = Vector3.Distance(self, play);
            return (distance - 10) * scale;
        }

        IEnumerator Trigger(bool canonFire = true)
        {
            while (canonFire)
            {
                GameObject canon = canons.ins(transform.position, Quaternion.identity);
                Rigidbody canonRb = canon.GetComponent<Rigidbody>();
                canonRb.AddForce(transform.forward * ChangeFirePower(), ForceMode.Impulse);
                yield return new WaitForSeconds(rapid);
            }
        }

        // void test_ray()
        // {
        //     UnityEngine.Debug.DrawRay(transform.position, -direction, Color.white, 0.02f);
        //     if (Physics.Raycast(transform.position, direction, out RaycastHit hit, distance))
        //     {
        //         hits.Add(hit.collider.gameObject);
        //     }
        // }

        // IEnumerator Trigger2(bool canonFire = true)
        // {
        //     while (canonFire)
        //     {
        //         // Ray ray = new(transform.position, player.transform.position);
        //         UnityEngine.Debug.DrawRay(transform.position, player.transform.position, Color.white, 1000);

        //         GameObject canon = canons.ins(transform.position, Quaternion.identity);
        //         Rigidbody canonRb = canon.GetComponent<Rigidbody>();
        //         canonRb.AddForce(transform.forward * ChangeFirePower(), ForceMode.Impulse);
        //         yield return new WaitForSeconds(rapid);
        //     }
        // }

    }
}
