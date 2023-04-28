using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class Deb3 : MonoBehaviour
{
    [SerializeField]
    Text t;

    PlayerInput pi;

    void Start()
    {
        pi = GameObject.Find("player0").GetComponent<PlayerInput>();
    }

    void Update()
    {
        t.text = $"Shootable: {pi.Shootable}, IsRotating: {pi.IsRotating}";
    }
}
