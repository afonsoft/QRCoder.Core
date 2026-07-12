using System;
using SkiaSharp;

using static QRCoder.Core.Generators.QRCodeGenerator;

using QRCoder.Core.Abstractions;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
namespace QRCoder.Core.Renderers
{
    /// <summary>
    /// Options for rendering a QR code bitmap.
    /// </summary>
    public sealed class QRCodeGraphicOptions
    {
        /// <summary>
        /// Gets or sets the pixels per module.
        /// </summary>
        public int PixelsPerModule { get; set; }

        /// <summary>
        /// Gets or sets the dark module color.
        /// </summary>
        public SKColor DarkSKColor { get; set; } = new SKColor(0, 0, 0);

        /// <summary>
        /// Gets or sets the light module color.
        /// </summary>
        public SKColor LightSKColor { get; set; } = new SKColor(255, 255, 255);

        /// <summary>
        /// Gets or sets a value indicating whether quiet zones are drawn.
        /// </summary>
        public bool DrawQuietZones { get; set; } = true;

        /// <summary>
        /// Gets or sets the icon to render.
        /// </summary>
        public SKBitmap Icon { get; set; }

        /// <summary>
        /// Gets or sets the icon size percentage.
        /// </summary>
        public int IconSizePercent { get; set; } = 15;

        /// <summary>
        /// Gets or sets the icon border width.
        /// </summary>
        public int IconBorderWidth { get; set; }

        /// <summary>
        /// Gets or sets the icon background color.
        /// </summary>
        public SKColor? IconBackgroundSKColor { get; set; }
    }

    /// <summary>
    /// Represents a QR code, providing methods for generating graphical representations.
    /// </summary>
    public class QRCode : AbstractQRCode
    {
        /// <summary>
        /// Constructor without params to be used in COM Objects connections
        /// </summary>
        public QRCode()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="QRCode"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public QRCode(QRCodeData data) : base(data)
        {
        }

        /// <summary>
        /// Generates a graphical representation of the QR code with the specified pixel size per module.
        /// </summary>
        /// <param name="pixelsPerModule">The size of each module in pixels.</param>
        /// <returns>A SkiaSharp bitmap representing the QR code.</returns>
        public SKBitmap GetGraphic(int pixelsPerModule)
        {
            return RenderGraphic(pixelsPerModule, new SKColor(0, 0, 0), new SKColor(255, 255, 255), true);
        }

        /// <summary>
        /// Generates a graphical representation of the QR code using the specified options.
        /// </summary>
        /// <param name="options">Rendering options.</param>
        /// <returns>A SkiaSharp bitmap representing the QR code.</returns>
        public SKBitmap GetGraphic(QRCodeGraphicOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            return options.Icon == null
                ? RenderGraphic(options.PixelsPerModule, options.DarkSKColor, options.LightSKColor, options.DrawQuietZones)
                : RenderGraphic(options.PixelsPerModule, options.DarkSKColor, options.LightSKColor, options.Icon, options.IconSizePercent, options.IconBorderWidth, options.DrawQuietZones, options.IconBackgroundSKColor);
        }

        /// <summary>
        /// Returns the graphic representation of the QR code.
        /// </summary>
        /// <param name="pixelsPerModule">The pixels per module.</param>
        /// <param name="darkSKColorHtmlHex">The dark sk color html hex.</param>
        /// <param name="lightSKColorHtmlHex">The light sk color html hex.</param>
        /// <param name="drawQuietZones">The draw quiet zones.</param>
        /// <returns>The sk bitmap result.</returns>
        public SKBitmap GetGraphic(int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, bool drawQuietZones = true)
        {
            return RenderGraphic(
                pixelsPerModule,
                ParseHtmlColor(darkSKColorHtmlHex),
                ParseHtmlColor(lightSKColorHtmlHex),
                drawQuietZones
            );
        }

        /// <summary>
        /// Returns the graphic representation of the QR code.
        /// </summary>
        /// <param name="pixelsPerModule">The pixels per module.</param>
        /// <param name="darkSKColor">The dark sk color.</param>
        /// <param name="lightSKColor">The light sk color.</param>
        /// <param name="drawQuietZones">The draw quiet zones.</param>
        /// <returns>The sk bitmap result.</returns>
        public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, bool drawQuietZones = true)
        {
            return RenderGraphic(pixelsPerModule, darkSKColor, lightSKColor, drawQuietZones);
        }

        /// <summary>
        /// Returns the graphic representation of the QR code.
        /// </summary>
        /// <param name="pixelsPerModule">The pixels per module.</param>
        /// <param name="darkSKColor">The dark sk color.</param>
        /// <param name="lightSKColor">The light sk color.</param>
        /// <param name="drawQuietZones">The draw quiet zones.</param>
        /// <returns>The sk bitmap result.</returns>
        private SKBitmap RenderGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, bool drawQuietZones = true)
        {
            var size = (this.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8)) * pixelsPerModule;
            var offset = drawQuietZones ? 0 : 4 * pixelsPerModule;

            var bmp = new SKBitmap(size, size);
            using (var gfx = new SKCanvas(bmp))
            using (var lightBrush = new SKPaint { Color = lightSKColor })
            using (var darkBrush = new SKPaint { Color = darkSKColor })
            {
                for (var x = 0; x < size + offset; x = x + pixelsPerModule)
                {
                    for (var y = 0; y < size + offset; y = y + pixelsPerModule)
                    {
                        var module = this.QrCodeData.ModuleMatrix[(y + pixelsPerModule) / pixelsPerModule - 1][(x + pixelsPerModule) / pixelsPerModule - 1];
                        var moduleBrush = module ? darkBrush : lightBrush;

                        gfx.DrawRect(new SKRect(x - offset, y - offset, x - offset + pixelsPerModule, y - offset + pixelsPerModule), moduleBrush);
                    }
                }

                gfx.Save();
            }

            return bmp;
        }

        private SKBitmap RenderGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon, int iconSizePercent, int iconBorderWidth, bool drawQuietZones, SKColor? iconBackgroundSKColor)
        {
            var size = (this.QrCodeData.ModuleMatrix.Count - (drawQuietZones ? 0 : 8)) * pixelsPerModule;
            var offset = drawQuietZones ? 0 : 4 * pixelsPerModule;

            var bmp = new SKBitmap(size, size, SKColorType.Rgba8888, SKAlphaType.Premul);

            using (var gfx = new SKCanvas(bmp))
            using (var lightBrush = new SKPaint { Color = lightSKColor })
            using (var darkBrush = new SKPaint { Color = darkSKColor })
            {
                gfx.Clear(lightSKColor);
                lightBrush.IsAntialias = true;
                darkBrush.IsAntialias = true;
                var drawIconFlag = icon != null && iconSizePercent > 0 && iconSizePercent <= 100;

                for (var x = 0; x < size + offset; x = x + pixelsPerModule)
                {
                    for (var y = 0; y < size + offset; y = y + pixelsPerModule)
                    {
                        var moduleBrush = this.QrCodeData.ModuleMatrix[(y + pixelsPerModule) / pixelsPerModule - 1][(x + pixelsPerModule) / pixelsPerModule - 1] ? darkBrush : lightBrush;
                        gfx.DrawRect(new SKRect(x - offset, y - offset, x - offset + pixelsPerModule, y - offset + pixelsPerModule), moduleBrush);
                    }
                }

                if (drawIconFlag)
                {
                    float iconDestWidth = iconSizePercent * bmp.Width / 100f;
                    float iconDestHeight = drawIconFlag ? iconDestWidth * icon.Height / icon.Width : 0;
                    float iconX = (bmp.Width - iconDestWidth) / 2;
                    float iconY = (bmp.Height - iconDestHeight) / 2;
                    var centerDest = new SKRect(iconX - iconBorderWidth, iconY - iconBorderWidth, iconX - iconBorderWidth + iconDestWidth + iconBorderWidth * 2, iconY - iconBorderWidth + iconDestHeight + iconBorderWidth * 2);
                    var iconDestRect = new SKRect(iconX, iconY, iconX + iconDestWidth, iconY + iconDestHeight);
                    var iconBgBrush = iconBackgroundSKColor != null ? new SKPaint { Color = (SKColor)iconBackgroundSKColor } : lightBrush;
                    if (iconBorderWidth > 0)
                    {
                        using (var iconPath = CreateRoundedSKRectIPath(centerDest, iconBorderWidth * 2))
                        {
                            gfx.DrawPath(iconPath, iconBgBrush);
                        }
                    }
                    using (var iconImage = SKImage.FromBitmap(icon))
                    {
                        gfx.DrawImage(iconImage, iconDestRect, new SKRect(0, 0, icon.Width, icon.Height));
                    }
                }

                gfx.Save();
            }

            return bmp;
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
        /// <param name="iconBackgroundSKColor">The icon background sk color.</param>
        /// <returns>The sk bitmap result.</returns>
        [Obsolete("Use GetGraphic(QRCodeGraphicOptions) instead.")]
        public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true, SKColor? iconBackgroundSKColor = null)
        {
            return RenderGraphic(pixelsPerModule, darkSKColor, lightSKColor, icon, iconSizePercent, iconBorderWidth, drawQuietZones, iconBackgroundSKColor);
        }

        internal static SKPath CreateRoundedSKRectIPath(SKRect rect, int cornerRadius)
        {
            var roundedRect = new SKPath();
            roundedRect.AddArc(new SKRect(rect.Left, rect.Top, rect.Left + cornerRadius * 2, rect.Top + cornerRadius * 2), 180, 90);
            roundedRect.LineTo(rect.Right - cornerRadius, rect.Top);
            roundedRect.AddArc(new SKRect(rect.Right - cornerRadius * 2, rect.Top, rect.Right, rect.Top + cornerRadius * 2), 270, 90);
            roundedRect.LineTo(rect.Right, rect.Bottom - cornerRadius);
            roundedRect.AddArc(new SKRect(rect.Right - cornerRadius * 2, rect.Bottom - cornerRadius * 2, rect.Right, rect.Bottom), 0, 90);
            roundedRect.LineTo(rect.Left + cornerRadius, rect.Bottom);
            roundedRect.AddArc(new SKRect(rect.Left, rect.Bottom - cornerRadius * 2, rect.Left + cornerRadius * 2, rect.Bottom), 90, 90);
            roundedRect.LineTo(rect.Left, rect.Top + cornerRadius);
            roundedRect.Close();
            return roundedRect;
        }
        // SkiaSharp-only HTML color parser
        private static SKColor ParseHtmlColor(string htmlColor)
        {
            if (string.IsNullOrWhiteSpace(htmlColor))
                throw new ArgumentException("Color string is null or empty.");

            string color = htmlColor.TrimStart('#');
            if (color.Length == 6)
            {
                // RRGGBB
                return new SKColor(
                    Convert.ToByte(color.Substring(0, 2), 16),
                    Convert.ToByte(color.Substring(2, 2), 16),
                    Convert.ToByte(color.Substring(4, 2), 16),
                    255
                );
            }
            else if (color.Length == 8)
            {
                // AARRGGBB
                return new SKColor(
                    Convert.ToByte(color.Substring(2, 2), 16),
                    Convert.ToByte(color.Substring(4, 2), 16),
                    Convert.ToByte(color.Substring(6, 2), 16),
                    Convert.ToByte(color.Substring(0, 2), 16)
                );
            }
            else
            {
                throw new ArgumentException("Invalid HTML color format. Use #RRGGBB or #AARRGGBB.");
            }
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
        public static SKBitmap GetQRCode(string plainText, int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true)
        {
            using (var qrGenerator = new QRCodeGenerator())
            using (var qrCodeData = qrGenerator.CreateQrCode(plainText, eccLevel, forceUtf8, utf8BOM, eciMode, requestedVersion))
            using (var qrCode = new QRCode(qrCodeData))
                return qrCode.GetGraphic(new QRCodeGraphicOptions
                {
                    PixelsPerModule = pixelsPerModule,
                    DarkSKColor = darkSKColor,
                    LightSKColor = lightSKColor,
                    DrawQuietZones = drawQuietZones,
                    Icon = icon,
                    IconSizePercent = iconSizePercent,
                    IconBorderWidth = iconBorderWidth
                });
        }
    }
}
