using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 重力
    /// </summary>
    [SerializeField]
    Vector3 gravity = new(0, -9.81f, 0);

    void Start()
    {
        Physics.gravity = gravity;
    }
}
