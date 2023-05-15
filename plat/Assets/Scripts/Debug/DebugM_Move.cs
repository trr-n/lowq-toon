using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class DebugM_Move : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    ThirdPersonUserControl tpuc;
    [SerializeField]
    Text tt;

    void Start()
    {
        tpuc = player.GetComponent<ThirdPersonUserControl>();
    }

    void Update()
    {
        tt.text = $"mmove: {tpuc.M_Move}";
        tt.color = Color.white;
    }
}
