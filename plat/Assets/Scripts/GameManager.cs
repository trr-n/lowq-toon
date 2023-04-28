using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        Physics.gravity = Mine.Scenes.MainGravity;
    }
}
