using QRCoder.Core.Tests.Helpers;
using QRCoder.Core.Tests.Helpers.XUnitExtenstions;
using Shouldly;
using SkiaSharp;
using Xunit;

namespace QRCoder.Core.Tests
{
    public class ArtQRCodeRendererTests
    {
        [Fact]
        [Category("QRRenderer/ArtQRCode")]
        public void can_create_standard_qrcode_graphic()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var bmp = new ArtQRCode(data).GetGraphic(10);

            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("b9ecef2ee7e769d17f5e00914c7452bb");
        }

        [Fact]
        [Category("QRRenderer/ArtQRCode")]
        public void can_create_standard_qrcode_graphic_with_custom_finder()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var finder = new SKBitmap(15, 15);
            var bmp = new ArtQRCode(data).GetGraphic(10, SKColors.Black, SKColors.White, SKColors.Transparent, finderPatternImage: finder);

            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("442648a1087f78955773c261b45665c9");
        }

        [Fact]
        [Category("QRRenderer/ArtQRCode")]
        public void can_create_standard_qrcode_graphic_without_quietzone()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var bmp = new ArtQRCode(data).GetGraphic(10, SKColors.Black, SKColors.White, SKColors.Transparent, drawQuietZones: false);

            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("4bbf0a58f3dc2c82cae0ad874da92028");
        }

        [Fact]
        [Category("QRRenderer/ArtQRCode")]
        public void can_create_standard_qrcode_graphic_with_background()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var bmp = new ArtQRCode(data).GetGraphic(SKBitmap.Decode(System.IO.Path.Combine(HelperFunctions.GetAssemblyPath(), "assets", "noun_software-engineer_2909346.png")));
            //Used logo is licensed under public domain. Ref.: https://thenounproject.com/Iconathon1/collection/redefining-women/?i=2909346

            var result = HelperFunctions.BitmapToHash(bmp);

            result.ShouldBe("b9ecef2ee7e769d17f5e00914c7452bb");
        }

        [Fact]
        [Category("QRRenderer/ArtQRCode")]
        public void should_throw_pixelfactor_oor_exception()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var aCode = new ArtQRCode(data);

            var exception = Record.Exception(() => aCode.GetGraphic(10, SKColors.Black, SKColors.White, SKColors.Transparent, pixelSizeFactor: 2));
            Assert.NotNull(exception);
            Assert.IsType<System.Exception>(exception);
            exception.Message.ShouldBe("The parameter pixelSize must be between 0 and 1. (0-100%)");
        }

        [Fact]
        [Category("QRRenderer/ArtQRCode")]
        public void can_instantate_parameterless()
        {
            var asciiCode = new ArtQRCode();
            asciiCode.ShouldNotBeNull();
            asciiCode.ShouldBeOfType<ArtQRCode>();
        }

        [Fact]
        [Category("QRRenderer/ArtQRCode")]
        public void can_render_artqrcode_from_helper()
        {
            //Create QR code
            var bmp = ArtQRCodeHelper.GetQRCode("A", 10, SKColors.Black, SKColors.White, SKColors.Transparent, QRCodeGenerator.ECCLevel.L);

            var result = HelperFunctions.BitmapToHash(bmp);
            result.ShouldBe("ed4718421930b85bc6c5aeaa11e4d860");
        }
    }
}