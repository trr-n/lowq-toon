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
            if (Section.Active() == Constant.Main)
                Visual.Cursor(c.hide, v.inscene);
            else
                Visual.Cursor(c.show, v.unlocked);
        }
    }
}
