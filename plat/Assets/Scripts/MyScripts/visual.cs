using UnityEngine;

namespace Toon.Extend
{
    public enum c { hide, show }
    public static class visual
    {
        public static float fps() => Mathf.Floor(1 / Time.deltaTime);

        public static string timer(int digits) => Time.time.ToString("F" + digits);

        public static void cursor(c status) => Cursor.visible = status != c.hide;

        public static bool timer(this float timer, float limit) => timer < limit;
    }
}
