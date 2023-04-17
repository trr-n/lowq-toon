using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet__ : MonoBehaviour
{
    [SerializeField]
    Bullet bullet;

    [SerializeField]
    float fireRate;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= fireRate)
        {
            bullet.Fire(power: Vector3.forward);
        }
    }
}
