using System;

namespace UnityEngine
{
    public struct Vector2Int : IEquatable<Vector2Int>
    {

        public int x { get; set; }

        public int y { get; set; }

        public int this[int index]
        {
            get
            {
                int result;
                if (index != 0)
                {
                    if (index != 1)
                    {
                        throw new IndexOutOfRangeException(string.Format("Invalid Vector2Int index addressed: {0}!", index));
                    }
                    result = y;
                }
                else
                {
                    result = x;
                }
                return result;
            }
            set
            {
                if (index != 0)
                {
                    if (index != 1)
                    {
                        throw new IndexOutOfRangeException(string.Format("Invalid Vector2Int index addressed: {0}!", index));
                    }
                    y = value;
                }
                else
                {
                    x = value;
                }
            }
        }

        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y);
            }
        }

        public int sqrMagnitude
        {
            get
            {
                return x * x + y * y;
            }
        }

        public static Vector2Int zero { get; } = new Vector2Int(0, 0);

        public static Vector2Int one { get; } = new Vector2Int(1, 1);

        public static Vector2Int up { get; } = new Vector2Int(0, 1);

        public static Vector2Int down { get; } = new Vector2Int(0, -1);

        public static Vector2Int left { get; } = new Vector2Int(-1, 0);

        public static Vector2Int right { get; } = new Vector2Int(1, 0);

        public Vector2Int(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Set(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Distance(Vector2Int a, Vector2Int b)
        {
            float num = a.x - b.x;
            float num2 = a.y - b.y;
            return (float)Math.Sqrt(num * num + num2 * num2);
        }

        public static Vector2Int Min(Vector2Int lhs, Vector2Int rhs)
        {
            return new Vector2Int(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y));
        }

        public static Vector2Int Max(Vector2Int lhs, Vector2Int rhs)
        {
            return new Vector2Int(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y));
        }

        public static Vector2Int Scale(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x * b.x, a.y * b.y);
        }

        public void Scale(Vector2Int scale)
        {
            x *= scale.x;
            y *= scale.y;
        }

        public void Clamp(Vector2Int min, Vector2Int max)
        {
            x = Math.Max(min.x, x);
            x = Math.Min(max.x, x);
            y = Math.Max(min.y, y);
            y = Math.Min(max.y, y);
        }

        public static implicit operator Vector2(Vector2Int v)
        {
            return new Vector2(v.x, v.y);
        }

        public static Vector2Int FloorToInt(Vector2 v)
        {
            return new Vector2Int(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y));
        }

        public static Vector2Int CeilToInt(Vector2 v)
        {
            return new Vector2Int(Mathf.CeilToInt(v.x), Mathf.CeilToInt(v.y));
        }

        public static Vector2Int RoundToInt(Vector2 v)
        {
            return new Vector2Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
        }

        public static Vector2Int operator -(Vector2Int v)
        {
            return new Vector2Int(-v.x, -v.y);
        }

        public static Vector2Int operator +(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x + b.x, a.y + b.y);
        }

        public static Vector2Int operator -(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x - b.x, a.y - b.y);
        }

        public static Vector2Int operator *(Vector2Int a, Vector2Int b)
        {
            return new Vector2Int(a.x * b.x, a.y * b.y);
        }

        public static Vector2Int operator *(int a, Vector2Int b)
        {
            return new Vector2Int(a * b.x, a * b.y);
        }

        public static Vector2Int operator *(Vector2Int a, int b)
        {
            return new Vector2Int(a.x * b, a.y * b);
        }

        public static Vector2Int operator /(Vector2Int a, int b)
        {
            return new Vector2Int(a.x / b, a.y / b);
        }

        public static bool operator ==(Vector2Int lhs, Vector2Int rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static bool operator !=(Vector2Int lhs, Vector2Int rhs)
        {
            return !(lhs == rhs);
        }

        public override bool Equals(object other)
        {
            bool flag = !(other is Vector2Int);
            return !flag && Equals((Vector2Int)other);
        }

        public bool Equals(Vector2Int other)
        {
            return x.Equals(other.x) && y.Equals(other.y);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", x, y );
        }
    }
}
