using System;

namespace UnityEngine
{
    public struct Vector3 : IEquatable<Vector3>
    {
        public const float kEpsilon = 1E-05f;

        public const float kEpsilonNormalSqrt = 1E-15f;
        public float x;
        public float y;
        public float z;
        public static readonly Vector3 zero = new Vector3(0f, 0f, 0f);

        public static readonly Vector3 one = new Vector3(1f, 1f, 1f);

        public static readonly Vector3 up = new Vector3(0f, 1f, 0f);

        public static readonly Vector3 down = new Vector3(0f, -1f, 0f);

        public static readonly Vector3 left = new Vector3(-1f, 0f, 0f);

        public static readonly Vector3 right = new Vector3(1f, 0f, 0f);

        public static readonly Vector3 forward = new Vector3(0f, 0f, 1f);

        public static readonly Vector3 back = new Vector3(0f, 0f, -1f);

        public static readonly Vector3 positiveInfinity = new Vector3(float.PositiveInfinity, float.PositiveInfinity, float.PositiveInfinity);

        public static readonly Vector3 negativeInfinity = new Vector3(float.NegativeInfinity, float.NegativeInfinity, float.NegativeInfinity);
        public float this[int index]
        {
            get
            {
                float result;
                switch (index)
                {
                    case 0:
                        result = x;
                        break;
                    case 1:
                        result = y;
                        break;
                    case 2:
                        result = z;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
                return result;
            }
            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Vector3 index!");
                }
            }
        }

        public Vector3 normalized
        {
            get
            {
                return Normalize(this);
            }
        }
        public float magnitude => (float)Math.Sqrt(x * x + y * y + z * z);
        public float sqrMagnitude => x * x + y * y + z * z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            z = 0f;
        }
        public void Set(float newX, float newY, float newZ)
        {
            x = newX;
            y = newY;
            z = newZ;
        }
        public static Vector3 Scale(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }

        public void Scale(Vector3 scale)
        {
            x *= scale.x;
            y *= scale.y;
            z *= scale.z;
        }
        public static Vector3 Cross(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.y * rhs.z - lhs.z * rhs.y, lhs.z * rhs.x - lhs.x * rhs.z, lhs.x * rhs.y - lhs.y * rhs.x);
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2 ^ z.GetHashCode() >> 2;
        }
        public override bool Equals(object other)
        {
            return (other is Vector3) && Equals((Vector3)other);
        }

        public bool Equals(Vector3 other)
        {
            return x == other.x && y == other.y && z == other.z;
        }
        public static Vector3 Reflect(Vector3 inDirection, Vector3 inNormal)
        {
            float num = -2f * Dot(inNormal, inDirection);
            return new Vector3(num * inNormal.x + inDirection.x, num * inNormal.y + inDirection.y, num * inNormal.z + inDirection.z);
        }
        public static Vector3 Normalize(Vector3 value)
        {
            float num = Magnitude(value);
            Vector3 result;
            if (num > 1E-05f)
            {
                result = value / num;
            }
            else
            {
                result = zero;
            }
            return result;
        }
        public void Normalize()
        {
            float num = Magnitude(this);
            if (num > 1E-05f)
            {
                this /= num;
            }
            else
            {
                this = zero;
            }
        }

        public static float Dot(Vector3 lhs, Vector3 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }

        public static Vector3 Project(Vector3 vector, Vector3 onNormal)
        {
            float num = Dot(onNormal, onNormal);
            bool flag = num < float.Epsilon;
            Vector3 result;
            if (flag)
            {
                result = zero;
            }
            else
            {
                float num2 = Dot(vector, onNormal);
                result = new Vector3(onNormal.x * num2 / num, onNormal.y * num2 / num, onNormal.z * num2 / num);
            }
            return result;
        }

        public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal)
        {
            float num = Dot(planeNormal, planeNormal);
            bool flag = num < float.Epsilon;
            Vector3 result;
            if (flag)
            {
                result = vector;
            }
            else
            {
                float num2 = Dot(vector, planeNormal);
                result = new Vector3(vector.x - planeNormal.x * num2 / num, vector.y - planeNormal.y * num2 / num, vector.z - planeNormal.z * num2 / num);
            }
            return result;
        }

        public static float Angle(Vector3 from, Vector3 to)
        {
            float num = (float)Math.Sqrt(from.sqrMagnitude * to.sqrMagnitude);
            float result;
            if (num < 1E-15f)
            {
                result = 0f;
            }
            else
            {
                float num2 = Mathf.Clamp(Dot(from, to) / num, -1f, 1f);
                result = (float)Math.Acos(num2) * 57.29578f;
            }
            return result;
        }

        public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis)
        {
            float num = Vector3.Angle(from, to);
            float num2 = from.y * to.z - from.z * to.y;
            float num3 = from.z * to.x - from.x * to.z;
            float num4 = from.x * to.y - from.y * to.x;
            float num5 = Math.Sign(axis.x * num2 + axis.y * num3 + axis.z * num4);
            return num * num5;
        }
        public static float Distance(Vector3 a, Vector3 b)
        {
            float num = a.x - b.x;
            float num2 = a.y - b.y;
            float num3 = a.z - b.z;
            return (float)Math.Sqrt(num * num + num2 * num2 + num3 * num3);
        }

        public static Vector3 ClampMagnitude(Vector3 vector, float maxLength)
        {
            float sqrMagnitude = vector.sqrMagnitude;
            Vector3 result;
            if (sqrMagnitude > maxLength * maxLength)
            {
                float num = (float)Math.Sqrt(sqrMagnitude);
                float num2 = vector.x / num;
                float num3 = vector.y / num;
                float num4 = vector.z / num;
                result = new Vector3(num2 * maxLength, num3 * maxLength, num4 * maxLength);
            }
            else
            {
                result = vector;
            }
            return result;
        }

        public static float Magnitude(Vector3 vector)
        {
            return (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        }

        public static float SqrMagnitude(Vector3 vector)
        {
            return vector.x * vector.x + vector.y * vector.y + vector.z * vector.z;
        }
        public static Vector3 Min(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y), Mathf.Min(lhs.z, rhs.z));
        }
        public static Vector3 Max(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y), Mathf.Max(lhs.z, rhs.z));
        }
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector3 operator -(Vector3 a)
        {
            return new Vector3(-a.x, -a.y, -a.z);
        }

        public static Vector3 operator *(Vector3 a, float d)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);
        }

        public static Vector3 operator *(float d, Vector3 a)
        {
            return new Vector3(a.x * d, a.y * d, a.z * d);
        }

        public static Vector3 operator /(Vector3 a, float d)
        {
            return new Vector3(a.x / d, a.y / d, a.z / d);
        }

        public static bool operator ==(Vector3 lhs, Vector3 rhs)
        {
            float num = lhs.x - rhs.x;
            float num2 = lhs.y - rhs.y;
            float num3 = lhs.z - rhs.z;
            float num4 = num * num + num2 * num2 + num3 * num3;
            return num4 < 9.99999944E-11f;
        }

        public static bool operator !=(Vector3 lhs, Vector3 rhs)
        {
            return !(lhs == rhs);
        }
        public override string ToString()
        {
            return string.Format("({0:F1}, {1:F1}, {2:F1})", x, y, z);
        }
        public string ToString(string format)
        {
            return string.Format("({0}, {1}, {2})",
                x.ToString(format, System.Globalization.CultureInfo.InvariantCulture.NumberFormat),
                y.ToString(format, System.Globalization.CultureInfo.InvariantCulture.NumberFormat),
                z.ToString(format, System.Globalization.CultureInfo.InvariantCulture.NumberFormat));
        }

    }

}
