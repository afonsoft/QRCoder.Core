using System;
using System.Collections.Generic;
using System.Text;
using static QRCoder.Core.Generators.QRCodeGenerator;

using QRCoder.Core.Abstractions;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
namespace QRCoder.Core.Renderers
{
    /// <summary>
    /// Renders a QR code as ASCII art text, suitable for terminal/console output.
    /// Each module is represented by configurable dark and light character strings.
    /// </summary>
    public class AsciiQRCode : AbstractQRCode
    {
        /// <summary>
        /// Constructor without params to be used in COM Objects connections
        /// </summary>
        public AsciiQRCode()
        { }

        /// <summary>
        /// Constructor with params to be used in COM Objects connections
        /// </summary>
        public AsciiQRCode(QRCodeData data) : base(data)
        {
        }

        /// <summary>
        /// Returns a strings that contains the resulting QR code as ASCII chars.
        /// </summary>
        /// <param name="repeatPerModule">Number of repeated darkSKColorString/whiteSpaceString per module.</param>
        /// <param name="darkSKColorString">String for use as dark color modules. In case of string make sure whiteSpaceString has the same length.</param>
        /// <param name="drawQuietZones"></param>
        /// <param name="whiteSpaceString">String for use as white modules (whitespace). In case of string make sure darkSKColorString has the same length.</param>
        /// <param name="endOfLine">End of line separator. (Default: \n)</param>
        /// <returns></returns>
        public string GetGraphic(int repeatPerModule, string darkSKColorString = "██", string whiteSpaceString = "  ", bool drawQuietZones = true, string endOfLine = "\n")
        {
            return string.Join(endOfLine, GetLineByLineGraphic(repeatPerModule, darkSKColorString, whiteSpaceString, drawQuietZones));
        }

        /// <summary>
        /// Returns an array of strings that contains each line of the resulting QR code as ASCII chars.
        /// </summary>
        /// <param name="repeatPerModule">Number of repeated darkSKColorString/whiteSpaceString per module.</param>
        /// <param name="darkSKColorString">String for use as dark color modules. In case of string make sure whiteSpaceString has the same length.</param>
        /// <param name="whiteSpaceString">String for use as white modules (whitespace). In case of string make sure darkSKColorString has the same length.</param>
        /// <param name="drawQuietZones"></param>
        /// <returns></returns>
        public string[] GetLineByLineGraphic(int repeatPerModule, string darkSKColorString = "██", string whiteSpaceString = "  ", bool drawQuietZones = true)
        {
            var qrCode = new List<string>();
            //We need to adjust the repeatPerModule based on number of characters in darkSKColorString
            //(we assume whiteSpaceString has the same number of characters)
            //to keep the QR code as square as possible.
            var quietZonesModifier = (drawQuietZones ? 0 : 8);
            var quietZonesOffset = (int)(quietZonesModifier * 0.5);
            var adjustmentValueForNumberOfCharacters = darkSKColorString.Length / 2 != 1 ? darkSKColorString.Length / 2 : 0;
            var verticalNumberOfRepeats = repeatPerModule + adjustmentValueForNumberOfCharacters;
            var moduleCount = QrCodeData.ModuleMatrix.Count - quietZonesModifier;
            var sideLength = moduleCount * verticalNumberOfRepeats;
            for (var y = 0; y < sideLength; y++)
            {
                var lineBuilder = new StringBuilder();
                var moduleRow = ((y + verticalNumberOfRepeats) / verticalNumberOfRepeats - 1) + quietZonesOffset;
                for (var x = 0; x < moduleCount; x++)
                {
                    var module = QrCodeData.ModuleMatrix[moduleRow][x + quietZonesOffset];
                    for (var i = 0; i < repeatPerModule; i++)
                    {
                        lineBuilder.Append(module ? darkSKColorString : whiteSpaceString);
                    }
                }
                qrCode.Add(lineBuilder.ToString());
            }
            return qrCode.ToArray();
        }
    }

    /// <summary>
    /// Represents a ascii qr code helper.
    /// </summary>
    public static class AsciiQRCodeHelper
    {
        /// <summary>
        /// Generates a QR code from the given data and returns the rendered output.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="pixelsPerModule">The pixels per module.</param>
        /// <param name="darkSKColorString">The dark sk color string.</param>
        /// <param name="whiteSpaceString">The white space string.</param>
        /// <param name="eccLevel">The ecc level.</param>
        /// <param name="forceUtf8">The force utf8.</param>
        /// <param name="utf8BOM">The utf8bom.</param>
        /// <param name="eciMode">The eci mode.</param>
        /// <param name="requestedVersion">The requested version.</param>
        /// <param name="endOfLine">The end of line.</param>
        /// <param name="drawQuietZones">The draw quiet zones.</param>
        /// <returns>The string result.</returns>
        public static string GetQRCode(string plainText, int pixelsPerModule, string darkSKColorString, string whiteSpaceString, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, string endOfLine = "\n", bool drawQuietZones = true)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
            using (var qrCode = new AsciiQRCode(qrCodeData))
                return qrCode.GetGraphic(pixelsPerModule, darkSKColorString, whiteSpaceString, drawQuietZones, endOfLine);
        }
    }
}
