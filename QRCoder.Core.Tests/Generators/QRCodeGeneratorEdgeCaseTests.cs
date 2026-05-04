using System;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using Shouldly;
using Xunit;

namespace QRCoder.Core.Tests.Generators
{
    public class QRCodeGeneratorEdgeCaseTests
    {
        [Theory]
        [InlineData(QRCodeGenerator.ECCLevel.L)]
        [InlineData(QRCodeGenerator.ECCLevel.M)]
        [InlineData(QRCodeGenerator.ECCLevel.Q)]
        [InlineData(QRCodeGenerator.ECCLevel.H)]
        public void all_ecc_levels_generate_valid_data(QRCodeGenerator.ECCLevel level)
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Test", level);
            data.ShouldNotBeNull();
            data.ModuleMatrix.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void empty_string_generates_valid_qrcode()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("", QRCodeGenerator.ECCLevel.L);
            data.ShouldNotBeNull();
            data.ModuleMatrix.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void unicode_text_generates_valid_qrcode()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("こんにちは世界 🌍", QRCodeGenerator.ECCLevel.M, forceUtf8: true);
            data.ShouldNotBeNull();
            data.ModuleMatrix.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void numeric_only_input()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("1234567890", QRCodeGenerator.ECCLevel.L);
            data.ShouldNotBeNull();
            data.Version.ShouldBe(1);
        }

        [Fact]
        public void alphanumeric_input()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("HELLO WORLD", QRCodeGenerator.ECCLevel.L);
            data.ShouldNotBeNull();
        }

        [Fact]
        public void binary_data_generates_valid_qrcode()
        {
            var binaryData = new byte[] { 0x00, 0x01, 0x02, 0xFF, 0xFE };
            using var data = QRCodeGenerator.GenerateQrCode(binaryData, QRCodeGenerator.ECCLevel.M);
            data.ShouldNotBeNull();
            data.ModuleMatrix.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void force_utf8_with_bom()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Test UTF8 BOM", QRCodeGenerator.ECCLevel.L, forceUtf8: true, utf8BOM: true);
            data.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(20)]
        public void requested_version_is_respected(int version)
        {
            using var data = QRCodeGenerator.GenerateQrCode("Test", QRCodeGenerator.ECCLevel.L, requestedVersion: version);
            data.ShouldNotBeNull();
            data.Version.ShouldBe(version);
        }

        [Fact]
        public void static_generate_matches_instance_create()
        {
            using var gen = new QRCodeGenerator();
            using var data1 = gen.CreateQrCode("Test", QRCodeGenerator.ECCLevel.M);
            using var data2 = QRCodeGenerator.GenerateQrCode("Test", QRCodeGenerator.ECCLevel.M);

            data1.Version.ShouldBe(data2.Version);
            data1.ModuleMatrix.Count.ShouldBe(data2.ModuleMatrix.Count);
        }

        [Fact]
        public void payload_based_generation()
        {
            var payload = new PayloadGenerator.Url("https://github.com");
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode(payload);
            data.ShouldNotBeNull();
            data.ModuleMatrix.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void payload_based_generation_with_ecc()
        {
            var payload = new PayloadGenerator.Url("https://github.com");
            using var data = QRCodeGenerator.GenerateQrCode(payload, QRCodeGenerator.ECCLevel.H);
            data.ShouldNotBeNull();
        }

        [Fact]
        public void dispose_works_without_exception()
        {
            var gen = new QRCodeGenerator();
            gen.Dispose();
        }

        [Fact]
        public void special_characters_in_input()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("!@#$%^&*()_+-=[]{}|;':\",./<>?", QRCodeGenerator.ECCLevel.M);
            data.ShouldNotBeNull();
        }

        [Fact]
        public void url_with_query_params()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("https://example.com/path?key=value&foo=bar#section", QRCodeGenerator.ECCLevel.Q);
            data.ShouldNotBeNull();
        }

        [Fact]
        public void higher_ecc_produces_larger_matrix()
        {
            using var gen = new QRCodeGenerator();
            using var dataL = gen.CreateQrCode("Same text for comparison", QRCodeGenerator.ECCLevel.L);
            using var dataH = gen.CreateQrCode("Same text for comparison", QRCodeGenerator.ECCLevel.H);

            dataH.ModuleMatrix.Count.ShouldBeGreaterThanOrEqualTo(dataL.ModuleMatrix.Count);
        }
    }
}
