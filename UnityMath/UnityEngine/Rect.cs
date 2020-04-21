using System;
using System.Globalization;

namespace UnityEngine
{
    public struct Rect : IEquatable<Rect>
    {
        public float x;
        public float y;
        public float width;
        public float height;
        public float xMax { get { return x + width; } }
        public float yMax { get { return y + height; } }
        public Rect(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public Rect(Vector2 position, Vector2 size)
        {
            x = position.x;
            y = position.y;
            width = size.x;
            height = size.y;
        }

        public bool Contains(Vector2 point)
        {
            return point.x >= x && point.x < (x+width) && point.y >= y && point.y < y+height;
        }

        public bool Overlaps(Rect other)
        {
            return other.xMax > x && other.x < xMax && other.yMax > y && other.y < yMax;
        }

        public override bool Equals(object other)
        {
            return other is Rect && Equals((Rect)other);
        }

        public bool Equals(Rect other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && width.Equals(other.width) && height.Equals(other.height);
        }
        public override int GetHashCode()
        {
            return x.GetHashCode() ^ width.GetHashCode() << 2 ^ y.GetHashCode() >> 2 ^ height.GetHashCode() >> 1;
        }

        public static bool operator ==(Rect lhs, Rect rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y && lhs.width == rhs.width && lhs.height == rhs.height;
        }

        public static bool operator !=(Rect lhs, Rect rhs)
        {
            return !(lhs == rhs);
        }

        public override string ToString()
        {
            return string.Format("(x:{0:F2}, y:{1:F2}, width:{2:F2}, height:{3:F2})", x, y, width, height);
        }
        public string ToString(string format)
        {
            return string.Format("(x:{0}, y:{1}, width:{2}, height:{3})", 
                x.ToString(format, CultureInfo.InvariantCulture.NumberFormat),
                y.ToString(format, CultureInfo.InvariantCulture.NumberFormat),
                width.ToString(format, CultureInfo.InvariantCulture.NumberFormat),
                height.ToString(format, CultureInfo.InvariantCulture.NumberFormat)
                );
        }
    }
}
