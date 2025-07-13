using System;
using SkiaSharp;

using System.IO;
using static QRCoder.Core.Base64QRCode;
using static QRCoder.Core.QRCodeGenerator;

namespace QRCoder.Core
{
    /// <summary>
    /// Base64QRCode
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

        public Base64QRCode(QRCodeData data) : base(data)
        {
            qr = new QRCode(data);
        }

        public override void SetQRCodeData(QRCodeData data)
        {
            this.qr.SetQRCodeData(data);
        }

        public string GetGraphic(int pixelsPerModule)
        {
            return this.GetGraphic(pixelsPerModule, SKColors.Black, SKColors.White, true);
        }

        public string GetGraphic(int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            return this.GetGraphic(pixelsPerModule, SKColorTranslator.FromHtml(darkSKColorHtmlHex), SKColorTranslator.FromHtml(lightSKColorHtmlHex), drawQuietZones, imgType);
        }

        public string GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            var base64 = string.Empty;
            using (SKBitmap bmp = qr.GetGraphic(pixelsPerModule, darkSKColor, lightSKColor, drawQuietZones))
            {
                base64 = SKBitmapToBase64(bmp, imgType);
            }
            return base64;
        }

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

        public enum ImageType
        {
            Gif,
            Jpeg,
            Png
        }
    }

    public static class Base64QRCodeHelper
    {
        public static string GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, ImageType imgType = ImageType.Png)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
            using (var qrCode = new Base64QRCode(qrCodeData))
                return qrCode.GetGraphic(pixelsPerModule, darkSKColorHtmlHex, lightSKColorHtmlHex, drawQuietZones, imgType);
        }
    }
}