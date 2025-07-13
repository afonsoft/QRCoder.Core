using System;
using System.Collections.Generic;
using System.Linq;
using static QRCoder.Core.QRCodeGenerator;

namespace QRCoder.Core
{
    /// <summary>
    /// SKBitmapByteQRCode
    /// </summary>
    // ReSharper disable once InconsistentNaming
    public class SKBitmapByteQRCode : AbstractQRCode
    {
        /// <summary>
        /// Constructor without params to be used in COM Objects connections
        /// </summary>
        public SKBitmapByteQRCode()
        { }

        public SKBitmapByteQRCode(QRCodeData data) : base(data)
        {
        }

        public byte[] GetGraphic(int pixelsPerModule)
        {
            return GetGraphic(pixelsPerModule, new byte[] { 0x00, 0x00, 0x00 }, new byte[] { 0xFF, 0xFF, 0xFF });
        }

        public byte[] GetGraphic(int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex)
        {
            return GetGraphic(pixelsPerModule, HexSKColorToByteArray(darkSKColorHtmlHex), HexSKColorToByteArray(lightSKColorHtmlHex));
        }

        public byte[] GetGraphic(int pixelsPerModule, byte[] darkSKColorRgb, byte[] lightSKColorRgb)
        {
            var sideLength = this.QrCodeData.ModuleMatrix.Count * pixelsPerModule;

            var moduleDark = darkSKColorRgb.Reverse();
            var moduleLight = lightSKColorRgb.Reverse();

            List<byte> bmp = new List<byte>();

            //header
            bmp.AddRange(new byte[] { 0x42, 0x4D, 0x4C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00 });

            //width
            bmp.AddRange(IntTo4Byte(sideLength));
            //height
            bmp.AddRange(IntTo4Byte(sideLength));

            //header end
            bmp.AddRange(new byte[] { 0x01, 0x00, 0x18, 0x00 });

            //draw qr code
            for (var x = sideLength - 1; x >= 0; x = x - pixelsPerModule)
            {
                for (int pm = 0; pm < pixelsPerModule; pm++)
                {
                    for (var y = 0; y < sideLength; y = y + pixelsPerModule)
                    {
                        var module =
                            this.QrCodeData.ModuleMatrix[(x + pixelsPerModule) / pixelsPerModule - 1][(y + pixelsPerModule) / pixelsPerModule - 1];
                        for (int i = 0; i < pixelsPerModule; i++)
                        {
                            bmp.AddRange(module ? moduleDark : moduleLight);
                        }
                    }
                    if (sideLength % 4 != 0)
                    {
                        for (int i = 0; i < sideLength % 4; i++)
                        {
                            bmp.Add(0x00);
                        }
                    }
                }
            }

            //finalize with terminator
            bmp.AddRange(new byte[] { 0x00, 0x00 });

            return bmp.ToArray();
        }

        private byte[] HexSKColorToByteArray(string colorString)
        {
            if (colorString.StartsWith("#"))
                colorString = colorString.Substring(1);
            byte[] byteSKColor = new byte[colorString.Length / 2];
            for (int i = 0; i < byteSKColor.Length; i++)
                byteSKColor[i] = byte.Parse(colorString.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture);
            return byteSKColor;
        }

        private byte[] IntTo4Byte(int inp)
        {
            byte[] bytes = new byte[2];
            unchecked
            {
                bytes[1] = (byte)(inp >> 8);
                bytes[0] = (byte)(inp);
            }
            return bytes;
        }
    }

    public static class SKBitmapByteQRCodeHelper
    {
        public static byte[] GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHtmlHex,
            string lightSKColorHtmlHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false,
            EciMode eciMode = EciMode.Default, int requestedVersion = -1)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (
                var qrCodeData = qrGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode,
                    requestedVersion))
            using (var qrCode = new SKBitmapByteQRCode(qrCodeData))
                return qrCode.GetGraphic(pixelsPerModule, darkSKColorHtmlHex, lightSKColorHtmlHex);
        }

        public static byte[] GetQRCode(string txt, QRCodeGenerator.ECCLevel eccLevel, int size)
        {
            using (var qrGen = new QRCodeGenerator())
            using (var qrCode = qrGen.CreateQrCode(txt, eccLevel))
            using (var qrBmp = new SKBitmapByteQRCode(qrCode))
                return qrBmp.GetGraphic(size);
        }
    }
}