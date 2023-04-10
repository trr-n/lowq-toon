using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    GameObject self;

    void Start()
    {

    }

    void Update()
    {
        CameraRotate(sensi: null);
    }

    void CameraRotate(float? sensi)
    {
        float mx = Input.GetAxis(Mine.Keys.MX), my = Input.GetAxis(Mine.Keys.MY);
        if (mx > 0.001f)
            transform.RotateAround(self.transform.position, Vector3.up, mx);
    }
}
