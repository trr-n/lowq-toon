using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toon.Extend;

namespace Toon
{
    public class CursorSetting : MonoBehaviour
    {
        void Start()
        {
            DontDestroyOnLoad(this);
        }

        void Update()
        {
            if (scene.active() == constant.Main)
                visual.cursor(c.hide, v.inscene);
            else
                visual.cursor(c.show, v.unlocked);
        }
    }
}
