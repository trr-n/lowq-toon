using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Toon.Extend;

namespace Toon
{
    public class Navi : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("player")]
        GameObject target;

        [SerializeField]
        NavMeshAgent agent;

        [SerializeField]
        float speed;

        [SerializeField]
        [Tooltip("NPCとの距離がescapeで追尾")]
        float chase = 13;

        float distance;

        void Start()
        {
            agent.speed = speed;
        }

        void Update()
        {
            distance = Vector3.Distance(transform.position, target.transform.position);
            distance.show();
            if (distance >= chase)
            {
                return;
            }
            agent.SetDestination(target.transform.position);
        }
    }
}
