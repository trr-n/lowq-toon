using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    [SerializeField]
    float life;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > life)
        {
            Destroy(this.gameObject);
            timer = 0;
        }
    }
}
