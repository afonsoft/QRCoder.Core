using System;
using SkiaSharp;
using static QRCoder.Core.QRCodeGenerator;

namespace QRCoder.Core
{
    /// <summary>
    /// PostscriptQRCode
    /// </summary>
    public class PostscriptQRCode : AbstractQRCode
    {
        /// <summary>
        /// Constructor without params to be used in COM Objects connections
        /// </summary>
        public PostscriptQRCode()
        { }

        public PostscriptQRCode(QRCodeData data) : base(data)
        {
        }

        public string GetGraphic(int pointsPerModule, bool epsFormat = false)
        {
            var viewBox = new Size(pointsPerModule * this.QrCodeData.ModuleMatrix.Count, pointsPerModule * this.QrCodeData.ModuleMatrix.Count);
            return this.GetGraphic(viewBox, SKColor.Black, SKColor.White, true, epsFormat);
        }

        public string GetGraphic(int pointsPerModule, SKColor darkSKColor, SKColor lightSKColor, bool drawQuietZones = true, bool epsFormat = false)
        {
            var viewBox = new Size(pointsPerModule * this.QrCodeData.ModuleMatrix.Count, pointsPerModule * this.QrCodeData.ModuleMatrix.Count);
            return this.GetGraphic(viewBox, darkSKColor, lightSKColor, drawQuietZones, epsFormat);
        }

        public string GetGraphic(int pointsPerModule, string darkSKColorHex, string lightSKColorHex, bool drawQuietZones = true, bool epsFormat = false)
        {
            var viewBox = new Size(pointsPerModule * this.QrCodeData.ModuleMatrix.Count, pointsPerModule * this.QrCodeData.ModuleMatrix.Count);
            return this.GetGraphic(viewBox, darkSKColorHex, lightSKColorHex, drawQuietZones, epsFormat);
        }

        public string GetGraphic(Size viewBox, bool drawQuietZones = true, bool epsFormat = false)
        {
            return this.GetGraphic(viewBox, SKColor.Black, SKColor.White, drawQuietZones, epsFormat);
        }

        public string GetGraphic(Size viewBox, string darkSKColorHex, string lightSKColorHex, bool drawQuietZones = true, bool epsFormat = false)
        {
            return this.GetGraphic(viewBox, SKColorTranslator.FromHtml(darkSKColorHex), SKColorTranslator.FromHtml(lightSKColorHex), drawQuietZones, epsFormat);
        }

        public string GetGraphic(Size viewBox, SKColor darkSKColor, SKColor lightSKColor, bool drawQuietZones = true, bool epsFormat = false)
        {
            var offset = drawQuietZones ? 0 : 4;
            var drawableModulesCount = this.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : offset * 2);
            var pointsPerModule = (double)Math.Min(viewBox.Width, viewBox.Height) / (double)drawableModulesCount;

            string psFile = string.Format(psHeader, new object[] {
                DateTime.Now.ToString("s"), CleanSvgVal(viewBox.Width), CleanSvgVal(pointsPerModule),
                epsFormat ? "EPSF-3.0" : string.Empty
            });
            psFile += string.Format(psFunctions, new object[] {
                CleanSvgVal(darkSKColor.R /255.0), CleanSvgVal(darkSKColor.G /255.0), CleanSvgVal(darkSKColor.B /255.0),
                CleanSvgVal(lightSKColor.R /255.0), CleanSvgVal(lightSKColor.G /255.0), CleanSvgVal(lightSKColor.B /255.0),
                drawableModulesCount
            });

            for (int xi = offset; xi < offset + drawableModulesCount; xi++)
            {
                if (xi > offset)
                    psFile += "nl\n";
                for (int yi = offset; yi < offset + drawableModulesCount; yi++)
                {
                    psFile += (this.QrCodeData.ModuleMatrix[xi][yi] ? "f " : "b ");
                }
                psFile += "\n";
            }
            return psFile + psFooter;
        }

        private string CleanSvgVal(double input)
        {
            //Clean double values for international use/formats
            return input.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        private const string psHeader = @"%!PS-Adobe-3.0 {3}
%%Creator: QRCoder.NET
%%Title: QRCode
%%CreationDate: {0}
%%DocumentData: Clean7Bit
%%Origin: 0
%%DocumentMedia: Default {1} {1} 0 () ()
%%BoundingBox: 0 0 {1} {1}
%%LanguageLevel: 2
%%Pages: 1
%%Page: 1 1
%%EndComments
%%BeginConstants
/sz {1} def
/sc {2} def
%%EndConstants
%%BeginFeature: *PageSize Default
<< /PageSize [ sz sz ] /ImagingBBox null >> setpagedevice
%%EndFeature
";

        private const string psFunctions = @"%%BeginFunctions
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

        private const string psFooter = @"%%EndBody
grestore
showpage
%%EOF
";
    }

#if NET6_0_WINDOWS || NET8_0_WINDOWS || NETSTANDARD2_0_WINDOWS || NETSTANDARD2_1_WINDOWS
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
#endif

    public static class PostscriptQRCodeHelper
    {
        public static string GetQRCode(string plainText, int pointsPerModule, string darkSKColorHex, string lightSKColorHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, bool epsFormat = false)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
            using (var qrCode = new PostscriptQRCode(qrCodeData))
                return qrCode.GetGraphic(pointsPerModule, darkSKColorHex, lightSKColorHex, drawQuietZones, epsFormat);
        }
    }
}