using System;
using QRCoder.Core.Generators;
using QRCoder.Core.Renderers;
using Shouldly;
using Xunit;

namespace QRCoder.Core.Tests.Renderers
{
    public class Base64QRCodeTests
    {
        [Fact]
        public void can_render_base64_qrcode()
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode("Base64 test", QRCodeGenerator.ECCLevel.M))
            using (var b64Qr = new Base64QRCode(data))
            {
                var base64 = b64Qr.GetGraphic(10);
                base64.ShouldNotBeNullOrEmpty();

                // Should be valid base64
                var bytes = Convert.FromBase64String(base64);
                bytes.Length.ShouldBeGreaterThan(0);
            }
        }

        [Fact]
        public void base64_with_custom_colors()
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode("Color test", QRCodeGenerator.ECCLevel.L))
            using (var b64Qr = new Base64QRCode(data))
            {
                var base64 = b64Qr.GetGraphic(10, "#FF0000", "#FFFFFF");
                base64.ShouldNotBeNullOrEmpty();
                Convert.FromBase64String(base64).Length.ShouldBeGreaterThan(0);
            }
        }

        [Fact]
        public void base64_png_format()
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode("PNG format", QRCodeGenerator.ECCLevel.M))
            using (var b64Qr = new Base64QRCode(data))
            {
                var base64 = b64Qr.GetGraphic(10, "#000000", "#FFFFFF", imgType: Base64QRCode.ImageType.Png);
                var bytes = Convert.FromBase64String(base64);
                // PNG signature
                bytes[0].ShouldBe((byte)0x89);
                bytes[1].ShouldBe((byte)0x50); // P
                bytes[2].ShouldBe((byte)0x4E); // N
                bytes[3].ShouldBe((byte)0x47); // G
            }
        }

        [Fact]
        public void base64_helper_generates_output()
        {
            var base64 = Base64QRCodeHelper.GetQRCode("Helper", 10, "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.Q);
            base64.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void can_instantiate_parameterless()
        {
            var b64Qr = new Base64QRCode();
            b64Qr.ShouldNotBeNull();
        }
    }
}
