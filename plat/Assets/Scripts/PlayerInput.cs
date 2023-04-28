using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    // shootable �� true �̂Ƃ��ɃN���b�N�����甭�C
    bool shootable;
    /// <summary>
    /// ���C�\�Ȃ�true
    /// </summary>
    public bool Shootable { get => shootable; set => shootable = value; }

    bool isRotating;
    /// <summary>
    /// �v���C���[����]���Ă�����true
    /// </summary>
    public bool IsRotating { get => isRotating; set => isRotating = value; }

    [SerializeField]
    int click4shoot = 0;
    /// <summary>
    /// �ˌ��L�[
    /// </summary>
    public int Click4Shoot => click4shoot;

    void Update()
    {
        var clicks = Input.GetMouseButtonDown(click4shoot);

        // �N���b�N���ĉ�]���ĂȂ�������true
        //shootable = !isRotating;// && clicks;

        // �ˌ��L�[���������]�t���O��true
        if (clicks)
        {
            isRotating = true;
            shootable = true;
        }
    }
}
