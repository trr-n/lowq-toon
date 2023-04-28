using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    GameManager gm;

    bool shootable;
    /// <summary>
    /// ���C�\�Ȃ�true
    /// </summary>
    public bool Shootable => shootable;

    bool isRotating;
    /// <summary>
    /// �v���C���[����]���Ă�����true
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
        // �ˌ��L�[���������]�t���O��true
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
