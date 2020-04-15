
using System;

namespace UnityEngine
{
    public struct Mathf
    {
        public static float Clamp(float value, float min, float max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }
            return value;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
            {
                value = min;
            }
            else if (value > max)
            {
                value = max;
            }
            return value;
        }

        public static float Clamp01(float value)
        {
            float result = value;
            if (value < 0f)
            {
                result = 0f;
            }
            else if (value > 1f)
            {
                result = 1f;
            }
            return result;
        }

        public static float Min(float a, float b)
        {
            return (a < b) ? a : b;
        }
        public static int Min(int a, int b)
        {
            return (a < b) ? a : b;
        }


        public static float Max(float a, float b)
        {
            return (a > b) ? a : b;
        }
        public static int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }

        public static int CeilToInt(float f)
        {
            return (int)Math.Ceiling(f);
        }
        public static int RoundToInt(float f)
        {
            return (int)Math.Round(f);
        }

        public static int FloorToInt(float f)
        {
            return (int)Math.Floor(f);
        }
    }
}