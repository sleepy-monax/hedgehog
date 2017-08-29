using System;
using static System.Math;

namespace Hedgehog
{
    public class Vector3D : IEquatable<Vector3D>
    {

        public float X { get; set; } = 0f;
        public float Y { get; set; } = 0f;
        public float Z { get; set; } = 0f;

        public float Lenght { get { return (float)Abs(Sqrt(X * X + Y * Y + Z * Z)); } }

        public Vector3D(float x, float y, float z, bool normalize = false)
        {
            X = x;
            Y = y;
            Z = z;

            if (normalize) Normalize();
        }

        public void Normalize()
        {
            float lenght = Lenght;
            X = X / lenght;
            Y = Y / lenght;
            Z = Z / lenght;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", X, Y, Z);
        }

        public float[] ToArray()
        {
            return new float[] { X, Y, Z };
        }

        // Operators ----------------------------------------------------------

        public bool Equals(Vector3D other)
        {
            return other.X == X && other.Y == Y && other.Z == Z;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector3D))
                return false;

            return Equals((Vector3D)obj);
        }

        public static Vector3D operator +(Vector3D left, Vector3D right)
        {
            return new Vector3D(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3D operator /(Vector3D left, Vector3D right)
        {
            return new Vector3D(left.X / right.X, left.Y / right.Y, left.Z / right.Z);
        }

        public static Vector3D operator *(Vector3D left, Vector3D right)
        {
            return new Vector3D(left.X * right.X, left.Y * right.Y, left.Z * right.Z);
        }

        public static bool operator ==(Vector3D left, Vector3D right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vector3D left, Vector3D right)
        {
            return !left.Equals(right);
        }
    }
}
