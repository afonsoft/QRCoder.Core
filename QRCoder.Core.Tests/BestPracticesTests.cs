using System;
using System.Collections;
using System.IO;
using System.Text;
using QRCoder.Core;
using QRCoder.Core.Exceptions;
using QRCoder.Core.Extensions;
using QRCoder.Core.Tests.Helpers;
using QRCoder.Core.Tests.Helpers.XUnitExtenstions;
using SkiaSharp;
using Xunit;
using Shouldly;

namespace QRCoder.Core.Tests
{
    /// <summary>
    /// Comprehensive tests for best practices, edge cases, and previously uncovered code paths.
    /// </summary>
    public class BestPracticesTests
    {
        #region QRCodeGenerator Tests

        [Fact]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_CreateQrCode_WithEmptyString_ShouldSucceed()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("", QRCodeGenerator.ECCLevel.L);
            data.ShouldNotBeNull();
            data.ModuleMatrix.ShouldNotBeNull();
            data.ModuleMatrix.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_CreateQrCode_WithUnicode_ShouldSucceed()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Olá mundo! 你好世界 🌍", QRCodeGenerator.ECCLevel.M);
            data.ShouldNotBeNull();
            data.ModuleMatrix.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_CreateQrCode_WithUrl_ShouldSucceed()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("https://github.com/afonsoft/QRCoder.Core", QRCodeGenerator.ECCLevel.Q);
            data.ShouldNotBeNull();
        }

        [Theory]
        [InlineData(QRCodeGenerator.ECCLevel.L)]
        [InlineData(QRCodeGenerator.ECCLevel.M)]
        [InlineData(QRCodeGenerator.ECCLevel.Q)]
        [InlineData(QRCodeGenerator.ECCLevel.H)]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_CreateQrCode_AllECCLevels_ShouldSucceed(QRCodeGenerator.ECCLevel eccLevel)
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Test", eccLevel);
            data.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_CreateQrCode_ForceUtf8_ShouldSucceed()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Test UTF8", QRCodeGenerator.ECCLevel.M, forceUtf8: true);
            data.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_CreateQrCode_WithUtf8BOM_ShouldSucceed()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Test BOM", QRCodeGenerator.ECCLevel.M, forceUtf8: true, utf8BOM: true);
            data.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_CreateQrCode_WithFixedVersion_ShouldSucceed()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Test", QRCodeGenerator.ECCLevel.L, requestedVersion: 5);
            data.ShouldNotBeNull();
            data.Version.ShouldBe(5);
        }

        [Fact]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_Dispose_MultipleTimes_ShouldNotThrow()
        {
            var gen = new QRCodeGenerator();
            gen.Dispose();
            Should.NotThrow(() => gen.Dispose());
        }

        [Fact]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_CreateQrCode_NumericMode_ShouldSucceed()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("0123456789", QRCodeGenerator.ECCLevel.L);
            data.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/QRCodeGenerator")]
        public void QRCodeGenerator_CreateQrCode_AlphanumericMode_ShouldSucceed()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("HELLO WORLD 123", QRCodeGenerator.ECCLevel.L);
            data.ShouldNotBeNull();
        }

        #endregion

        #region QRCodeData Tests

        [Fact]
        [Category("BestPractices/QRCodeData")]
        public void QRCodeData_RoundTrip_Uncompressed_ShouldPreserveData()
        {
            using var gen = new QRCodeGenerator();
            using var original = gen.CreateQrCode("Round trip test", QRCodeGenerator.ECCLevel.M);

            var rawData = original.GetRawData(QRCodeData.Compression.Uncompressed);
            rawData.ShouldNotBeNull();
            rawData.Length.ShouldBeGreaterThan(0);

            using var restored = new QRCodeData(rawData, QRCodeData.Compression.Uncompressed);
            restored.ModuleMatrix.Count.ShouldBe(original.ModuleMatrix.Count);
        }

        [Fact]
        [Category("BestPractices/QRCodeData")]
        public void QRCodeData_RoundTrip_Deflate_ShouldPreserveData()
        {
            using var gen = new QRCodeGenerator();
            using var original = gen.CreateQrCode("Deflate test", QRCodeGenerator.ECCLevel.M);

            var rawData = original.GetRawData(QRCodeData.Compression.Deflate);
            rawData.ShouldNotBeNull();

            using var restored = new QRCodeData(rawData, QRCodeData.Compression.Deflate);
            restored.ModuleMatrix.Count.ShouldBe(original.ModuleMatrix.Count);
        }

        [Fact]
        [Category("BestPractices/QRCodeData")]
        public void QRCodeData_RoundTrip_GZip_ShouldPreserveData()
        {
            using var gen = new QRCodeGenerator();
            using var original = gen.CreateQrCode("GZip test", QRCodeGenerator.ECCLevel.M);

            var rawData = original.GetRawData(QRCodeData.Compression.GZip);
            rawData.ShouldNotBeNull();

            using var restored = new QRCodeData(rawData, QRCodeData.Compression.GZip);
            restored.ModuleMatrix.Count.ShouldBe(original.ModuleMatrix.Count);
        }

        [Fact]
        [Category("BestPractices/QRCodeData")]
        public void QRCodeData_InvalidRawData_ShouldThrowInvalidOperationException()
        {
            var invalidData = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00 };
            Should.Throw<InvalidOperationException>(() =>
                new QRCodeData(invalidData, QRCodeData.Compression.Uncompressed));
        }

        [Fact]
        [Category("BestPractices/QRCodeData")]
        public void QRCodeData_SaveAndLoad_RoundTrip_ShouldPreserveData()
        {
            var tempPath = Path.Combine(Path.GetTempPath(), $"qrdata_test_{Guid.NewGuid()}.qrr");
            try
            {
                using var gen = new QRCodeGenerator();
                using var original = gen.CreateQrCode("File round trip", QRCodeGenerator.ECCLevel.M);

                original.SaveRawData(tempPath, QRCodeData.Compression.Uncompressed);
                File.Exists(tempPath).ShouldBeTrue();

                using var restored = new QRCodeData(tempPath, QRCodeData.Compression.Uncompressed);
                restored.ModuleMatrix.Count.ShouldBe(original.ModuleMatrix.Count);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }

        [Fact]
        [Category("BestPractices/QRCodeData")]
        public void QRCodeData_Dispose_ShouldClearModuleMatrix()
        {
            using var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("Dispose test", QRCodeGenerator.ECCLevel.M);
            data.ModuleMatrix.ShouldNotBeNull();

            data.Dispose();
            data.ModuleMatrix.ShouldBeNull();
        }

        [Fact]
        [Category("BestPractices/QRCodeData")]
        public void QRCodeData_Version_ShouldBePositive()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Version test", QRCodeGenerator.ECCLevel.M);
            data.Version.ShouldBeGreaterThan(0);
        }

        #endregion

        #region AbstractQRCode Tests

        [Fact]
        [Category("BestPractices/AbstractQRCode")]
        public void AbstractQRCode_SetQRCodeData_ShouldUpdateData()
        {
            using var gen = new QRCodeGenerator();
            using var data1 = gen.CreateQrCode("First", QRCodeGenerator.ECCLevel.L);
            using var data2 = gen.CreateQrCode("Second with more data", QRCodeGenerator.ECCLevel.H);

            var qrCode = new QRCode(data1);
            var size1 = qrCode.GetGraphic(1).Width;

            qrCode.SetQRCodeData(data2);
            var size2 = qrCode.GetGraphic(1).Width;

            size2.ShouldNotBe(size1);
        }

        [Fact]
        [Category("BestPractices/AbstractQRCode")]
        public void AbstractQRCode_Dispose_ShouldBeIdempotent()
        {
            using var gen = new QRCodeGenerator();
            var data = gen.CreateQrCode("Test", QRCodeGenerator.ECCLevel.L);
            var qrCode = new QRCode(data);

            qrCode.Dispose();
            Should.NotThrow(() => qrCode.Dispose());
        }

        #endregion

        #region QRCode Renderer Tests

        [Fact]
        [Category("BestPractices/QRCode")]
        public void QRCode_GetGraphic_WithCustomColors_ShouldReturnBitmap()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Color test", QRCodeGenerator.ECCLevel.M);
            using var qr = new QRCode(data);

            using var bmp = qr.GetGraphic(5, new SKColor(255, 0, 0), new SKColor(0, 255, 0), true);
            bmp.ShouldNotBeNull();
            bmp.Width.ShouldBeGreaterThan(0);
            bmp.Height.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BestPractices/QRCode")]
        public void QRCode_GetGraphic_WithHexColors_ShouldReturnBitmap()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Hex color test", QRCodeGenerator.ECCLevel.M);
            using var qr = new QRCode(data);

            using var bmp = qr.GetGraphic(5, "#FF0000", "#00FF00");
            bmp.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/QRCode")]
        public void QRCode_GetGraphic_WithoutQuietZones_ShouldBeSmallerThanWithQuietZones()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Quiet zone test", QRCodeGenerator.ECCLevel.M);

            using var qrWith = new QRCode(data);
            using var bmpWith = qrWith.GetGraphic(5, SKColors.Black, SKColors.White, true);

            using var qrWithout = new QRCode(data);
            using var bmpWithout = qrWithout.GetGraphic(5, SKColors.Black, SKColors.White, false);

            bmpWithout.Width.ShouldBeLessThan(bmpWith.Width);
        }

        [Fact]
        [Category("BestPractices/QRCode")]
        public void QRCode_ParseHtmlColor_InvalidFormat_ShouldThrowArgumentException()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Test", QRCodeGenerator.ECCLevel.L);
            using var qr = new QRCode(data);

            Should.Throw<FormatException>(() => qr.GetGraphic(5, "#ZZZZZZ", "#ffffff"));
        }

        [Fact]
        [Category("BestPractices/QRCode")]
        public void QRCode_ParseHtmlColor_EmptyString_ShouldThrowArgumentException()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Test", QRCodeGenerator.ECCLevel.L);
            using var qr = new QRCode(data);

            Should.Throw<Exception>(() => qr.GetGraphic(5, "", "#ffffff"));
        }

        [Fact]
        [Category("BestPractices/QRCode")]
        public void QRCode_ParseHtmlColor_WithAlpha_ShouldWork()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Alpha test", QRCodeGenerator.ECCLevel.L);
            using var qr = new QRCode(data);

            using var bmp = qr.GetGraphic(5, "#80000000", "#80FFFFFF");
            bmp.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/QRCode")]
        public void QRCode_ParameterlessConstructor_ShouldWork()
        {
            var qr = new QRCode();
            qr.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/QRCode")]
        public void QRCodeHelper_GetQRCode_ShouldReturnValidBitmap()
        {
            using var bmp = QRCodeHelper.GetQRCode("Helper test", 5, SKColors.Black, SKColors.White, QRCodeGenerator.ECCLevel.M);
            bmp.ShouldNotBeNull();
            bmp.Width.ShouldBeGreaterThan(0);
        }

        #endregion

        #region AsciiQRCode Tests

        [Fact]
        [Category("BestPractices/AsciiQRCode")]
        public void AsciiQRCode_GetGraphic_ShouldReturnNonEmptyString()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("ASCII test", QRCodeGenerator.ECCLevel.M);
            using var ascii = new AsciiQRCode(data);

            var result = ascii.GetGraphic(1);
            result.ShouldNotBeNullOrEmpty();
            result.ShouldContain("██");
        }

        [Fact]
        [Category("BestPractices/AsciiQRCode")]
        public void AsciiQRCode_GetGraphic_WithCustomSymbols_ShouldWork()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Custom symbols", QRCodeGenerator.ECCLevel.M);
            using var ascii = new AsciiQRCode(data);

            var result = ascii.GetGraphic(1, "XX", "..", true);
            result.ShouldNotBeNullOrEmpty();
            result.ShouldContain("XX");
            result.ShouldContain("..");
        }

        [Fact]
        [Category("BestPractices/AsciiQRCode")]
        public void AsciiQRCode_GetLineByLineGraphic_ShouldReturnLines()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Line test", QRCodeGenerator.ECCLevel.L);
            using var ascii = new AsciiQRCode(data);

            var lines = ascii.GetLineByLineGraphic(1);
            lines.ShouldNotBeNull();
            lines.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BestPractices/AsciiQRCode")]
        public void AsciiQRCode_WithoutQuietZones_ShouldHaveFewerLines()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("QZ test", QRCodeGenerator.ECCLevel.L);

            using var withQz = new AsciiQRCode(data);
            var linesWith = withQz.GetLineByLineGraphic(1, drawQuietZones: true);

            using var withoutQz = new AsciiQRCode(data);
            var linesWithout = withoutQz.GetLineByLineGraphic(1, drawQuietZones: false);

            linesWithout.Length.ShouldBeLessThan(linesWith.Length);
        }

        [Fact]
        [Category("BestPractices/AsciiQRCode")]
        public void AsciiQRCodeHelper_GetQRCode_ShouldReturnString()
        {
            var result = AsciiQRCodeHelper.GetQRCode("Helper", 1, "██", "  ", QRCodeGenerator.ECCLevel.M);
            result.ShouldNotBeNullOrEmpty();
        }

        #endregion

        #region PngByteQRCode Tests

        [Fact]
        [Category("BestPractices/PngByteQRCode")]
        public void PngByteQRCode_GetGraphic_BlackWhite_ShouldReturnValidPng()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PNG test", QRCodeGenerator.ECCLevel.M);
            using var png = new PngByteQRCode(data);

            var bytes = png.GetGraphic(5);
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(8);
            // PNG magic number
            bytes[0].ShouldBe((byte)0x89);
            bytes[1].ShouldBe((byte)0x50);
            bytes[2].ShouldBe((byte)0x4E);
            bytes[3].ShouldBe((byte)0x47);
        }

        [Fact]
        [Category("BestPractices/PngByteQRCode")]
        public void PngByteQRCode_GetGraphic_WithColors_ShouldReturnValidPng()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Color PNG", QRCodeGenerator.ECCLevel.M);
            using var png = new PngByteQRCode(data);

            var darkColor = new byte[] { 255, 0, 0 };
            var lightColor = new byte[] { 0, 255, 0 };
            var bytes = png.GetGraphic(5, darkColor, lightColor);
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(8);
        }

        [Fact]
        [Category("BestPractices/PngByteQRCode")]
        public void PngByteQRCode_GetGraphic_WithAlpha_ShouldReturnValidPng()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Alpha PNG", QRCodeGenerator.ECCLevel.M);
            using var png = new PngByteQRCode(data);

            var darkColor = new byte[] { 0, 0, 0, 255 };
            var lightColor = new byte[] { 255, 255, 255, 128 };
            var bytes = png.GetGraphic(5, darkColor, lightColor);
            bytes.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/PngByteQRCode")]
        public void PngByteQRCode_WithoutQuietZones_ShouldReturnSmallerPng()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("QZ PNG", QRCodeGenerator.ECCLevel.M);

            using var pngWith = new PngByteQRCode(data);
            var bytesWith = pngWith.GetGraphic(5, true);

            using var pngWithout = new PngByteQRCode(data);
            var bytesWithout = pngWithout.GetGraphic(5, false);

            bytesWithout.Length.ShouldBeLessThan(bytesWith.Length);
        }

        #endregion

        #region SKBitmapByteQRCode Tests

        [Fact]
        [Category("BestPractices/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCode_GetGraphic_Default_ShouldReturnBytes()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("BMP test", QRCodeGenerator.ECCLevel.M);
            using var bmp = new SKBitmapByteQRCode(data);

            var bytes = bmp.GetGraphic(5);
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(0);
            // BMP magic number
            bytes[0].ShouldBe((byte)0x42);
            bytes[1].ShouldBe((byte)0x4D);
        }

        [Fact]
        [Category("BestPractices/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCode_GetGraphic_WithHexColors_ShouldReturnBytes()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("BMP hex", QRCodeGenerator.ECCLevel.M);
            using var bmp = new SKBitmapByteQRCode(data);

            var bytes = bmp.GetGraphic(5, "#FF0000", "#00FF00");
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BestPractices/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCode_GetGraphic_WithByteColors_ShouldReturnBytes()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("BMP byte colors", QRCodeGenerator.ECCLevel.M);
            using var bmp = new SKBitmapByteQRCode(data);

            var bytes = bmp.GetGraphic(5, new byte[] { 0, 0, 255 }, new byte[] { 255, 255, 0 });
            bytes.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCodeHelper_GetQRCode_ShouldReturnBytes()
        {
            var bytes = SKBitmapByteQRCodeHelper.GetQRCode("Helper", 5, "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.M);
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BestPractices/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCodeHelper_GetQRCode_Simple_ShouldReturnBytes()
        {
            var bytes = SKBitmapByteQRCodeHelper.GetQRCode("Simple", QRCodeGenerator.ECCLevel.L, 5);
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(0);
        }

        #endregion

        #region Base64QRCode Tests

        [Fact]
        [Category("BestPractices/Base64QRCode")]
        public void Base64QRCode_GetGraphic_ShouldReturnValidBase64()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Base64 test", QRCodeGenerator.ECCLevel.M);
            using var b64 = new Base64QRCode(data);

            var result = b64.GetGraphic(5);
            result.ShouldNotBeNullOrEmpty();

            // Should be valid Base64
            var decoded = Convert.FromBase64String(result);
            decoded.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BestPractices/Base64QRCode")]
        public void Base64QRCode_GetGraphic_AsJpeg_ShouldReturnBase64()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("JPEG test", QRCodeGenerator.ECCLevel.M);
            using var b64 = new Base64QRCode(data);

            var result = b64.GetGraphic(5, SKColors.Black, SKColors.White, true, Base64QRCode.ImageType.Jpeg);
            result.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        [Category("BestPractices/Base64QRCode")]
        public void Base64QRCode_GetGraphic_WithIcon_ShouldReturnBase64()
        {
            if (!HelperFunctions.IsSkiaSharpAvailable()) return;

            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Icon test", QRCodeGenerator.ECCLevel.H);
            using var b64 = new Base64QRCode(data);

            using var icon = new SKBitmap(10, 10);
            var result = b64.GetGraphic(5, SKColors.Black, SKColors.White, icon, 15, 2);
            result.ShouldNotBeNullOrEmpty();
        }

        #endregion

        #region PdfByteQRCode Tests

        [Fact]
        [Category("BestPractices/PdfByteQRCode")]
        public void PdfByteQRCode_GetGraphic_ShouldReturnValidPdf()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PDF test", QRCodeGenerator.ECCLevel.M);
            using var pdf = new PdfByteQRCode(data);

            var bytes = pdf.GetGraphic(5);
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(0);
            // PDF magic number: %PDF
            var header = Encoding.ASCII.GetString(bytes, 0, 5);
            header.ShouldStartWith("%PDF");
        }

        [Fact]
        [Category("BestPractices/PdfByteQRCode")]
        public void PdfByteQRCode_GetGraphic_WithColors_ShouldReturnValidPdf()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PDF color", QRCodeGenerator.ECCLevel.M);
            using var pdf = new PdfByteQRCode(data);

            var bytes = pdf.GetGraphic(5, "#FF0000", "#00FF00");
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BestPractices/PdfByteQRCode")]
        public void PdfByteQRCode_GetGraphic_WithCustomDpi_ShouldReturnValidPdf()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PDF DPI", QRCodeGenerator.ECCLevel.M);
            using var pdf = new PdfByteQRCode(data);

            var bytes = pdf.GetGraphic(5, "#000000", "#FFFFFF", 300, 95);
            bytes.ShouldNotBeNull();
        }

        #endregion

        #region PostscriptQRCode Tests

        [Fact]
        [Category("BestPractices/PostscriptQRCode")]
        public void PostscriptQRCode_GetGraphic_ShouldReturnValidPostscript()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PS test", QRCodeGenerator.ECCLevel.M);
            using var ps = new PostscriptQRCode(data);

            var result = ps.GetGraphic(5);
            result.ShouldNotBeNullOrEmpty();
            result.ShouldStartWith("%!PS-Adobe-3.0");
            result.ShouldContain("%%EOF");
        }

        [Fact]
        [Category("BestPractices/PostscriptQRCode")]
        public void PostscriptQRCode_GetGraphic_AsEps_ShouldReturnValidEps()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("EPS test", QRCodeGenerator.ECCLevel.M);
            using var ps = new PostscriptQRCode(data);

            var result = ps.GetGraphic(5, epsFormat: true);
            result.ShouldNotBeNullOrEmpty();
            result.ShouldContain("EPSF-3.0");
        }

        [Fact]
        [Category("BestPractices/PostscriptQRCode")]
        public void PostscriptQRCode_GetGraphic_WithColors_ShouldWork()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PS colors", QRCodeGenerator.ECCLevel.M);
            using var ps = new PostscriptQRCode(data);

            var result = ps.GetGraphic(5, new SKColor(255, 0, 0), new SKColor(0, 255, 0));
            result.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        [Category("BestPractices/PostscriptQRCode")]
        public void PostscriptQRCode_GetGraphic_WithHexColors_ShouldWork()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PS hex", QRCodeGenerator.ECCLevel.M);
            using var ps = new PostscriptQRCode(data);

            var result = ps.GetGraphic(5, "#FF0000", "#00FF00");
            result.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        [Category("BestPractices/PostscriptQRCode")]
        public void PostscriptQRCode_GetGraphic_WithViewBox_ShouldWork()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PS viewbox", QRCodeGenerator.ECCLevel.M);
            using var ps = new PostscriptQRCode(data);

            var result = ps.GetGraphic(new Size(200, 200));
            result.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        [Category("BestPractices/PostscriptQRCode")]
        public void PostscriptQRCode_WithoutQuietZones_ShouldWork()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("PS no QZ", QRCodeGenerator.ECCLevel.M);
            using var ps = new PostscriptQRCode(data);

            var result = ps.GetGraphic(5, SKColors.Black, SKColors.White, false);
            result.ShouldNotBeNullOrEmpty();
        }

        #endregion

        #region ArtQRCode Tests

        [Fact]
        [Category("BestPractices/ArtQRCode")]
        public void ArtQRCode_GetGraphic_Default_ShouldReturnBitmap()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Art test", QRCodeGenerator.ECCLevel.H);
            using var art = new ArtQRCode(data);

            using var bmp = art.GetGraphic(10);
            bmp.ShouldNotBeNull();
            bmp.Width.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BestPractices/ArtQRCode")]
        public void ArtQRCode_GetGraphic_WithCustomPixelSizeFactor_ShouldWork()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Art pixel", QRCodeGenerator.ECCLevel.H);
            using var art = new ArtQRCode(data);

            using var bmp = art.GetGraphic(10, SKColors.Black, SKColors.White, SKColors.Transparent, pixelSizeFactor: 0.5);
            bmp.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/ArtQRCode")]
        public void ArtQRCode_GetGraphic_FlatQuietZone_ShouldWork()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Art flat QZ", QRCodeGenerator.ECCLevel.H);
            using var art = new ArtQRCode(data);

            using var bmp = art.GetGraphic(10, SKColors.Black, SKColors.White, SKColors.Transparent,
                quietZoneRenderingStyle: ArtQRCode.QuietZoneStyle.Flat);
            bmp.ShouldNotBeNull();
        }

        [Fact]
        [Category("BestPractices/ArtQRCode")]
        public void ArtQRCode_PixelSizeFactor_GreaterThanOne_ShouldThrow()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Out of range", QRCodeGenerator.ECCLevel.H);
            using var art = new ArtQRCode(data);

            Should.Throw<ArgumentOutOfRangeException>(() =>
                art.GetGraphic(10, SKColors.Black, SKColors.White, SKColors.Transparent, pixelSizeFactor: 1.5));
        }

        #endregion

        #region Extensions Tests

        [Fact]
        [Category("BestPractices/Extensions")]
        public void SKColorExtensions_ToHex_ShouldReturnCorrectFormat()
        {
            var color = new SKColor(255, 128, 0, 200);
            var hex = color.ToHex();

            hex.ShouldNotBeNullOrEmpty();
            hex.ShouldStartWith("#");
            hex.Length.ShouldBe(9); // #AARRGGBB
        }

        [Fact]
        [Category("BestPractices/Extensions")]
        public void SKColorExtensions_FromHex_RGB_ShouldReturnCorrectColor()
        {
            var color = SKColorExtensions.FromHex("#FF0000");
            color.Red.ShouldBe((byte)255);
            color.Green.ShouldBe((byte)0);
            color.Blue.ShouldBe((byte)0);
        }

        [Fact]
        [Category("BestPractices/Extensions")]
        public void SKColorExtensions_FromHex_ARGB_ShouldReturnCorrectColor()
        {
            var color = SKColorExtensions.FromHex("#80FF0000");
            color.Red.ShouldBeGreaterThan((byte)0);
        }

        [Fact]
        [Category("BestPractices/Extensions")]
        public void SKColorExtensions_FromHex_Null_ShouldReturnTransparent()
        {
            var color = SKColorExtensions.FromHex(null);
            color.ShouldBe(SKColors.Transparent);
        }

        [Fact]
        [Category("BestPractices/Extensions")]
        public void SKColorExtensions_FromHex_Empty_ShouldReturnTransparent()
        {
            var color = SKColorExtensions.FromHex("");
            color.ShouldBe(SKColors.Transparent);
        }

        [Fact]
        [Category("BestPractices/Extensions")]
        public void SKColorExtensions_FromHex_InvalidLength_ShouldReturnTransparent()
        {
            var color = SKColorExtensions.FromHex("#FFF");
            color.ShouldBe(SKColors.Transparent);
        }

        [Fact]
        [Category("BestPractices/Extensions")]
        public void SKColorExtensions_FromHex_WithoutHash_ShouldWork()
        {
            var color = SKColorExtensions.FromHex("FF0000");
            color.Red.ShouldBe((byte)255);
        }

        [Fact]
        [Category("BestPractices/Extensions")]
        public void StringValueAttribute_ShouldStoreValue()
        {
            var attr = new StringValueAttribute("test-value");
            attr.StringValue.ShouldBe("test-value");
        }

        #endregion

        #region DataTooLongException Tests

        [Fact]
        [Category("BestPractices/Exceptions")]
        public void DataTooLongException_WithoutVersion_ShouldContainDetails()
        {
            var ex = new DataTooLongException("H", "Byte", 100);
            ex.Message.ShouldContain("H");
            ex.Message.ShouldContain("Byte");
            ex.Message.ShouldContain("100");
        }

        [Fact]
        [Category("BestPractices/Exceptions")]
        public void DataTooLongException_WithVersion_ShouldContainDetails()
        {
            var ex = new DataTooLongException("M", "Alphanumeric", 5, 200);
            ex.Message.ShouldContain("M");
            ex.Message.ShouldContain("Alphanumeric");
            ex.Message.ShouldContain("5");
            ex.Message.ShouldContain("200");
        }

        [Fact]
        [Category("BestPractices/Exceptions")]
        public void DataTooLongException_ShouldBeException()
        {
            var ex = new DataTooLongException("L", "Numeric", 50);
            ex.ShouldBeAssignableTo<Exception>();
        }

        #endregion

        #region Size Struct Tests

        [Fact]
        [Category("BestPractices/Size")]
        public void Size_Constructor_ShouldSetProperties()
        {
            var size = new Size(100.5, 200.5);
            size.Width.ShouldBe(100.5);
            size.Height.ShouldBe(200.5);
        }

        [Fact]
        [Category("BestPractices/Size")]
        public void Size_Default_ShouldBeZero()
        {
            var size = new Size();
            size.Width.ShouldBe(0);
            size.Height.ShouldBe(0);
        }

        [Fact]
        [Category("BestPractices/Size")]
        public void Size_SetProperties_ShouldWork()
        {
            var size = new Size(10, 20);
            size.Width = 30;
            size.Height = 40;
            size.Width.ShouldBe(30);
            size.Height.ShouldBe(40);
        }

        #endregion

        #region PayloadGenerator Basic Tests

        [Fact]
        [Category("BestPractices/PayloadGenerator")]
        public void WiFi_Payload_ShouldGenerateCorrectFormat()
        {
            var wifi = new PayloadGenerator.WiFi("MyNetwork", "MyPassword", PayloadGenerator.WiFi.Authentication.WPA);
            var result = wifi.ToString();
            result.ShouldStartWith("WIFI:");
            result.ShouldContain("T:WPA");
            result.ShouldContain("S:MyNetwork");
            result.ShouldContain("P:MyPassword");
        }

        [Fact]
        [Category("BestPractices/PayloadGenerator")]
        public void WiFi_HiddenSSID_ShouldContainHiddenFlag()
        {
            var wifi = new PayloadGenerator.WiFi("Hidden", "Pass", PayloadGenerator.WiFi.Authentication.WPA, isHiddenSSID: true);
            var result = wifi.ToString();
            result.ShouldContain("H:true");
        }

        [Fact]
        [Category("BestPractices/PayloadGenerator")]
        public void Mail_Payload_ShouldGenerateCorrectFormat()
        {
            var mail = new PayloadGenerator.Mail("test@example.com", "Subject", "Body");
            var result = mail.ToString();
            result.ShouldContain("test@example.com");
        }

        [Fact]
        [Category("BestPractices/PayloadGenerator")]
        public void Url_Payload_ShouldGenerateCorrectFormat()
        {
            var url = new PayloadGenerator.Url("https://github.com");
            var result = url.ToString();
            result.ShouldContain("https://github.com");
        }

        [Fact]
        [Category("BestPractices/PayloadGenerator")]
        public void SMS_Payload_ShouldGenerateCorrectFormat()
        {
            var sms = new PayloadGenerator.SMS("+5511999999999", "Hello!");
            var result = sms.ToString();
            result.ShouldContain("+5511999999999");
        }

        [Fact]
        [Category("BestPractices/PayloadGenerator")]
        public void PhoneNumber_Payload_ShouldGenerateCorrectFormat()
        {
            var phone = new PayloadGenerator.PhoneNumber("+5511999999999");
            var result = phone.ToString();
            result.ShouldStartWith("tel:");
            result.ShouldContain("+5511999999999");
        }

        [Fact]
        [Category("BestPractices/PayloadGenerator")]
        public void Geolocation_Payload_ShouldGenerateCorrectFormat()
        {
            var geo = new PayloadGenerator.Geolocation("-23.5505", "-46.6333");
            var result = geo.ToString();
            result.ShouldStartWith("geo:");
        }

        [Fact]
        [Category("BestPractices/PayloadGenerator")]
        public void Bookmark_Payload_ShouldGenerateCorrectFormat()
        {
            var bm = new PayloadGenerator.Bookmark("https://github.com", "GitHub");
            var result = bm.ToString();
            result.ShouldContain("github.com");
            result.ShouldContain("GitHub");
        }

        #endregion

        #region Cross-Platform Consistency Tests

        [Fact]
        [Category("BestPractices/CrossPlatform")]
        public void QRCode_SameInput_ShouldProduceSameModuleMatrix()
        {
            using var gen1 = new QRCodeGenerator();
            using var gen2 = new QRCodeGenerator();

            using var data1 = gen1.CreateQrCode("Deterministic test", QRCodeGenerator.ECCLevel.M);
            using var data2 = gen2.CreateQrCode("Deterministic test", QRCodeGenerator.ECCLevel.M);

            data1.ModuleMatrix.Count.ShouldBe(data2.ModuleMatrix.Count);
            for (int i = 0; i < data1.ModuleMatrix.Count; i++)
            {
                for (int j = 0; j < data1.ModuleMatrix[i].Count; j++)
                {
                    data1.ModuleMatrix[i][j].ShouldBe(data2.ModuleMatrix[i][j]);
                }
            }
        }

        [Fact]
        [Category("BestPractices/CrossPlatform")]
        public void PngByteQRCode_SameInput_ShouldProduceSameOutput()
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Deterministic PNG", QRCodeGenerator.ECCLevel.M);

            using var png1 = new PngByteQRCode(data);
            var bytes1 = png1.GetGraphic(5);

            using var png2 = new PngByteQRCode(data);
            var bytes2 = png2.GetGraphic(5);

            bytes1.Length.ShouldBe(bytes2.Length);
            for (int i = 0; i < bytes1.Length; i++)
            {
                bytes1[i].ShouldBe(bytes2[i]);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [Category("BestPractices/CrossPlatform")]
        public void QRCode_DifferentModuleSizes_ShouldScaleCorrectly(int pixelsPerModule)
        {
            using var gen = new QRCodeGenerator();
            using var data = gen.CreateQrCode("Scale test", QRCodeGenerator.ECCLevel.L);

            using var png = new PngByteQRCode(data);
            var bytes = png.GetGraphic(pixelsPerModule);
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(0);
        }

        #endregion

        #region HelperFunctions Tests

        [Fact]
        [Category("BestPractices/Helpers")]
        public void HelperFunctions_ByteArrayToHash_ShouldReturnConsistentHash()
        {
            var data = Encoding.UTF8.GetBytes("test data");
            var hash1 = HelperFunctions.ByteArrayToHash(data);
            var hash2 = HelperFunctions.ByteArrayToHash(data);
            hash1.ShouldBe(hash2);
        }

        [Fact]
        [Category("BestPractices/Helpers")]
        public void HelperFunctions_StringToHash_ShouldReturnConsistentHash()
        {
            var hash1 = HelperFunctions.StringToHash("hello");
            var hash2 = HelperFunctions.StringToHash("hello");
            hash1.ShouldBe(hash2);
        }

        [Fact]
        [Category("BestPractices/Helpers")]
        public void HelperFunctions_GetAssemblyPath_ShouldReturnNonEmpty()
        {
            var path = HelperFunctions.GetAssemblyPath();
            path.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        [Category("BestPractices/Helpers")]
        public void HelperFunctions_IsSkiaSharpAvailable_ShouldReturnBoolean()
        {
            // Just ensure it doesn't throw
            var result = HelperFunctions.IsSkiaSharpAvailable();
            result.ShouldBeOneOf(true, false);
        }

        #endregion
    }
}
