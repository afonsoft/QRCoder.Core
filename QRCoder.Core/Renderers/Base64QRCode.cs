using System;
using SkiaSharp;

using System.IO;
using static QRCoder.Core.Renderers.Base64QRCode;
using static QRCoder.Core.Generators.QRCodeGenerator;
using QRCoder.Core.Extensions;

using QRCoder.Core.Abstractions;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
namespace QRCoder.Core.Renderers
{
    /// <summary>
    /// Renders a QR code as a Base64-encoded image string. Useful for embedding QR codes
    /// directly in HTML img tags or CSS without requiring a separate file.
    /// </summary>
    public class Base64QRCode : AbstractQRCode
    {
        private QRCode qr;

        /// <summary>
        /// Constructor without params to be used in COM Objects connections
        /// </summary>
        public Base64QRCode()
        {
            qr = new QRCode();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Base64QRCode"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public Base64QRCode(QRCodeData data) : base(data)
        {
            qr = new QRCode(data);
        }

        /// <summary>
        /// Sets the QR code data to be used by this renderer.
        /// </summary>
        /// <param name="data">The data.</param>
        public override void SetQRCodeData(QRCodeData data)
        {
            this.qr.SetQRCodeData(data);
        }

        /// <summary>
        /// Returns the graphic representation of the QR code.
        /// </summary>
        /// <param name="pixelsPerModule">The pixels per module.</param>
        /// <returns>The string result.</returns>
        public string GetGraphic(int pixelsPerModule)
        {
            return this.GetGraphic(pixelsPerModule, SKColors.Black, SKColors.White, true);
        }

        /// <summary>
        /// Returns the graphic representation of the QR code.
        /// </summary>
        /// <param name="pixelsPerModule">The pixels per module.</param>
        /// <param name="darkSKColorHtmlHex">The dark sk color html hex.</param>
        /// <param name="lightSKColorHtmlHex">The light sk color html hex.</param>
        /// <param name="drawQuietZones">The draw quiet zones.</param>
        /// <param name="imgType">The img type.</param>
        /// <returns>The string result.</returns>
        public string GetGraphic(int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            return this.GetGraphic(pixelsPerModule, SKColorExtensions.FromHex(darkSKColorHtmlHex), SKColorExtensions.FromHex(lightSKColorHtmlHex), drawQuietZones, imgType);
        }

        /// <summary>
        /// Returns the graphic representation of the QR code.
        /// </summary>
        /// <param name="pixelsPerModule">The pixels per module.</param>
        /// <param name="darkSKColor">The dark sk color.</param>
        /// <param name="lightSKColor">The light sk color.</param>
        /// <param name="drawQuietZones">The draw quiet zones.</param>
        /// <param name="imgType">The img type.</param>
        /// <returns>The string result.</returns>
        public string GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            var base64 = string.Empty;
            using (SKBitmap bmp = qr.GetGraphic(pixelsPerModule, darkSKColor, lightSKColor, drawQuietZones))
            {
                base64 = SKBitmapToBase64(bmp, imgType);
            }
            return base64;
        }

        /// <summary>
        /// Returns the graphic representation of the QR code.
        /// </summary>
        /// <param name="pixelsPerModule">The pixels per module.</param>
        /// <param name="darkSKColor">The dark sk color.</param>
        /// <param name="lightSKColor">The light sk color.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="iconSizePercent">The icon size percent.</param>
        /// <param name="iconBorderWidth">The icon border width.</param>
        /// <param name="drawQuietZones">The draw quiet zones.</param>
        /// <param name="imgType">The img type.</param>
        /// <returns>The string result.</returns>
        public string GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon, int iconSizePercent = 15, int iconBorderWidth = 6, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            var base64 = string.Empty;
            using (SKBitmap bmp = qr.GetGraphic(pixelsPerModule, darkSKColor, lightSKColor, icon, iconSizePercent, iconBorderWidth, drawQuietZones))
            {
                base64 = SKBitmapToBase64(bmp, imgType);
            }
            return base64;
        }

        private string SKBitmapToBase64(SKBitmap bmp, ImageType imgType)
        {
            var base64 = string.Empty;
            SKEncodedImageFormat encodedFormat = imgType switch
            {
                ImageType.Png => SKEncodedImageFormat.Png,
                ImageType.Jpeg => SKEncodedImageFormat.Jpeg,
                ImageType.Gif => SKEncodedImageFormat.Gif,
                _ => SKEncodedImageFormat.Png,
            };
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bmp.Encode(memoryStream, encodedFormat, 100);
                base64 = Convert.ToBase64String(memoryStream.ToArray(), Base64FormattingOptions.None);
            }
            return base64;
        }

        /// <summary>
        /// Defines the image type values.
        /// </summary>
        public enum ImageType
        {
            /// <summary>
            /// gif.
            /// </summary>
            Gif,
            /// <summary>
            /// jpeg.
            /// </summary>
            Jpeg,
            /// <summary>
            /// png.
            /// </summary>
            Png
        }
    }

    /// <summary>
    /// Represents a base64qr code helper.
    /// </summary>
    public static class Base64QRCodeHelper
    {
        /// <summary>
        /// Generates a QR code from the given data and returns the rendered output.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="pixelsPerModule">The pixels per module.</param>
        /// <param name="darkSKColorHtmlHex">The dark sk color html hex.</param>
        /// <param name="lightSKColorHtmlHex">The light sk color html hex.</param>
        /// <param name="eccLevel">The ecc level.</param>
        /// <param name="forceUtf8">The force utf8.</param>
        /// <param name="utf8BOM">The utf8bom.</param>
        /// <param name="eciMode">The eci mode.</param>
        /// <param name="requestedVersion">The requested version.</param>
        /// <param name="drawQuietZones">The draw quiet zones.</param>
        /// <param name="imgType">The img type.</param>
        /// <returns>The string result.</returns>
        public static string GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
            using (var qrCode = new Base64QRCode(qrCodeData))
                return qrCode.GetGraphic(pixelsPerModule, darkSKColorHtmlHex, lightSKColorHtmlHex, drawQuietZones, imgType);
        }
    }
}
