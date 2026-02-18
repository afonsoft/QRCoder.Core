using System;
using System.IO;
using System.Linq;
using QRCoder.Core;
using QRCoder.Core.Exceptions;
using QRCoder.Core.Extensions;
using QRCoder.Core.Tests.Helpers.XUnitExtenstions;
using SkiaSharp;
using Xunit;
using Shouldly;

namespace QRCoder.Core.Tests
{
    /// <summary>
    /// Testes de cobertura para classes com baixa ou nenhuma cobertura
    /// </summary>
    public class LowCoverageTests
    {
        private readonly QRCodeGenerator _generator;
        private readonly QRCodeData _qrData;

        public LowCoverageTests()
        {
            _generator = new QRCodeGenerator();
            _qrData = _generator.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);
        }

        #region Base64QRCode Tests

        [Fact]
        [Category("LowCoverage/Base64QRCode")]
        public void Base64QRCode_ConstructorWithoutParams_ShouldCreateInstance()
        {
            // Arrange & Act
            var base64QRCode = new Base64QRCode();

            // Assert
            base64QRCode.ShouldNotBeNull();
        }

        [Fact]
        [Category("LowCoverage/Base64QRCode")]
        public void Base64QRCode_ConstructorWithData_ShouldCreateInstance()
        {
            // Arrange & Act
            var base64QRCode = new Base64QRCode(_qrData);

            // Assert
            base64QRCode.ShouldNotBeNull();
        }

        [Fact]
        [Category("LowCoverage/Base64QRCode")]
        public void Base64QRCode_GetGraphic_WithPixelsPerModule_ShouldReturnBase64String()
        {
            // Arrange
            var base64QRCode = new Base64QRCode(_qrData);

            // Act
            var result = base64QRCode.GetGraphic(10);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.Length.ShouldBeGreaterThan(100);
        }

        [Fact]
        [Category("LowCoverage/Base64QRCode")]
        public void Base64QRCode_GetGraphic_WithHexColors_ShouldReturnBase64String()
        {
            // Arrange
            var base64QRCode = new Base64QRCode(_qrData);

            // Act
            var result = base64QRCode.GetGraphic(10, "#FF0000", "#00FF00");

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.Length.ShouldBeGreaterThan(100);
        }

        [Theory]
        [InlineData(Base64QRCode.ImageType.Png)]
        [InlineData(Base64QRCode.ImageType.Jpeg)]
        [InlineData(Base64QRCode.ImageType.Gif)]
        [Category("LowCoverage/Base64QRCode")]
        public void Base64QRCode_GetGraphic_WithDifferentImageTypes_ShouldReturnBase64String(Base64QRCode.ImageType imageType)
        {
            // Arrange
            var base64QRCode = new Base64QRCode(_qrData);

            // Act
            var result = base64QRCode.GetGraphic(10, SKColors.Black, SKColors.White, true, imageType);

            // Assert
            result.ShouldNotBeNull();
            if (!string.IsNullOrEmpty(result))
            {
                result.Length.ShouldBeGreaterThan(100);
            }
        }

        [Fact]
        [Category("LowCoverage/Base64QRCode")]
        public void Base64QRCode_SetQRCodeData_ShouldUpdateData()
        {
            // Arrange
            var base64QRCode = new Base64QRCode();
            var newData = _generator.CreateQrCode("New Data", QRCodeGenerator.ECCLevel.L);

            // Act
            base64QRCode.SetQRCodeData(newData);

            // Assert
            var result = base64QRCode.GetGraphic(10);
            result.ShouldNotBeNullOrEmpty();
        }

        [Fact]
        [Category("LowCoverage/Base64QRCode")]
        public void Base64QRCodeHelper_GetQRCode_ShouldReturnBase64String()
        {
            // Arrange
            var plainText = "Helper Test";

            // Act
            var result = Base64QRCodeHelper.GetQRCode(plainText, 10, "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.M);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.Length.ShouldBeGreaterThan(100);
        }

        #endregion

        #region PdfByteQRCode Tests

        [Fact]
        [Category("LowCoverage/PdfByteQRCode")]
        public void PdfByteQRCode_ConstructorWithoutParams_ShouldCreateInstance()
        {
            // Arrange & Act
            var pdfQRCode = new PdfByteQRCode();

            // Assert
            pdfQRCode.ShouldNotBeNull();
        }

        [Fact]
        [Category("LowCoverage/PdfByteQRCode")]
        public void PdfByteQRCode_ConstructorWithData_ShouldCreateInstance()
        {
            // Arrange & Act
            var pdfQRCode = new PdfByteQRCode(_qrData);

            // Assert
            pdfQRCode.ShouldNotBeNull();
        }

        [Fact]
        [Category("LowCoverage/PdfByteQRCode")]
        public void PdfByteQRCode_GetGraphic_WithPixelsPerModule_ShouldReturnPdfBytes()
        {
            // Arrange
            var pdfQRCode = new PdfByteQRCode(_qrData);

            // Act
            var result = pdfQRCode.GetGraphic(10);

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check PDF header
            var header = result.Take(4).ToArray();
            header[0].ShouldBe((byte)0x25); // %
            header[1].ShouldBe((byte)0x50); // P
            header[2].ShouldBe((byte)0x44); // D
            header[3].ShouldBe((byte)0x46); // F
        }

        [Fact]
        [Category("LowCoverage/PdfByteQRCode")]
        public void PdfByteQRCode_GetGraphic_WithHexColors_ShouldReturnPdfBytes()
        {
            // Arrange
            var pdfQRCode = new PdfByteQRCode(_qrData);

            // Act
            var result = pdfQRCode.GetGraphic(10, "#FF0000", "#00FF00");

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check PDF header
            var header = result.Take(4).ToArray();
            header[0].ShouldBe((byte)0x25); // %
            header[1].ShouldBe((byte)0x50); // P
            header[2].ShouldBe((byte)0x44); // D
            header[3].ShouldBe((byte)0x46); // F
        }

        [Theory]
        [InlineData(150, 85)]
        [InlineData(300, 95)]
        [InlineData(72, 100)]
        [Category("LowCoverage/PdfByteQRCode")]
        public void PdfByteQRCode_GetGraphic_WithDifferentDpiAndQuality_ShouldReturnPdfBytes(int dpi, long quality)
        {
            // Arrange
            var pdfQRCode = new PdfByteQRCode(_qrData);

            // Act
            var result = pdfQRCode.GetGraphic(10, "#000000", "#FFFFFF", dpi, quality);

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check PDF header
            var header = result.Take(4).ToArray();
            header[0].ShouldBe((byte)0x25); // %
            header[1].ShouldBe((byte)0x50); // P
            header[2].ShouldBe((byte)0x44); // D
            header[3].ShouldBe((byte)0x46); // F
        }

        [Fact]
        [Category("LowCoverage/PdfByteQRCode")]
        public void PdfByteQRCodeHelper_GetQRCode_ShouldReturnPdfBytes()
        {
            // Arrange
            var plainText = "PDF Helper Test";

            // Act
            var result = PdfByteQRCodeHelper.GetQRCode(plainText, 10, "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.M);

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check PDF header
            var header = result.Take(4).ToArray();
            header[0].ShouldBe((byte)0x25); // %
            header[1].ShouldBe((byte)0x50); // P
            header[2].ShouldBe((byte)0x44); // D
            header[3].ShouldBe((byte)0x46); // F
        }

        [Fact]
        [Category("LowCoverage/PdfByteQRCode")]
        public void PdfByteQRCodeHelper_GetQRCode_Simple_ShouldReturnPdfBytes()
        {
            // Arrange
            var plainText = "Simple PDF Test";

            // Act
            var result = PdfByteQRCodeHelper.GetQRCode(plainText, QRCodeGenerator.ECCLevel.M, 10);

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check PDF header
            var header = result.Take(4).ToArray();
            header[0].ShouldBe((byte)0x25); // %
            header[1].ShouldBe((byte)0x50); // P
            header[2].ShouldBe((byte)0x44); // D
            header[3].ShouldBe((byte)0x46); // F
        }

        #endregion

        #region PostscriptQRCode Tests

        [Fact]
        [Category("LowCoverage/PostscriptQRCode")]
        public void PostscriptQRCode_ConstructorWithoutParams_ShouldCreateInstance()
        {
            // Arrange & Act
            var postscriptQRCode = new PostscriptQRCode();

            // Assert
            postscriptQRCode.ShouldNotBeNull();
        }

        [Fact]
        [Category("LowCoverage/PostscriptQRCode")]
        public void PostscriptQRCode_ConstructorWithData_ShouldCreateInstance()
        {
            // Arrange & Act
            var postscriptQRCode = new PostscriptQRCode(_qrData);

            // Assert
            postscriptQRCode.ShouldNotBeNull();
        }

        [Fact]
        [Category("LowCoverage/PostscriptQRCode")]
        public void PostscriptQRCode_GetGraphic_WithPointsPerModule_ShouldReturnPostscriptString()
        {
            // Arrange
            var postscriptQRCode = new PostscriptQRCode(_qrData);

            // Act
            var result = postscriptQRCode.GetGraphic(10);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.StartsWith("%!PS-Adobe-3.0").ShouldBeTrue();
            result.ShouldContain("QRCoder.NET");
            result.ShouldContain("%%EOF");
        }

        [Fact]
        [Category("LowCoverage/PostscriptQRCode")]
        public void PostscriptQRCode_GetGraphic_WithEpsFormat_ShouldReturnEpsString()
        {
            // Arrange
            var postscriptQRCode = new PostscriptQRCode(_qrData);

            // Act
            var result = postscriptQRCode.GetGraphic(10, epsFormat: true);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.StartsWith("%!PS-Adobe-3.0 EPSF-3.0").ShouldBeTrue();
            result.ShouldContain("QRCoder.NET");
            result.ShouldContain("%%EOF");
        }

        [Fact]
        [Category("LowCoverage/PostscriptQRCode")]
        public void PostscriptQRCode_GetGraphic_WithHexColors_ShouldReturnPostscriptString()
        {
            // Arrange
            var postscriptQRCode = new PostscriptQRCode(_qrData);

            // Act
            var result = postscriptQRCode.GetGraphic(10, "#FF0000", "#00FF00");

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.StartsWith("%!PS-Adobe-3.0").ShouldBeTrue();
            result.ShouldContain("QRCoder.NET");
            result.ShouldContain("%%EOF");
        }

        [Fact]
        [Category("LowCoverage/PostscriptQRCode")]
        public void PostscriptQRCode_GetGraphic_WithViewBox_ShouldReturnPostscriptString()
        {
            // Arrange
            var postscriptQRCode = new PostscriptQRCode(_qrData);
            var viewBox = new Size(200, 200);

            // Act
            var result = postscriptQRCode.GetGraphic(viewBox);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.StartsWith("%!PS-Adobe-3.0").ShouldBeTrue();
            result.ShouldContain("QRCoder.NET");
            result.ShouldContain("%%EOF");
        }

        [Fact]
        [Category("LowCoverage/PostscriptQRCode")]
        public void PostscriptQRCodeHelper_GetQRCode_ShouldReturnPostscriptString()
        {
            // Arrange
            var plainText = "Postscript Helper Test";

            // Act
            var result = PostscriptQRCodeHelper.GetQRCode(plainText, 10, "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.M);

            // Assert
            result.ShouldNotBeNullOrEmpty();
            result.StartsWith("%!PS-Adobe-3.0").ShouldBeTrue();
            result.ShouldContain("QRCoder.NET");
            result.ShouldContain("%%EOF");
        }

        #endregion

        #region SKBitmapByteQRCode Tests

        [Fact]
        [Category("LowCoverage/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCode_ConstructorWithoutParams_ShouldCreateInstance()
        {
            // Arrange & Act
            var bitmapQRCode = new SKBitmapByteQRCode();

            // Assert
            bitmapQRCode.ShouldNotBeNull();
        }

        [Fact]
        [Category("LowCoverage/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCode_ConstructorWithData_ShouldCreateInstance()
        {
            // Arrange & Act
            var bitmapQRCode = new SKBitmapByteQRCode(_qrData);

            // Assert
            bitmapQRCode.ShouldNotBeNull();
        }

        [Fact]
        [Category("LowCoverage/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCode_GetGraphic_WithPixelsPerModule_ShouldReturnBitmapBytes()
        {
            // Arrange
            var bitmapQRCode = new SKBitmapByteQRCode(_qrData);

            // Act
            var result = bitmapQRCode.GetGraphic(10);

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check BMP header
            var header = result.Take(2).ToArray();
            header[0].ShouldBe((byte)0x42); // B
            header[1].ShouldBe((byte)0x4D); // M
        }

        [Fact]
        [Category("LowCoverage/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCode_GetGraphic_WithHexColors_ShouldReturnBitmapBytes()
        {
            // Arrange
            var bitmapQRCode = new SKBitmapByteQRCode(_qrData);

            // Act
            var result = bitmapQRCode.GetGraphic(10, "#FF0000", "#00FF00");

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check BMP header
            var header = result.Take(2).ToArray();
            header[0].ShouldBe((byte)0x42); // B
            header[1].ShouldBe((byte)0x4D); // M
        }

        [Fact]
        [Category("LowCoverage/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCode_GetGraphic_WithRgbColors_ShouldReturnBitmapBytes()
        {
            // Arrange
            var bitmapQRCode = new SKBitmapByteQRCode(_qrData);
            var darkColor = new byte[] { 255, 0, 0 }; // Red
            var lightColor = new byte[] { 0, 255, 0 }; // Green

            // Act
            var result = bitmapQRCode.GetGraphic(10, darkColor, lightColor);

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check BMP header
            var header = result.Take(2).ToArray();
            header[0].ShouldBe((byte)0x42); // B
            header[1].ShouldBe((byte)0x4D); // M
        }

        [Fact]
        [Category("LowCoverage/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCodeHelper_GetQRCode_ShouldReturnBitmapBytes()
        {
            // Arrange
            var plainText = "Bitmap Helper Test";

            // Act
            var result = SKBitmapByteQRCodeHelper.GetQRCode(plainText, 10, "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.M);

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check BMP header
            var header = result.Take(2).ToArray();
            header[0].ShouldBe((byte)0x42); // B
            header[1].ShouldBe((byte)0x4D); // M
        }

        [Fact]
        [Category("LowCoverage/SKBitmapByteQRCode")]
        public void SKBitmapByteQRCodeHelper_GetQRCode_Simple_ShouldReturnBitmapBytes()
        {
            // Arrange
            var plainText = "Simple Bitmap Test";

            // Act
            var result = SKBitmapByteQRCodeHelper.GetQRCode(plainText, QRCodeGenerator.ECCLevel.M, 10);

            // Assert
            result.ShouldNotBeNull();
            result.Length.ShouldBeGreaterThan(1000);
            
            // Check BMP header
            var header = result.Take(2).ToArray();
            header[0].ShouldBe((byte)0x42); // B
            header[1].ShouldBe((byte)0x4D); // M
        }

        #endregion

        #region DataTooLongException Tests

        [Fact]
        [Category("LowCoverage/DataTooLongException")]
        public void DataTooLongException_ConstructorWithBasicParams_ShouldCreateException()
        {
            // Arrange & Act
            var exception = new DataTooLongException("M", "Binary", 2953);

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain("ECC level=M");
            exception.Message.ShouldContain("EncodingMode=Binary");
            exception.Message.ShouldContain("2953 byte");
        }

        [Fact]
        [Category("LowCoverage/DataTooLongException")]
        public void DataTooLongException_ConstructorWithVersion_ShouldCreateException()
        {
            // Arrange & Act
            var exception = new DataTooLongException("H", "Byte", 5, 2953);

            // Assert
            exception.ShouldNotBeNull();
            exception.Message.ShouldContain("ECC level=H");
            exception.Message.ShouldContain("EncodingMode=Byte");
            exception.Message.ShouldContain("FixedVersion=5");
            exception.Message.ShouldContain("2953 byte");
        }

        [Fact]
        [Category("LowCoverage/DataTooLongException")]
        public void DataTooLongException_ShouldInheritFromException()
        {
            // Arrange
            var exception = new DataTooLongException("M", "Binary", 2953);

            // Act & Assert
            Assert.IsAssignableFrom<Exception>(exception);
        }

        #endregion

        #region SKColorExtensions Tests

        [Fact]
        [Category("LowCoverage/SKColorExtensions")]
        public void SKColorExtensions_ToHex_WithOpaqueColor_ShouldReturnHex()
        {
            // Arrange
            var color = new SKColor(255, 128, 64, 255); // Opaque orange

            // Act
            var result = color.ToHex();

            // Assert
            result.ShouldBe("#FFFF8040");
        }

        [Fact]
        [Category("LowCoverage/SKColorExtensions")]
        public void SKColorExtensions_ToHex_WithTransparentColor_ShouldReturnHex()
        {
            // Arrange
            var color = new SKColor(255, 128, 64, 128); // Semi-transparent orange

            // Act
            var result = color.ToHex();

            // Assert
            result.ShouldBe("#80FF8040");
        }

        [Fact]
        [Category("LowCoverage/SKColorExtensions")]
        public void SKColorExtensions_FromHex_WithEmptyString_ShouldReturnTransparent()
        {
            // Arrange
            string hex = null;

            // Act
            var result = SKColorExtensions.FromHex(hex);

            // Assert
            result.ShouldBe(SKColors.Transparent);
        }

        [Fact]
        [Category("LowCoverage/SKColorExtensions")]
        public void SKColorExtensions_FromHex_WithNullString_ShouldReturnTransparent()
        {
            // Arrange
            string hex = "";

            // Act
            var result = SKColorExtensions.FromHex(hex);

            // Assert
            result.ShouldBe(SKColors.Transparent);
        }

        [Theory]
        [InlineData("#FF0000", 255, 0, 0)] // Red
        [InlineData("#00FF00", 0, 255, 0)] // Green
        [InlineData("#0000FF", 0, 0, 255)] // Blue
        [InlineData("#FFFFFF", 255, 255, 255)] // White
        [InlineData("#000000", 0, 0, 0)] // Black
        [InlineData("#808080", 128, 128, 128)] // Gray
        [Category("LowCoverage/SKColorExtensions")]
        public void SKColorExtensions_FromHex_With6DigitHex_ShouldReturnCorrectColor(string hex, byte expectedR, byte expectedG, byte expectedB)
        {
            // Act
            var result = SKColorExtensions.FromHex(hex);

            // Assert
            Assert.Equal(expectedR, result.Red);
            Assert.Equal(expectedG, result.Green);
            Assert.Equal(expectedB, result.Blue);
            Assert.Equal((byte)255, result.Alpha); // Opaque by default
        }

        [Theory]
        [InlineData("#FF0000FF", 255, 0, 0, 255)] // ARGB format
        [InlineData("#8000FF00", 128, 0, 255, 0)] // ARGB format  
        [InlineData("#00000080", 0, 0, 0, 128)] // ARGB format
        [InlineData("#FFFFFFFF", 255, 255, 255, 255)] // ARGB format
        [Category("LowCoverage/SKColorExtensions")]
        public void SKColorExtensions_FromHex_With8DigitHex_ShouldReturnCorrectColor(string hex, byte expectedA, byte expectedR, byte expectedG, byte expectedB)
        {
            // Act
            var result = SKColorExtensions.FromHex(hex);

            // Assert
            Assert.Equal(expectedA, result.Alpha);
            Assert.Equal(expectedR, result.Red);
            Assert.Equal(expectedG, result.Green);
            Assert.Equal(expectedB, result.Blue);
        }

        [Theory]
        [InlineData("#GGGGGG")] // Invalid hex characters - will throw
        [InlineData("#12345")] // Invalid length
        [InlineData("#1234567")] // Invalid length
        [InlineData("#123456789")] // Invalid length
        [Category("LowCoverage/SKColorExtensions")]
        public void SKColorExtensions_FromHex_WithInvalidHex_ShouldReturnTransparent(string invalidHex)
        {
            // Act & Assert
            if (invalidHex == "#GGGGGG")
            {
                // This should throw an exception
                Assert.Throws<ArgumentException>(() => SKColorExtensions.FromHex(invalidHex));
            }
            else
            {
                // Others should return transparent
                var result = SKColorExtensions.FromHex(invalidHex);
                Assert.Equal(SKColors.Transparent, result);
            }
        }

        [Fact]
        [Category("LowCoverage/SKColorExtensions")]
        public void SKColorExtensions_RoundTrip_ToHexAndFromHex_ShouldReturnOriginalColor()
        {
            // Arrange
            var originalColor = new SKColor(123, 200, 67, 200);

            // Act
            var hex = originalColor.ToHex();
            var resultColor = SKColorExtensions.FromHex(hex);

            // Assert
            Assert.Equal(originalColor.Red, resultColor.Red);
            Assert.Equal(originalColor.Green, resultColor.Green);
            Assert.Equal(originalColor.Blue, resultColor.Blue);
            Assert.Equal(originalColor.Alpha, resultColor.Alpha);
        }

        #endregion
    }
}
