using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toon
{
    public static class Const
    {
        public static readonly string
        //------------------------------------------------------------------------------
        // SCENE NAME
        //------------------------------------------------------------------------------
        Main = "Main",
        Title = "Title",

        //------------------------------------------------------------------------------
        // KEY NAME?
        //------------------------------------------------------------------------------
        Hor = "Horizontal",
        Ver = "Vertical",
        Jump = "Jump",
        MX = "Mouse X",
        MY = "Mouse Y",
        Volume = "Volume",

        //------------------------------------------------------------------------------
        // TAG NAME
        //------------------------------------------------------------------------------
        Player = "Player",
        Ground = "Ground",
        MainCam = "MainCamera",
        Cam = "Cam",
        Gun = "Gun"
        ;

        public static readonly Vector3 MainGravity = new(0, -9.81f, 0);
        public static readonly KeyCode Crouch = KeyCode.C;
    }
}
