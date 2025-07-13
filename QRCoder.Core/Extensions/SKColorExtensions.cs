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
    }
}