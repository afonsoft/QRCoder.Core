using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using Shouldly;
using SkiaSharp;
using Xunit;

namespace QRCoder.Core.Tests.Renderers
{
    public class PostscriptQRCodeTests
    {
        [Fact]
        public void can_render_postscript_qrcode()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PS test", QRCodeGenerator.ECCLevel.M);
            using var psQr = new PostscriptQRCode(data);

            var ps = psQr.GetGraphic(20);
            ps.ShouldNotBeNullOrEmpty();
            ps.ShouldContain("newpath");
        }

        [Fact]
        public void postscript_with_viewbox()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("ViewBox PS", QRCodeGenerator.ECCLevel.L);
            using var psQr = new PostscriptQRCode(data);

            var ps = psQr.GetGraphic(new Size(200, 200));
            ps.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void postscript_eps_format()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("EPS test", QRCodeGenerator.ECCLevel.Q);
            using var psQr = new PostscriptQRCode(data);

            var eps = psQr.GetGraphic(new Size(100, 100), epsFormat: true);
            eps.ShouldNotBeNullOrEmpty();
            eps.ShouldContain("EPSF");
        }

        [Fact]
        public void postscript_with_custom_colors()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Color PS", QRCodeGenerator.ECCLevel.M);
            using var psQr = new PostscriptQRCode(data);

            var ps = psQr.GetGraphic(new Size(150, 150), SKColors.DarkBlue, SKColors.LightGray);
            ps.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void postscript_helper_generates_output()
        {
            var ps = PostscriptQRCodeHelper.GetQRCode("Helper test", 20, "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.M);
            ps.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        public void can_instantiate_parameterless()
        {
            var psQr = new PostscriptQRCode();
            psQr.ShouldNotBeNull();
        }
    }
}
