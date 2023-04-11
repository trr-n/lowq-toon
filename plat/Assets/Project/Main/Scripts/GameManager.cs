using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector3 gravity = new(0, -9.81f, 0);

    void Start()
    {
        // default gravity
        Physics.gravity = gravity;
    }

    void Update()
    {

    }
}
