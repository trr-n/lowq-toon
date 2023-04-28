using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    bool shootable;
    public bool Shootable { get => shootable; set => shootable = value; }

    bool isRotating;
    public bool IsRotating { get => isRotating; set => isRotating = value; }

    [SerializeField]
    int click4shoot = 0;
    public int Click4Shoot => click4shoot;
    public int CC { get => 0; }

    void Update()
    {
        print(CC);

        var clicks = Input.GetMouseButtonDown(click4shoot);

        //shootable = !isRotating;// && clicks;

        if (clicks)
        {
            isRotating = true;
            shootable = true;
        }
    }
}
