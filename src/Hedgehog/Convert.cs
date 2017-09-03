using System.Drawing;
using System.Globalization;
using OpenTK;
using Hedgehog.Graphic;

namespace Hedgehog
{
    /// <summary>
    /// This class allow to convert hedgehog type to system and openTK types.
    /// </summary>
    public static class Convert
    {
        public static Matrix4 ToMatrix(this Transform3D t)
        {
            return Matrix4.Identity * Matrix4.CreateScale(t.Scale) * t.Rotation.ToMatrix() * t.Position.ToMatrix(); 
        }

        public static Matrix4 ToMatrix(this Rotation3D r)
        {
            return Matrix4.CreateRotationX(r.X) * Matrix4.CreateRotationX(r.Y) * Matrix4.CreateRotationX(r.Z);
        }

        public static Matrix4 ToMatrix(this Position3D p)
        {
            return Matrix4.CreateTranslation(p.X, p.Y, p.Z);
        }

        public static Matrix4 GetViewMatrix(this Camera c, float aspectRatio)
        {
            return Matrix4.CreatePerspectiveFieldOfView(c.FieldOfView, aspectRatio, 1.0f, c.ViewDistance);
        }

        public static Matrix4 GetWorldMatrix(this Camera c)
        {
            return Matrix4.CreateTranslation(-c.Position.X, -c.Position.Y, -c.Position.Z) * c.Rotation.ToMatrix();
        }

        public static Color ToSystemColor(this Color3 c)
        {
            return Color.FromArgb(c.Red, c.Green, c.Blue);
        }

        public static Color ToSystemColor(this Color4 c)
        {
            return Color.FromArgb(c.Alpha, c.Red, c.Green, c.Blue);
        }

        public static float ToFloat(this string s)
        {
            return float.Parse(s, CultureInfo.InvariantCulture);
        }

        public static int ToInt(this string s)
        {
            return int.Parse(s);
        }

        public static int[] ToInts(this string[] s)
        {
            int[] ints = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                if (int.TryParse(s[i], out int value))
                {
                    ints[i] = value;
                }
                else
                {
                    ints[i] = 0;
                }
            }

            return ints;
        }
    }
}
