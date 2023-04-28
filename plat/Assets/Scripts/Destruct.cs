using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    [SerializeField]
    float life;

    void Start()
    {
        Destroy(this.gameObject, life);
    }
}
