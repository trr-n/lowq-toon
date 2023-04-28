using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    GameManager gm;

    bool shootable;
    /// <summary>
    /// 発砲可能ならtrue
    /// </summary>
    public bool Shootable => shootable;

    bool isRotating;
    /// <summary>
    /// プレイヤーが回転していたらtrue
    /// </summary>
    public bool IsRotating { get => isRotating; set => isRotating = value; }

    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }

    void Update()
    {
        print($"shootable: {shootable}");
        var click = Input.GetMouseButtonDown((int)gm.Click4Shoot);
        // 射撃キー押したら回転フラグをtrue
        if (click)
        {
            isRotating = true;
        }
        if (click && !isRotating)
        {
            shootable = true;
        }
    }
}
