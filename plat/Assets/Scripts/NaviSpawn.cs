using System.Collections;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class NaviSpawn : MonoBehaviour
    {
        [SerializeField]
        GameObject navi;

        void Start()
        {
            navi ??= GameObject.FindGameObjectWithTag("Enemy");
            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(20);
                var a = Instantiate(navi, transform.position, Quaternion.identity);
            }
        }
    }
}
