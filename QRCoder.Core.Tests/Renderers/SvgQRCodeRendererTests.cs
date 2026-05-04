using QRCoder.Core.Abstractions;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using QRCoder.Core.Tests.Helpers;
using QRCoder.Core.Tests.Helpers.XUnitExtenstions;
using Shouldly;
using SkiaSharp;
using System;
using System.IO;
using Xunit;

namespace QRCoder.Core.Tests
{
    public class SvgQRCodeRendererTests
    {
        private string GetAssemblyPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode_simple()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.L);
            var svg = new SvgQRCode(data).GetGraphic(5);

            svg.ShouldNotBeNullOrEmpty();
            svg.ShouldContain("<svg ");
            svg.ShouldContain("</svg>");
            svg.ShouldContain("width=\"");
            svg.ShouldContain("height=\"");
            svg.ShouldContain("<rect ");
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var svg = new SvgQRCode(data).GetGraphic(10, SKColors.Red, SKColors.White);

            svg.ShouldNotBeNullOrEmpty();
            svg.ShouldContain("<svg ");
            svg.ShouldContain("</svg>");
            svg.ShouldContain("FF0000"); // Red color
            svg.ShouldContain("FFFFFF"); // White color
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode_viewbox_mode()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var svg = new SvgQRCode(data).GetGraphic(new Size(128, 128));

            svg.ShouldNotBeNullOrEmpty();
            svg.ShouldContain("<svg ");
            svg.ShouldContain("width=\"128\"");
            svg.ShouldContain("height=\"128\"");
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode_viewbox_mode_viewboxattr()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var svg = new SvgQRCode(data).GetGraphic(new Size(128, 128), sizingMode: SvgQRCode.SizingMode.ViewBoxAttribute);

            svg.ShouldNotBeNullOrEmpty();
            svg.ShouldContain("<svg ");
            svg.ShouldContain("viewBox=\"0 0 128 128\"");
            // The <svg> tag should use viewBox instead of width/height attributes
            svg.ShouldStartWith("<svg ");
            var svgTag = svg.Substring(0, svg.IndexOf(">") + 1);
            svgTag.ShouldNotContain("width=\"128\" height=\"128\"");
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode_without_quietzones()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var svgWithQuiet = new SvgQRCode(data).GetGraphic(10, SKColors.Red, SKColors.White, true);
            var svgNoQuiet = new SvgQRCode(data).GetGraphic(10, SKColors.Red, SKColors.White, false);

            svgNoQuiet.ShouldNotBeNullOrEmpty();
            svgNoQuiet.ShouldContain("<svg ");
            // SVG without quiet zones should be smaller
            svgNoQuiet.Length.ShouldBeLessThan(svgWithQuiet.Length);
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode_without_quietzones_hex()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);
            var svg = new SvgQRCode(data).GetGraphic(10, "#000000", "#ffffff", false);

            svg.ShouldNotBeNullOrEmpty();
            svg.ShouldContain("<svg ");
            svg.ShouldContain("000000"); // Dark color
            svg.ShouldContain("<rect ");
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode_with_png_logo()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);

            var logoPath = Path.Combine(GetAssemblyPath(), "assets", "noun_software-engineer_2909346.png");
            var logoBitmap = SKBitmap.Decode(logoPath);
            var logoObj = new SvgQRCode.SvgLogo(iconRasterized: logoBitmap, 15);
            logoObj.GetMediaType().ShouldBe(SvgQRCode.SvgLogo.MediaType.PNG);

            var svg = new SvgQRCode(data).GetGraphic(10, SKColors.DarkGray, SKColors.White, logo: logoObj);

            svg.ShouldNotBeNullOrEmpty();
            svg.ShouldContain("<svg ");
            svg.ShouldContain("<image ");
            svg.ShouldContain("data:image/png;base64,");
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode_with_svg_logo_embedded()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);

            var logoPath = Path.Combine(GetAssemblyPath(), "assets", "noun_Scientist_2909361.svg");
            var logoSvg = File.ReadAllText(logoPath);
            var logoObj = new SvgQRCode.SvgLogo(logoSvg, 20);
            logoObj.GetMediaType().ShouldBe(SvgQRCode.SvgLogo.MediaType.SVG);

            var svg = new SvgQRCode(data).GetGraphic(10, SKColors.DarkGray, SKColors.White, logo: logoObj);

            svg.ShouldNotBeNullOrEmpty();
            svg.ShouldContain("<svg ");
            svg.ShouldContain("</svg>");
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode_with_svg_logo_image_tag()
        {
            var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("This is a quick test! 123#?", QRCodeGenerator.ECCLevel.H);

            var logoPath = Path.Combine(GetAssemblyPath(), "assets", "noun_Scientist_2909361.svg");
            var logoSvg = File.ReadAllText(logoPath);
            var logoObj = new SvgQRCode.SvgLogo(logoSvg, 20, iconEmbedded: false);

            var svg = new SvgQRCode(data).GetGraphic(10, SKColors.DarkGray, SKColors.White, logo: logoObj);

            svg.ShouldNotBeNullOrEmpty();
            svg.ShouldContain("<svg ");
            svg.ShouldContain("<image ");
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_instantate_parameterless()
        {
            var svgCode = new SvgQRCode();
            svgCode.ShouldNotBeNull();
            svgCode.ShouldBeOfType<SvgQRCode>();
        }

        [Fact]
        [Category("QRRenderer/SvgQRCode")]
        public void can_render_svg_qrcode_from_helper()
        {
            var svg = SvgQRCodeHelper.GetQRCode("A", 2, "#000000", "#ffffff", QRCodeGenerator.ECCLevel.Q);

            svg.ShouldNotBeNullOrEmpty();
            svg.ShouldContain("<svg ");
            svg.ShouldContain("</svg>");
            svg.ShouldContain("000000");
        }
    }
}
