using UnityEngine;

namespace Toon.Extend
{
    public static class input
    {
        public static bool down(int mouse) => Input.GetMouseButtonDown(mouse);
        public static bool down(KeyCode key) => Input.GetKeyDown(key);
        public static bool down(string name) => Input.GetButtonDown(name);

        public static bool pressed(int mouse) => Input.GetMouseButton(mouse);
        public static bool pressed(KeyCode key) => Input.GetKey(key);
        public static bool pressed(string name) => Input.GetButton(name);
    }
}