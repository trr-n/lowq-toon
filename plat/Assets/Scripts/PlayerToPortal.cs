using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class PlayerToPortal : MonoBehaviour
    {
        [SerializeField]
        Transform targetT;
        [SerializeField]
        GameObject setumei;
        void Update()
        {
            var ray = new Ray(transform.position, targetT.position - transform.position);
            var distance = Vector3.Distance(targetT.position, transform.position) + 1;
            setumei.SetActive(Physics.Raycast(
                ray, out var hit2, distance) && hit2.collider.CompareTag(constant.Player));
        }
    }
}
