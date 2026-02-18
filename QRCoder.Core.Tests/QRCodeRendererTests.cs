using QRCoder.Core.Tests.Helpers;
using QRCoder.Core.Tests.Helpers.XUnitExtenstions;
using Shouldly;
using SkiaSharp;
using Xunit;

namespace QRCoder.Core.Tests
{
    public class QRCodeRendererTests
    {
        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_create_qrcode_standard_graphic()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var bmp = new QRCode(data).GetGraphic(10);

            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("1e0afd60c239d24be2ce0f8286a16918");
        }

        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_create_qrcode_standard_graphic_hex()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var bmp = new QRCode(data).GetGraphic(10, "#000000", "#ffffff");

            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("1e0afd60c239d24be2ce0f8286a16918");
        }

        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_create_qrcode_standard_graphic_without_quietzones()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var bmp = new QRCode(data).GetGraphic(5, SKColors.Black, SKColors.White, false);

            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("78f6af3170e47f3e930dfc05fa4f0cce");
        }

        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_create_qrcode_with_transparent_logo_graphic()
        {
            // Skip test if SkiaSharp is not available (CI environment)
            if (!HelperFunctions.IsSkiaSharpAvailable())
            {
                return; // Skip test gracefully
            }

            //Create QR code
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);

            var bmp = new QRCode(data).GetGraphic(10, SKColors.Black, SKColors.Transparent, icon: SKBitmap.Decode(System.IO.Path.Combine(HelperFunctions.GetAssemblyPath(), "assets", "noun_software-engineer_2909346.png")));
            //Used logo is licensed under public domain. Ref.: https://thenounproject.com/Iconathon1/collection/redefining-women/?i=2909346
            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("947e264401b6e4958d8c955c1e8574cb");
        }

        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_create_qrcode_with_non_transparent_logo_graphic()
        {
            // Skip test if SkiaSharp is not available (CI environment)
            if (!HelperFunctions.IsSkiaSharpAvailable())
            {
                return; // Skip test gracefully
            }

            //Create QR code
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var bmp = new QRCode(data).GetGraphic(10, SKColors.Black, SKColors.White, icon: SKBitmap.Decode(System.IO.Path.Combine(HelperFunctions.GetAssemblyPath(), "assets", "noun_software-engineer_2909346.png")));
            //Used logo is licensed under public domain. Ref.: https://thenounproject.com/Iconathon1/collection/redefining-women/?i=2909346

            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("1e0afd60c239d24be2ce0f8286a16918");
        }

        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_create_qrcode_with_logo_and_with_transparent_border()
        {
            // Skip test if SkiaSharp is not available (CI environment)
            if (!HelperFunctions.IsSkiaSharpAvailable())
            {
                return; // Skip test gracefully
            }

            //Create QR code
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);

            var logo = SKBitmap.Decode(System.IO.Path.Combine(HelperFunctions.GetAssemblyPath(), "assets", "noun_software-engineer_2909346.png"));
            var bmp = new QRCode(data).GetGraphic(10, SKColors.Black, SKColors.Transparent, icon: logo, iconBorderWidth: 6);
            //Used logo is licensed under public domain. Ref.: https://thenounproject.com/Iconathon1/collection/redefining-women/?i=2909346
            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("947e264401b6e4958d8c955c1e8574cb");
        }

        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_create_qrcode_with_logo_and_with_standard_border()
        {
            // Skip test if SkiaSharp is not available (CI environment)
            if (!HelperFunctions.IsSkiaSharpAvailable())
            {
                return; // Skip test gracefully
            }

            //Create QR code
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);

            var logo = SKBitmap.Decode(System.IO.Path.Combine(HelperFunctions.GetAssemblyPath(), "assets", "noun_software-engineer_2909346.png"));
            var bmp = new QRCode(data).GetGraphic(10, SKColors.Black, SKColors.White, icon: logo, iconBorderWidth: 6);
            //Used logo is licensed under public domain. Ref.: https://thenounproject.com/Iconathon1/collection/redefining-women/?i=2909346
            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("09866787899d8f4ab4bd08df75e47e55");
        }

        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_create_qrcode_with_logo_and_with_custom_border()
        {
            // Skip test if SkiaSharp is not available (CI environment)
            if (!HelperFunctions.IsSkiaSharpAvailable())
            {
                return; // Skip test gracefully
            }

            //Create QR code
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);

            var logo = SKBitmap.Decode(System.IO.Path.Combine(HelperFunctions.GetAssemblyPath(), "assets", "noun_software-engineer_2909346.png"));
            var bmp = new QRCode(data).GetGraphic(10, SKColors.Black, SKColors.Transparent, icon: logo, iconBorderWidth: 6, iconBackgroundSKColor: SKColors.DarkGreen);
            //Used logo is licensed under public domain. Ref.: https://thenounproject.com/Iconathon1/collection/redefining-women/?i=2909346
            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("5e39d9e2a412dfcca26352234b0ce6da");
        }

        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_instantate_qrcode_parameterless()
        {
            var svgCode = new QRCode();
            svgCode.ShouldNotBeNull();
            svgCode.ShouldBeOfType<QRCode>();
        }

        [Fact]
        [Category("QRRenderer/QRCode")]
        public void can_render_qrcode_from_helper()
        {
            //Create QR code
            var bmp = QRCodeHelper.GetQRCode("This is a quick test! 123#?", 10, SKColors.Black, SKColors.White, QRCodeGenerator.ECCLevel.H);

            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("1e0afd60c239d24be2ce0f8286a16918");
        }
    }
}