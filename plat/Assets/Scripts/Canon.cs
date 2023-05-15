using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class Canon : MonoBehaviour
    {
        [SerializeField] Vector3 towerPosition = new(8.731677f, 3.177724f, -7.152449f);
        [SerializeField] float diffy = 2.65f;
        [SerializeField] GameObject[] canons;
        GameObject tmp;

        GameObject player;
        Vector3 direction;
        Quaternion lookAt;
        Quaternion offset;
        Quaternion diff;

        bool isHaving;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag(constant.Player);
            transform.set(towerPosition);
        }

        void Update()
        {
            LookingAtPlayer();
            FireForPlayer();
        }

        void LookingAtPlayer()
        {
            //* init diff x: 17.98, y: 2.65, z: -1.63
            diff = Quaternion.Euler(0, diffy, 0);
            direction = transform.position - player.transform.position;
            lookAt = Quaternion.LookRotation(direction, Vector3.up);
            offset = Quaternion.FromToRotation(Vector3.forward, Vector3.forward);
            transform.rotation = lookAt * offset;
        }

        void FireForPlayer()
        {
            GameObject canon = canons.ins(transform.position, Quaternion.identity);
            canon.TryGetComponent<Rigidbody>(out Rigidbody canonRb);
            canonRb.AddForce(transform.position - player.transform.position, ForceMode.Impulse);
        }
    }
}
