using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

public class bb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision info)
    {
        if (info.gameObject.CompareTag("Missile"))
        {
            "hit".show();
        }
    }

}
