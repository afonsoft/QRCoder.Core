using QRCoder.Core.Extensions;
using Shouldly;
using SkiaSharp;
using Xunit;

namespace QRCoder.Core.Tests.Extensions
{
    public class SKColorExtensionsTests
    {
        [Fact]
        public void to_hex_returns_argb_format()
        {
            var color = new SKColor(255, 0, 0, 255); // Red, fully opaque
            var hex = color.ToHex();
            hex.ShouldBe("#FFFF0000");
        }

        [Fact]
        public void to_hex_with_transparency()
        {
            var color = new SKColor(0, 128, 255, 128);
            var hex = color.ToHex();
            hex.ShouldBe("#800080FF");
        }

        [Fact]
        public void to_hex_black()
        {
            var hex = SKColors.Black.ToHex();
            hex.ShouldBe("#FF000000");
        }

        [Fact]
        public void to_hex_white()
        {
            var hex = SKColors.White.ToHex();
            hex.ShouldBe("#FFFFFFFF");
        }

        [Fact]
        public void from_hex_6_digit_rgb()
        {
            var color = SKColorExtensions.FromHex("#FF0000");
            color.Red.ShouldBe((byte)255);
            color.Green.ShouldBe((byte)0);
            color.Blue.ShouldBe((byte)0);
        }

        [Fact]
        public void from_hex_8_digit_argb()
        {
            var color = SKColorExtensions.FromHex("#80FF0000");
            color.Red.ShouldBe((byte)255);
            color.Green.ShouldBe((byte)0);
            color.Blue.ShouldBe((byte)0);
        }

        [Fact]
        public void from_hex_without_hash()
        {
            var color = SKColorExtensions.FromHex("00FF00");
            color.Red.ShouldBe((byte)0);
            color.Green.ShouldBe((byte)255);
            color.Blue.ShouldBe((byte)0);
        }

        [Fact]
        public void from_hex_null_returns_transparent()
        {
            var color = SKColorExtensions.FromHex(null);
            color.ShouldBe(SKColors.Transparent);
        }

        [Fact]
        public void from_hex_empty_returns_transparent()
        {
            var color = SKColorExtensions.FromHex("");
            color.ShouldBe(SKColors.Transparent);
        }

        [Fact]
        public void from_hex_invalid_length_returns_transparent()
        {
            var color = SKColorExtensions.FromHex("#FFF");
            color.ShouldBe(SKColors.Transparent);
        }
    }
}
