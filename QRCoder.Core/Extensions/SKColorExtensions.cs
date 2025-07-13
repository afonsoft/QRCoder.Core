using SkiaSharp;
using System.Globalization;

namespace QRCoder.Core.Extensions
{
    public static class SKColorExtensions
    {
        public static string ToHex(this SKColor color)
        {
            return string.Format(CultureInfo.InvariantCulture, "#{0:X2}{1:X2}{2:X2}{3:X2}", color.Alpha, color.Red, color.Green, color.Blue);
        }

        public static SKColor FromHex(string hex)
        {
            if (string.IsNullOrEmpty(hex))
            {
                return SKColors.Transparent;
            }

            hex = hex.StartsWith("#") ? hex.Substring(1) : hex;

            if (hex.Length == 6)
            {
                // RGB (assume opaque)
                return SKColor.Parse(hex);
            }
            else if (hex.Length == 8)
            {
                // ARGB
                return SKColor.Parse(hex);
            }
            else
            {
                // Invalid format, return transparent or throw an exception
                return SKColors.Transparent;
            }
        }
    }
}