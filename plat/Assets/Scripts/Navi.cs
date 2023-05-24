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
        HP hp;

        [SerializeField]
        [Tooltip("player")]
        GameObject target;

        [SerializeField]
        NavMeshAgent agent;

        [SerializeField]
        float speed;

        float distance;

        void Start()
        {
            agent ??= GetComponent<NavMeshAgent>();
            target ??= GameObject.FindGameObjectWithTag(constant.Player);
            agent.speed = speed;
        }

        void Update()
        {
            agent.SetDestination(target.transform.position);

            if (hp.IsZero())
            {
                Destroy(this.gameObject);
            }
        }

        void OnCollisionEnter(Collision info)
        {
            if (info.compare(constant.Missile))
            {
                hp.Damage(50);
            }
        }
    }
}
