using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Toon
{
    public class NavTest : MonoBehaviour
    {
        [SerializeField]
        GameObject target;

        [SerializeField]
        NavMeshAgent agent;

        void Update()
        {
            agent.destination = target.transform.position;
        }
    }
}
