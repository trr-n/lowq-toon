﻿using System;
using UnityEngine;

namespace Toon.Extend
{
    public static class Numeric
    {
        public static float Clamping(this float n, float min, float max) => Mathf.Clamp(n, min, max);
        public static int Clamping(this int n, int min, int max) => Mathf.Clamp(n, min, max);
        public static float Clamp(float n, float min, float max) => Mathf.Clamp(n, min, max);
        public static int Clamp(int n, int min, int max) => Mathf.Clamp(n, min, max);
        public static float Round(float n, int digit = 0) => MathF.Round(n, digit);
        public static int Round(int n, int digit = 0) => ((int)MathF.Round(n, digit));
        public static int Percent(float n, int digit = 0) => ((int)MathF.Round(n * 100, digit));
        public static float Ratio(float w, float t) => (float)w / t;
        public static bool AlmostSame(this float n1, float n2) => Mathf.Approximately(n1, n2);
        public static bool AlmostSame(Vector3 n1, Vector3 n2)
            => Mathf.Approximately(n1.x, n2.x) && Mathf.Approximately(n1.y, n2.y) && Mathf.Approximately(n1.z, n2.z);
        public static bool IsPrime(int n) // https://excelmath.atelierkobato.com/composite/
        {
            if (n < 2 || (n % 2 == 0 && n != 2)) return false;
            for (int i = 2; i < Mathf.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}