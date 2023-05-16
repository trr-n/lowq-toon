using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Canon : MonoBehaviour
    {
        [SerializeField] float power = 20;
        [SerializeField] GameObject[] canons;
        [SerializeField] GameObject towerDeco;
        [SerializeField] GameObject player;

        Vector3 direction;
        Transform towerT;

        bool isHaving;
        float rapid = 1;
        float distance;

        void Start()
        {
            StartCoroutine(Trigger());
        }

        void Update()
        {
            towerT = towerDeco.transform;
            // fix position
            direction = towerT.position - player.transform.position;
        }

        // todo
        // 1, XX以上XX以下ならXXみたいに細かく手動で決める
        float ChangeFirePower()
        {
            Vector3 self = transform.position, play = player.transform.position;
            distance = Vector3.Distance(self, play);
            (distance * 10).show();
            return distance; // 仮
        }

        IEnumerator Trigger()
        {
            while (true)
            {
                GameObject canon = canons.ins(transform.position, Quaternion.identity);
                Rigidbody canonRb = canon.GetComponent<Rigidbody>();
                // canonRb.AddForce(transform.forward * power, ForceMode.Impulse);
                canonRb.AddForce(transform.forward * ChangeFirePower(), ForceMode.Impulse);
                yield return new WaitForSeconds(rapid);
            }
        }
    }
}
