using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // shootable が true のときにクリックしたら発砲
    bool shootable;
    /// <summary>
    /// 発砲可能ならtrue
    /// </summary>
    public bool Shootable { get => shootable; set => shootable = value; }

    bool isRotating;
    /// <summary>
    /// プレイヤーが回転していたらtrue
    /// </summary>
    public bool IsRotating { get => isRotating; set => isRotating = value; }

    [SerializeField]
    int click4shoot = 0;
    /// <summary>
    /// 射撃キー
    /// </summary>
    public int Click4Shoot => click4shoot;

    void Update()
    {
        var clicks = Input.GetMouseButtonDown(click4shoot);

        // クリックして回転してなかったらtrue
        //shootable = !isRotating;// && clicks;

        // 射撃キー押したら回転フラグをtrue
        if (clicks)
        {
            isRotating = true;
            shootable = true;
        }
    }
}
