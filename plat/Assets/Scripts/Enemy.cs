using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int maxHp = 100;
    int hp;

    void Start()
    {
        hp = maxHp;
    }

    void Update()
    {
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Bullet"))
        {
            hp -= 10;
            Destroy(c.gameObject);
        }
    }
}
