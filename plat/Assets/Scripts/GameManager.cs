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

    public enum Click4Shooting
    {
        Left = 0, Right = 1
    }
    [SerializeField]
    [Tooltip("射撃キー")]
    Click4Shooting click4shooting = Click4Shooting.Left;
    public Click4Shooting Click4Shoot => click4shooting;

    void Start()
    {
        Physics.gravity = gravity;
    }

    void Update()
    {
    }
}
