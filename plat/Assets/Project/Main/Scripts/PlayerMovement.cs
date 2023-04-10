using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    class Init
    {
        public static Vector3 Pos = new(0, 70, 0);
    }

    GameObject self;

    void Start()
    {
        GetStart();

        Initialize(position: Init.Pos);
    }

    void GetStart()
    {
        self = this.gameObject;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += Vector3.forward * Time.deltaTime;

        Moves(basis: 20, sneak: 10);
        Jumps(power: 10);
    }

    void Initialize(Vector3 position) => self.transform.position = position;

    // move speed will be down during shooting
    void Moves(float basis, float sneak)
    {
        float h = Input.GetAxis("Horizontal"), v = Input.GetAxis("Vertical");
        Vector3 hv = new(h, 0, v);
        float add = basis;
        if (Input.GetKeyDown(KeyCode.LeftShift)) { add = sneak; }
        else { add = basis; }
        self.transform.Translate(hv * add * Time.deltaTime);
    }

    void Jumps(float power)
    {

    }
}
