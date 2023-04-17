using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 発砲用rigidbody
    /// </summary>
    [SerializeField]
    Rigidbody rb;

    /// <summary>
    /// 発砲
    /// </summary>
    /// <param name="power">力を加える方向</param>
    public void Fire(Vector3 power)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = power;
    }
}
