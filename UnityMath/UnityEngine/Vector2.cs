using System;

namespace UnityEngine
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public float x;

        public float y;
        public const float kEpsilon = 1E-05f;

        public const float kEpsilonNormalSqrt = 1E-15f;

        public float this[int index]
        {
            get
            {
                float result;
                if (index != 0)
                {
                    if (index != 1)
                    {
                        throw new IndexOutOfRangeException("Invalid Vector2 index!");
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
                        throw new IndexOutOfRangeException("Invalid Vector2 index!");
                    }
                    y = value;
                }
                else
                {
                    x = value;
                }
            }
        }

        public Vector2 normalized
        {
            get
            {
                Vector2 result = new Vector2(this.x, this.y);
                result.Normalize();
                return result;
            }
        }

        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y);
            }
        }

        public float sqrMagnitude
        {
            get
            {
                return x * x + y * y;
            }
        }

        public static Vector2 zero { get; } = new Vector2(0f, 0f);

        public static Vector2 one { get; } = new Vector2(1f, 1f);

        public static Vector2 up { get; } = new Vector2(0f, 1f);

        public static Vector2 down { get; } = new Vector2(0f, -1f);

        public static Vector2 left { get; } = new Vector2(-1f, 0f);

        public static Vector2 right { get; } = new Vector2(1f, 0f);

        public static Vector2 positiveInfinity { get; } = new Vector2(float.PositiveInfinity, float.PositiveInfinity);

        public static Vector2 negativeInfinity { get; } = new Vector2(float.NegativeInfinity, float.NegativeInfinity);

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void Set(float newX, float newY)
        {
            x = newX;
            y = newY;
        }

        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            t = Mathf.Clamp01(t);
            return new Vector2(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
        }

        public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t)
        {
            return new Vector2(a.x + (b.x - a.x) * t, a.y + (b.y - a.y) * t);
        }

        public static Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
        {
            float num = target.x - current.x;
            float num2 = target.y - current.y;
            float num3 = num * num + num2 * num2;
            Vector2 result;
            if (num3 == 0f || (maxDistanceDelta >= 0f && num3 <= maxDistanceDelta * maxDistanceDelta))
            {
                result = target;
            }
            else
            {
                float num4 = (float)Math.Sqrt(num3);
                result = new Vector2(current.x + num / num4 * maxDistanceDelta, current.y + num2 / num4 * maxDistanceDelta);
            }
            return result;
        }

        public static Vector2 Scale(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public void Scale(Vector2 scale)
        {
            this.x *= scale.x;
            this.y *= scale.y;
        }

        public void Normalize()
        {
            float magnitude = this.magnitude;
            bool flag = magnitude > 1E-05f;
            if (flag)
            {
                this /= magnitude;
            }
            else
            {
                this = Vector2.zero;
            }
        }

        public override string ToString()
        {
            return string.Format("({0:F1}, {1:F1})", x, y);
        }

        public string ToString(string format)
        {
            return string.Format("({0}, {1})", 
                x.ToString(format, System.Globalization.CultureInfo.InvariantCulture.NumberFormat),
                y.ToString(format, System.Globalization.CultureInfo.InvariantCulture.NumberFormat)
            );
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode() << 2;
        }

        public override bool Equals(object other)
        {
            bool flag = !(other is Vector2);
            return !flag && Equals((Vector2)other);
        }

        public bool Equals(Vector2 other)
        {
            return x == other.x && y == other.y;
        }

        public static Vector2 Reflect(Vector2 inDirection, Vector2 inNormal)
        {
            float num = -2f * Vector2.Dot(inNormal, inDirection);
            return new Vector2(num * inNormal.x + inDirection.x, num * inNormal.y + inDirection.y);
        }

        public static Vector2 Perpendicular(Vector2 inDirection)
        {
            return new Vector2(-inDirection.y, inDirection.x);
        }

        public static float Dot(Vector2 lhs, Vector2 rhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y;
        }

        public static float Angle(Vector2 from, Vector2 to)
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

        public static float SignedAngle(Vector2 from, Vector2 to)
        {
            float num = Vector2.Angle(from, to);
            float num2 = Math.Sign(from.x * to.y - from.y * to.x);
            return num * num2;
        }

        public static float Distance(Vector2 a, Vector2 b)
        {
            float num = a.x - b.x;
            float num2 = a.y - b.y;
            return (float)Math.Sqrt(num * num + num2 * num2);
        }

        public static Vector2 ClampMagnitude(Vector2 vector, float maxLength)
        {
            float sqrMagnitude = vector.sqrMagnitude;
            Vector2 result;
            if (sqrMagnitude > maxLength * maxLength)
            {
                float num = (float)Math.Sqrt(sqrMagnitude);
                float num2 = vector.x / num;
                float num3 = vector.y / num;
                result = new Vector2(num2 * maxLength, num3 * maxLength);
            }
            else
            {
                result = vector;
            }
            return result;
        }

        public static float SqrMagnitude(Vector2 a)
        {
            return a.x * a.x + a.y * a.y;
        }

        public float SqrMagnitude()
        {
            return x * x + y * y;
        }

        public static Vector2 Min(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(Mathf.Min(lhs.x, rhs.x), Mathf.Min(lhs.y, rhs.y));
        }

        public static Vector2 Max(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(Mathf.Max(lhs.x, rhs.x), Mathf.Max(lhs.y, rhs.y));
        }


        public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
        {
            smoothTime = Mathf.Max(0.0001f, smoothTime);
            float num = 2f / smoothTime;
            float num2 = num * deltaTime;
            float num3 = 1f / (1f + num2 + 0.48f * num2 * num2 + 0.235f * num2 * num2 * num2);
            float num4 = current.x - target.x;
            float num5 = current.y - target.y;
            Vector2 vector = target;
            float num6 = maxSpeed * smoothTime;
            float num7 = num6 * num6;
            float num8 = num4 * num4 + num5 * num5;
            bool flag = num8 > num7;
            if (flag)
            {
                float num9 = (float)Math.Sqrt((double)num8);
                num4 = num4 / num9 * num6;
                num5 = num5 / num9 * num6;
            }
            target.x = current.x - num4;
            target.y = current.y - num5;
            float num10 = (currentVelocity.x + num * num4) * deltaTime;
            float num11 = (currentVelocity.y + num * num5) * deltaTime;
            currentVelocity.x = (currentVelocity.x - num * num10) * num3;
            currentVelocity.y = (currentVelocity.y - num * num11) * num3;
            float num12 = target.x + (num4 + num10) * num3;
            float num13 = target.y + (num5 + num11) * num3;
            float num14 = vector.x - current.x;
            float num15 = vector.y - current.y;
            float num16 = num12 - vector.x;
            float num17 = num13 - vector.y;
            bool flag2 = num14 * num16 + num15 * num17 > 0f;
            if (flag2)
            {
                num12 = vector.x;
                num13 = vector.y;
                currentVelocity.x = (num12 - vector.x) / deltaTime;
                currentVelocity.y = (num13 - vector.y) / deltaTime;
            }
            return new Vector2(num12, num13);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        public static Vector2 operator -(Vector2 a)
        {
            return new Vector2(-a.x, -a.y);
        }

        public static Vector2 operator *(Vector2 a, float d)
        {
            return new Vector2(a.x * d, a.y * d);
        }

        public static Vector2 operator *(float d, Vector2 a)
        {
            return new Vector2(a.x * d, a.y * d);
        }

        public static Vector2 operator /(Vector2 a, float d)
        {
            return new Vector2(a.x / d, a.y / d);
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            float num = lhs.x - rhs.x;
            float num2 = lhs.y - rhs.y;
            return num * num + num2 * num2 < 9.99999944E-11f;
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return !(lhs == rhs);
        }

        public static implicit operator Vector2(Vector3 v)
        {
            return new Vector2(v.x, v.y);
        }

        public static implicit operator Vector3(Vector2 v)
        {
            return new Vector3(v.x, v.y, 0f);
        }
    }
}
