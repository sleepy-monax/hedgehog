using System.Drawing;
using System.Globalization;

namespace Hedgehog
{
    /// <summary>
    /// This class allow to convert hedgehog type to system and openTK types.
    /// </summary>
    public static class Convert
    {

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
