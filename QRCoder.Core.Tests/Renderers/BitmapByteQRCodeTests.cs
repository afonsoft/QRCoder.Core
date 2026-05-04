using QRCoder.Core.Generators;
using QRCoder.Core.Renderers;
using Shouldly;
using Xunit;

namespace QRCoder.Core.Tests.Renderers
{
    public class BitmapByteQRCodeTests
    {
        [Fact]
        public void can_render_bitmap_byte_qrcode()
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode("BMP test", QRCodeGenerator.ECCLevel.M))
            using (var bmpQr = new SKBitmapByteQRCode(data))
            {
                var bmp = bmpQr.GetGraphic(20);
                bmp.ShouldNotBeNull();
                bmp.Length.ShouldBeGreaterThan(0);
                // BMP header starts with BM
                bmp[0].ShouldBe((byte)'B');
                bmp[1].ShouldBe((byte)'M');
            }
        }

        [Fact]
        public void bitmap_with_custom_hex_colors()
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode("Hex color BMP", QRCodeGenerator.ECCLevel.L))
            using (var bmpQr = new SKBitmapByteQRCode(data))
            {
                var bmp = bmpQr.GetGraphic(10, "#FF0000", "#00FF00");
                bmp.ShouldNotBeNull();
                bmp.Length.ShouldBeGreaterThan(0);
            }
        }

        [Fact]
        public void bitmap_with_byte_array_colors()
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode("Byte color BMP", QRCodeGenerator.ECCLevel.Q))
            using (var bmpQr = new SKBitmapByteQRCode(data))
            {
                var bmp = bmpQr.GetGraphic(10,
                    new byte[] { 0, 0, 0 },       // dark = black
                    new byte[] { 255, 255, 255 }); // light = white
                bmp.ShouldNotBeNull();
            }
        }

        [Fact]
        public void bitmap_helper_generates_output()
        {
            var bmp = SKBitmapByteQRCodeHelper.GetQRCode("Helper", QRCodeGenerator.ECCLevel.M, 10);
            bmp.ShouldNotBeNull();
            bmp.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void can_instantiate_parameterless()
        {
            var bmpQr = new SKBitmapByteQRCode();
            bmpQr.ShouldNotBeNull();
        }
    }
}
