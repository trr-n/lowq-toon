using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var a = Mathf.Sin(Time.time);
        var aa = transform.position;
        aa.x = a;
    }
}
