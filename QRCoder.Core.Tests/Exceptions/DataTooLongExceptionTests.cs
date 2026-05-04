using QRCoder.Core.Exceptions;
using QRCoder.Core.Generators;
using Shouldly;
using Xunit;

namespace QRCoder.Core.Tests.Exceptions
{
    public class DataTooLongExceptionTests
    {
        [Fact]
        public void constructor_without_version_formats_message()
        {
            var ex = new DataTooLongException("H", "Byte", 100);
            ex.Message.ShouldContain("ECC level=H");
            ex.Message.ShouldContain("EncodingMode=Byte");
            ex.Message.ShouldContain("100 byte");
        }

        [Fact]
        public void constructor_with_version_formats_message()
        {
            var ex = new DataTooLongException("Q", "Alphanumeric", 5, 200);
            ex.Message.ShouldContain("ECC level=Q");
            ex.Message.ShouldContain("EncodingMode=Alphanumeric");
            ex.Message.ShouldContain("FixedVersion=5");
            ex.Message.ShouldContain("200 byte");
        }

        [Fact]
        public void data_too_long_is_thrown_for_oversized_payload()
        {
            var longText = new string('A', 10000);
            using var gen = new QRCodeGenerator();
            Should.Throw<DataTooLongException>(() =>
                gen.CreateQrCode(longText, QRCodeGenerator.ECCLevel.H));
        }

        [Fact]
        public void data_too_long_with_fixed_version()
        {
            var text = new string('A', 500);
            Should.Throw<DataTooLongException>(() =>
                QRCodeGenerator.GenerateQrCode(text, QRCodeGenerator.ECCLevel.H, requestedVersion: 1));
        }
    }
}
