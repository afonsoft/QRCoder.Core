using SkiaSharp;
using System.Globalization;

namespace QRCoder.Core.Extensions
{
    /// <summary>
    /// Extension methods for converting <see cref="SKColor"/> values to and from hexadecimal string notation.
    /// </summary>
    public static class SKColorExtensions
    {
        /// <summary>
        /// Converts this color to an ARGB hexadecimal string (e.g., "#FF000000" for opaque black).
        /// </summary>
        public static string ToHex(this SKColor color)
        {
            return string.Format(CultureInfo.InvariantCulture, "#{0:X2}{1:X2}{2:X2}{3:X2}", color.Alpha, color.Red, color.Green, color.Blue);
        }

        /// <summary>
        /// Parses a hexadecimal color string (#RRGGBB or #AARRGGBB) into an <see cref="SKColor"/>.
        /// Returns <see cref="SKColors.Transparent"/> for null, empty, or invalid input.
        /// </summary>
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