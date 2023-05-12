using System;
namespace Toon.Extend
{
    public static class Cast
    {
        public static float single(this object num) => (float)num;

        public static int inte(this object num) => (int)num;

        public static T cast<T>(this object obj)
        {
            try
            {
                return (T)obj;
            }
            catch (InvalidCastException e)
            {
                throw e;
                // return (T)obj;
            }
        }

        // public static T Convert<T>(string key)
        // {
        //     string value = Config.GetValue(key);

        //     Type _t = typeof(T);

        //     if (_t == typeof(int))
        //     {
        //         return (T)(object)int.Parse(value); // 一度object型にキャストする
        //     }
        //     else if (_t == typeof(bool))
        //     {
        //         return (T)(object)bool.Parse(value); // 一度object型にキャストする
        //     }
        //     throw new NotSupportedException(_t + " is not suported.");
        // }
    }
}
