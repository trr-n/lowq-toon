using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

public class a : MonoBehaviour
{
    [SerializeField]
    GameObject aa;

    void Start()
    {
        StartCoroutine(aaa());
    }
    IEnumerator aaa()
    {
        while (true)
        {
            var a = Instantiate(aa, transform.position, Quaternion.identity);
            a.GetComponent<Rigidbody>().AddForce(Vector3.forward * 100, ForceMode.Impulse);
            "aaa".show();
            yield return new WaitForSeconds(1);
        }
    }

}
