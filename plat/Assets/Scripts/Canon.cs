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
        readonly float min = 2, max = 20;

        enum Range { close = 0, medium, @long }
        float[] ratio = new float[3] { 10, 15, 27 };

        void Start()
        {
            StartCoroutine(Trigger());
        }

        void Update()
        {
            direction = transform.position - player.transform.position;
            // ChangeFirePower().show();
        }

        // todo 距離によって力を変動させる
        // closest point: 10.54776f, 10.59995f
        public float ChangeFirePower()
        {
            power = numeric.clamp(power, 0.5f, 100);
            Vector3 self = transform.position, play = player.transform.position;
            distance = Vector3.Distance(self, play);
            float judgeDistance = distance - 10;
            if (judgeDistance < 10)
            {
                scale = ratio[0];
            }
            scale =
                judgeDistance < 10 ? ratio[0] :
                judgeDistance < 11 ? ratio[1] :
                judgeDistance < 12 ? ratio[2] :
                throw new Exception();

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
