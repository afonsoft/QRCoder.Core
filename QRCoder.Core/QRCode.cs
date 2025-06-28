using System;
using SkiaSharp;

using static QRCoder.Core.QRCodeGenerator;

namespace QRCoder.Core
{
    /// <summary>
    /// QRCode
    /// </summary>
    public class QRCode : AbstractQRCode
    {
        /// <summary>
        /// Constructor without params to be used in COM Objects connections
        /// </summary>
        public QRCode()
        { }

        public QRCode(QRCodeData data) : base(data)
        {
        }

        public SKBitmap GetGraphic(int pixelsPerModule)
        {
            return this.GetGraphic(pixelsPerModule, SKColor.Black, SKColor.White, true);
        }

        public SKBitmap GetGraphic(int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, bool drawQuietZones = true)
        {
            return this.GetGraphic(pixelsPerModule, SKColorTranslator.FromHtml(darkSKColorHtmlHex), SKColorTranslator.FromHtml(lightSKColorHtmlHex), drawQuietZones);
        }

        public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, bool drawQuietZones = true)
        {
            var size = (this.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8)) * pixelsPerModule;
            var offset = drawQuietZones ? 0 : 4 * pixelsPerModule;

            var bmp = new SKBitmap(size, size);
            using (var gfx = SKCanvas.FromImage(bmp))
            using (var lightBrush = new SKPaint(lightSKColor))
            using (var darkBrush = new SKPaint(darkSKColor))
            {
                for (var x = 0; x < size + offset; x = x + pixelsPerModule)
                {
                    for (var y = 0; y < size + offset; y = y + pixelsPerModule)
                    {
                        var module = this.QrCodeData.ModuleMatrix[(y + pixelsPerModule) / pixelsPerModule - 1][(x + pixelsPerModule) / pixelsPerModule - 1];

                        if (module)
                        {
                            gfx.FillSKRectI(darkBrush, new SKRectI(x - offset, y - offset, pixelsPerModule, pixelsPerModule));
                        }
                        else
                        {
                            gfx.FillSKRectI(lightBrush, new SKRectI(x - offset, y - offset, pixelsPerModule, pixelsPerModule));
                        }
                    }
                }

                gfx.Save();
            }

            return bmp;
        }

        public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true, SKColor? iconBackgroundSKColor = null)
        {
            var size = (this.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8)) * pixelsPerModule;
            var offset = drawQuietZones ? 0 : 4 * pixelsPerModule;

            var bmp = new SKBitmap(size, size, SKColorType.Rgba8888, SKAlphaType.Premul);

            using (var gfx = SKCanvas.FromImage(bmp))
            using (var lightBrush = new SKPaint(lightSKColor))
            using (var darkBrush = new SKPaint(darkSKColor))
            {
                lightBrush.FilterQuality = SKFilterQuality.High;
                
                gfx.Clear(lightSKColor);lightBrush.IsAntialias = true;darkBrush.IsAntialias = true;
                var drawIconFlag = icon != null && iconSizePercent > 0 && iconSizePercent <= 100;

                for (var x = 0; x < size + offset; x = x + pixelsPerModule)
                {
                    for (var y = 0; y < size + offset; y = y + pixelsPerModule)
                    {
                        var moduleBrush = this.QrCodeData.ModuleMatrix[(y + pixelsPerModule) / pixelsPerModule - 1][(x + pixelsPerModule) / pixelsPerModule - 1] ? darkBrush : lightBrush;
                        gfx.FillSKRectI(moduleBrush, new SKRectI(x - offset, y - offset, pixelsPerModule, pixelsPerModule));
                    }
                }

                if (drawIconFlag)
                {
                    float iconDestWidth = iconSizePercent * bmp.Width / 100f;
                    float iconDestHeight = drawIconFlag ? iconDestWidth * icon.Height / icon.Width : 0;
                    float iconX = (bmp.Width - iconDestWidth) / 2;
                    float iconY = (bmp.Height - iconDestHeight) / 2;
                    var centerDest = new SKRectIF(iconX - iconBorderWidth, iconY - iconBorderWidth, iconDestWidth + iconBorderWidth * 2, iconDestHeight + iconBorderWidth * 2);
                    var iconDestRect = new SKRectIF(iconX, iconY, iconDestWidth, iconDestHeight);
                    var iconBgBrush = iconBackgroundSKColor != null ? new SKPaint((SKColor)iconBackgroundSKColor) : lightBrush;
                    //Only render icon/logo background, if iconBorderWith is set > 0
                    if (iconBorderWidth > 0)
                    {
                        using (SKCanvasPath iconPath = CreateRoundedSKRectIPath(centerDest, iconBorderWidth * 2))
                        {
                            gfx.FillPath(iconBgBrush, iconPath);
                        }
                    }
                    gfx.DrawImage(icon, iconDestRect, new SKRectIF(0, 0, icon.Width, icon.Height), SKCanvasUnit.Pixel);
                }

                gfx.Save();
            }

            return bmp;
        }

        internal SKCanvasPath CreateRoundedSKRectIPath(SKRectIF rect, int cornerRadius)
        {
            var roundedRect = new SKCanvasPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }
    }

    /// <summary>
    /// QRCodeHelper
    /// </summary>
    public static class QRCodeHelper
    {
        /// <summary>
        /// GetQRCode
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="pixelsPerModule"></param>
        /// <param name="darkSKColor"></param>
        /// <param name="lightSKColor"></param>
        /// <param name="eccLevel"></param>
        /// <param name="forceUtf8"></param>
        /// <param name="utf8BOM"></param>
        /// <param name="eciMode"></param>
        /// <param name="requestedVersion"></param>
        /// <param name="icon"></param>
        /// <param name="iconSizePercent"></param>
        /// <param name="iconBorderWidth"></param>
        /// <param name="drawQuietZones"></param>
        /// <returns></returns>
        public static SKBitmap GetQRCode(string plainText, int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
            using (var qrCode = new QRCode(qrCodeData))
                return qrCode.GetGraphic(pixelsPerModule, darkSKColor, lightSKColor, icon, iconSizePercent, iconBorderWidth, drawQuietZones);
        }
    }
}