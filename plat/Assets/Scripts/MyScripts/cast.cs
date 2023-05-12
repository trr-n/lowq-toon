namespace Toon.Extend
{
    public static class Cast
    {
        public static float single(this object num) => (float)num;
        public static int inte(this object num) => (int)num;
        // public static T cast<T>(this object obj) => (T)obj;
    }
}
