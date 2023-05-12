using System;

namespace Toon.Extend
{
    public static class Typing
    {
        public static Type get(object obj) => obj.GetType();

        public static float single(this object num) => (float)num;

        public static int inte(this object num) => (int)num;
    }
}
