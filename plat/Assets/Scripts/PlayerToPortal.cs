using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon
{
    public class PlayerToPortal : MonoBehaviour
    {
        [SerializeField]
        Transform targetT;

        bool looking = false;
        public bool Looking => looking;

        Vector3 direction;
        float distance;

        void Start()
        {

        }

        void Update()
        {
            direction = targetT.position - transform.position;
            distance = Vector3.Distance(targetT.position, transform.position);
            Ray ray = new(transform.position, direction);
            Debug.DrawRay(ray.origin, ray.direction, Color.white, Time.deltaTime, true);
            looking = false;
            if (Physics.Raycast(ray, out var hit, distance))
            {
                if (hit.collider)
                {
                    print("hit for " + hit.collider.name);
                }
                if (hit.collider.CompareTag(constant.Portal))
                {
                    looking = true;
                    print("looking at portal");
                }
            }
        }
    }
}
