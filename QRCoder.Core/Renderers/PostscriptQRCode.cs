using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using QRCoder.Core.Extensions;
using SkiaSharp;
using static QRCoder.Core.Generators.QRCodeGenerator;

using QRCoder.Core.Abstractions;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;

namespace QRCoder.Core.Renderers
{
    /// <summary>
    /// Renders a QR code as a PostScript or EPS (Encapsulated PostScript) string.
    /// Suitable for high-quality print output and vector graphics workflows.
    /// </summary>
    public class PostscriptQRCode : AbstractQRCode
    {
        /// <summary>
        /// Constructor without params to be used in COM Objects connections.
        /// </summary>
        public PostscriptQRCode()
        {
        }

        /// <summary>
        /// Constructor with QRCodeData.
        /// </summary>
        /// <param name="data">The QR code data to render.</param>
        public PostscriptQRCode(QRCodeData data) : base(data)
        {
        }

        /// <summary>
        /// Creates a black and white PostScript code representation of the QR code.
        /// </summary>
        /// <param name="pointsPerModule">The number of points each dark/light module of the QR code will occupy in the final QR code image.</param>
        /// <param name="epsFormat">Indicates if the output should be in EPS format.</param>
        /// <returns>Returns the QR code graphic as a PostScript string.</returns>
        public string GetGraphic(int pointsPerModule, bool epsFormat = false)
        {
            var viewBox = new Size(pointsPerModule * this.QrCodeData.ModuleMatrix.Count, pointsPerModule * this.QrCodeData.ModuleMatrix.Count);
            return this.GetGraphic(viewBox, new SKColor(0, 0, 0), new SKColor(255, 255, 255), true, epsFormat);
        }

        /// <summary>
        /// Creates a colored PostScript code representation of the QR code.
        /// </summary>
        /// <param name="pointsPerModule">The number of points each dark/light module of the QR code will occupy in the final QR code image.</param>
        /// <param name="darkSKColor">The color of the dark modules.</param>
        /// <param name="lightSKColor">The color of the light modules.</param>
        /// <param name="drawQuietZones">Indicates if quiet zones around the QR code should be drawn.</param>
        /// <param name="epsFormat">Indicates if the output should be in EPS format.</param>
        /// <returns>Returns the QR code graphic as a PostScript string.</returns>
        public string GetGraphic(int pointsPerModule, SKColor darkSKColor, SKColor lightSKColor, bool drawQuietZones = true, bool epsFormat = false)
        {
            var viewBox = new Size(pointsPerModule * this.QrCodeData.ModuleMatrix.Count, pointsPerModule * this.QrCodeData.ModuleMatrix.Count);
            return this.GetGraphic(viewBox, darkSKColor, lightSKColor, drawQuietZones, epsFormat);
        }

        /// <summary>
        /// Creates a colored PostScript code representation of the QR code.
        /// </summary>
        /// <param name="pointsPerModule">The number of points each dark/light module of the QR code will occupy in the final QR code image.</param>
        /// <param name="darkSKColorHex">The color of the dark modules in HTML hex format.</param>
        /// <param name="lightSKColorHex">The color of the light modules in HTML hex format.</param>
        /// <param name="drawQuietZones">Indicates if quiet zones around the QR code should be drawn.</param>
        /// <param name="epsFormat">Indicates if the output should be in EPS format.</param>
        /// <returns>Returns the QR code graphic as a PostScript string.</returns>
        public string GetGraphic(int pointsPerModule, string darkSKColorHex, string lightSKColorHex, bool drawQuietZones = true, bool epsFormat = false)
        {
            var viewBox = new Size(pointsPerModule * this.QrCodeData.ModuleMatrix.Count, pointsPerModule * this.QrCodeData.ModuleMatrix.Count);
            return this.GetGraphic(viewBox, darkSKColorHex, lightSKColorHex, drawQuietZones, epsFormat);
        }

        /// <summary>
        /// Creates a black and white PostScript code representation of the QR code.
        /// </summary>
        /// <param name="viewBox">The dimensions of the viewbox for the QR code.</param>
        /// <param name="drawQuietZones">Indicates if quiet zones around the QR code should be drawn.</param>
        /// <param name="epsFormat">Indicates if the output should be in EPS format.</param>
        /// <returns>Returns the QR code graphic as a PostScript string.</returns>
        public string GetGraphic(Size viewBox, bool drawQuietZones = true, bool epsFormat = false)
        {
            return this.GetGraphic(viewBox, new SKColor(0, 0, 0), new SKColor(255, 255, 255), drawQuietZones, epsFormat);
        }

        /// <summary>
        /// Creates a colored PostScript code representation of the QR code.
        /// </summary>
        /// <param name="viewBox">The dimensions of the viewbox for the QR code.</param>
        /// <param name="darkSKColorHex">The color of the dark modules in HTML hex format.</param>
        /// <param name="lightSKColorHex">The color of the light modules in HTML hex format.</param>
        /// <param name="drawQuietZones">Indicates if quiet zones around the QR code should be drawn.</param>
        /// <param name="epsFormat">Indicates if the output should be in EPS format.</param>
        /// <returns>Returns the QR code graphic as a PostScript string.</returns>
        public string GetGraphic(Size viewBox, string darkSKColorHex, string lightSKColorHex, bool drawQuietZones = true, bool epsFormat = false)
        {
            return this.GetGraphic(viewBox, SKColorExtensions.FromHex(darkSKColorHex), SKColorExtensions.FromHex(lightSKColorHex), drawQuietZones, epsFormat);
        }

        /// <summary>
        /// Creates a colored PostScript code representation of the QR code.
        /// </summary>
        /// <param name="viewBox">The dimensions of the viewbox for the QR code.</param>
        /// <param name="darkSKColor">The color of the dark modules.</param>
        /// <param name="lightSKColor">The color of the light modules.</param>
        /// <param name="drawQuietZones">Indicates if quiet zones around the QR code should be drawn.</param>
        /// <param name="epsFormat">Indicates if the output should be in EPS format.</param>
        /// <returns>Returns the QR code graphic as a PostScript string.</returns>
        public string GetGraphic(Size viewBox, SKColor darkSKColor, SKColor lightSKColor, bool drawQuietZones = true, bool epsFormat = false)
        {
            var offset = drawQuietZones ? 0 : 4;
            var drawableModulesCount = this.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : offset * 2);
            var pointsPerModule = (double)Math.Min(viewBox.Width, viewBox.Height) / (double)drawableModulesCount;

            var header = epsFormat ? EPS_HEADER : PS_HEADER;
            var functions = epsFormat ? EPS_FUNCTIONS : PS_FUNCTIONS;
            var footer = epsFormat ? EPS_FOOTER : PS_FOOTER;

            var estimatedCapacity = header.Length + functions.Length + footer.Length +
                (drawableModulesCount * drawableModulesCount * 2) +
                (drawableModulesCount * 3) +
                200;

            var sb = new StringBuilder(estimatedCapacity);

            sb.AppendFormat(CultureInfo.InvariantCulture, header, new object[] {
                CleanSvgVal(viewBox.Width), CleanSvgVal(pointsPerModule)
            });

            var args = new object[] {
                CleanSvgVal(darkSKColor.Red / 255.0), CleanSvgVal(darkSKColor.Green / 255.0), CleanSvgVal(darkSKColor.Blue / 255.0),
                CleanSvgVal(lightSKColor.Red / 255.0), CleanSvgVal(lightSKColor.Green / 255.0), CleanSvgVal(lightSKColor.Blue / 255.0),
                drawableModulesCount,
                CleanSvgVal(viewBox.Width), CleanSvgVal(pointsPerModule)
            };

            sb.AppendFormat(CultureInfo.InvariantCulture, functions, args);

            for (int xi = offset; xi < offset + drawableModulesCount; xi++)
            {
                if (xi > offset)
                    sb.Append("nl\n");
                for (int yi = offset; yi < offset + drawableModulesCount; yi++)
                {
                    sb.Append(this.QrCodeData.ModuleMatrix[xi][yi] ? "f " : "b ");
                }
            }
            sb.Append('\n');
            sb.Append(footer);
            return sb.ToString();
        }

        private static string CleanSvgVal(double input)
        {
            return input.ToString("G7", CultureInfo.InvariantCulture);
        }

        private const string PS_HEADER = @"%!PS-Adobe-3.0
%%Creator: QRCoder.NET
%%Title: QRCode
%%DocumentData: Clean7Bit
%%Origin: 0
%%DocumentMedia: Default {0} {0} 0 () ()
%%BoundingBox: 0 0 {0} {0}
%%LanguageLevel: 2
%%Pages: 1
%%Page: 1 1
%%EndComments
%%BeginConstants
/sz {0} def
/sc {1} def
%%EndConstants
%%BeginFeature: *PageSize Default
<< /PageSize [ sz sz ] /ImagingBBox null >> setpagedevice
%%EndFeature
";

        private const string EPS_HEADER = @"%!PS-Adobe-3.0 EPSF-3.0
%%Creator: QRCoder.NET
%%Title: QRCode
%%DocumentData: Clean7Bit
%%BoundingBox: 0 0 {0} {0}
%%LanguageLevel: 2
%%EndComments
";

        private const string PS_FUNCTIONS = @"%%BeginFunctions
/csquare {{
    newpath
    0 0 moveto
    0 1 rlineto
    1 0 rlineto
    0 -1 rlineto
    closepath
    setrgbcolor
    fill
}} def
/f {{
    {0} {1} {2} csquare
    1 0 translate
}} def
/b {{
    1 0 translate
}} def
/background {{
    {3} {4} {5} csquare
}} def
/nl {{
    -{6} -1 translate
}} def
%%EndFunctions
%%BeginBody
0 0 moveto
gsave
sz sz scale
background
grestore
gsave
sc sc scale
0 {6} 1 sub translate
";

        private const string EPS_FUNCTIONS = @"%%BeginProlog
7 dict begin
/csquare {{
    newpath
    0 0 moveto
    0 1 rlineto
    1 0 rlineto
    0 -1 rlineto
    closepath
    setrgbcolor
    fill
}} def
/f {{
    {0} {1} {2} csquare
    1 0 translate
}} def
/b {{
    1 0 translate
}} def
/background {{
    {3} {4} {5} csquare
}} def
/nl {{
    -{6} -1 translate
}} def
%%EndProlog
%%BeginSetup
/sz {7} def
/sc {8} def
%%EndSetup
gsave
0 0 moveto
sz sz scale
background
grestore
gsave
sc sc scale
0 {6} 1 sub translate
";

        private const string PS_FOOTER = @"%%EndBody
grestore
showpage
%%EOF
";

        private const string EPS_FOOTER = @"grestore
end
%%EOF
";
    }

    /// <summary>
    /// Helper class to create PostScript/EPS QR codes from plain text.
    /// </summary>
    public static class PostscriptQRCodeHelper
    {
        /// <summary>
        /// Creates a PostScript or EPS QR code from plain text.
        /// </summary>
        /// <param name="plainText">The text to encode.</param>
        /// <param name="pointsPerModule">The number of points each module occupies.</param>
        /// <param name="darkSKColorHex">The dark modules color in HTML hex format.</param>
        /// <param name="lightSKColorHex">The light modules color in HTML hex format.</param>
        /// <param name="eccLevel">Error correction level.</param>
        /// <param name="forceUtf8">Force UTF-8 encoding.</param>
        /// <param name="utf8BOM">Include UTF-8 BOM.</param>
        /// <param name="eciMode">ECI mode.</param>
        /// <param name="requestedVersion">Requested QR code version.</param>
        /// <param name="drawQuietZones">Draw quiet zones.</param>
        /// <param name="epsFormat">Return EPS format instead of plain PostScript.</param>
        /// <returns>PostScript or EPS string.</returns>
        [SuppressMessage("SonarAnalyzer.CSharp", "S107", Justification = "Convenience helper with many optional parameters")]
        public static string GetQRCode(string plainText, int pointsPerModule, string darkSKColorHex, string lightSKColorHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, bool epsFormat = false)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
            using (var qrCode = new PostscriptQRCode(qrCodeData))
                return qrCode.GetGraphic(pointsPerModule, darkSKColorHex, lightSKColorHex, drawQuietZones, epsFormat);
        }
    }
}
