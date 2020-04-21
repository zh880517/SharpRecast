using System;

namespace UnityEngine
{
    public struct Bounds : IEquatable<Bounds>
    {
        public Vector3 Min;
        public Vector3 Max;

        public Bounds(Vector3 min, Vector3 max)
        {
            Min = min;
            Max = max;
        }

        public bool Intersects(Bounds b)
        {
            return !(Min.x > b.Max.x || Max.x < b.Min.x
                || Min.y > b.Max.y || Max.y < b.Min.y
                || Min.z > b.Max.z || Max.z < b.Min.z);
        }


        public bool Equals(Bounds other)
        {
            return Min == other.Min && Max == other.Max;
        }
        public override bool Equals(object obj)
        {
            Bounds? b = obj as Bounds?;
            if (b.HasValue)
                return Equals(b.Value);

            return false;
        }
        public override int GetHashCode()
        {
            return Min.GetHashCode() ^ Max.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Min: {0}, Max: {1}", Min, Max);
        }
        public string ToString(string format)
        {
            return string.Format("Min: {0}, Max: {1}", Min.ToString(format), Max.ToString(format));
        }
    }
}
