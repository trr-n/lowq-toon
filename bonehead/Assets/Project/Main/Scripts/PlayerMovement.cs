using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 initPos;

    GameObject me;

    void Start()
    {
        Gets();

        InitPos(initPos);
    }

    void Gets()
    {
        me = this.gameObject;
    }

    void Update()
    {
        Moves(basisHor: 20, basisVer: 18, boostMag: 1.5f);
        Jumps(power: 123);
    }

    void InitPos(Vector3 pos) => me.transform.position = pos;

    void Moves(float basisHor, float basisVer, float? boostMag)
    {
        float h = Input.GetAxis("Horizontal"),
            v = Input.GetAxis("Vertical");
        Vector3 hv = new(h * basisHor, 0, v * basisVer);
        if (true && Input.GetKeyDown(KeyCode.LeftShift))
        {

        }
    }

    void Jumps(float power)
    {

    }
}
