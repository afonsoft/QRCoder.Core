using System;
using QRCoder.Core.Generators;
using QRCoder.Core.Renderers;
using Shouldly;
using Xunit;

namespace QRCoder.Core.Tests.Renderers
{
    public class PdfByteQRCodeTests
    {
        [Fact]
        public void can_render_pdf_qrcode()
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode("PDF test", QRCodeGenerator.ECCLevel.M))
            using (var pdfQr = new PdfByteQRCode(data))
            {
                var pdf = pdfQr.GetGraphic(20);
                pdf.ShouldNotBeNull();
                pdf.Length.ShouldBeGreaterThan(0);
                // PDF files start with %PDF
                pdf[0].ShouldBe((byte)'%');
                pdf[1].ShouldBe((byte)'P');
                pdf[2].ShouldBe((byte)'D');
                pdf[3].ShouldBe((byte)'F');
            }
        }

        [Fact]
        public void pdf_with_custom_colors()
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode("Color PDF", QRCodeGenerator.ECCLevel.L))
            using (var pdfQr = new PdfByteQRCode(data))
            {
                var pdf = pdfQr.GetGraphic(10, "#000000", "#FFFFFF");
                pdf.ShouldNotBeNull();
                pdf.Length.ShouldBeGreaterThan(0);
            }
        }

        [Fact]
        public void pdf_helper_generates_output()
        {
            var pdf = PdfByteQRCodeHelper.GetQRCode("Helper test", QRCodeGenerator.ECCLevel.Q, 10);
            pdf.ShouldNotBeNull();
            pdf.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void can_instantiate_parameterless()
        {
            var pdfQr = new PdfByteQRCode();
            pdfQr.ShouldNotBeNull();
        }
    }
}
