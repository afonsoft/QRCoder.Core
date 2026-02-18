using System;
using Xunit;
using Shouldly;
using QRCoder.Core;
using QRCoder.Core.Exceptions;

namespace QRCoder.Core.Tests
{
    /// <summary>
    /// Testes para classes de renderização sem cobertura
    /// </summary>
    public class RendererCoverageTests
    {
        /// <summary>
        /// Testes para Base64QRCode
        /// </summary>
        public class Base64QRCodeTests
        {
            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando crio um Base64QRCode
            /// Então não deve lançar exceção
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_CriarBase64QRCode_Entao_NaoLancaExcecao()
            {
                // Arrange
                var gen = new QRCodeGenerator();
                var data = gen.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);

                // Act & Assert
                Should.NotThrow(() => new Base64QRCode(data));
            }

            /// <summary>
            /// Dado que tenho um Base64QRCode
            /// Quando chamo o construtor padrão
            /// Então deve criar instância válida
            /// </summary>
            [Fact]
            public void Dado_Base64QRCode_Quando_CriarComConstrutorPadrao_Entao_CriaInstanciaValida()
            {
                // Arrange & Act & Assert
                Should.NotThrow(() => new Base64QRCode());
            }

            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando gero o gráfico Base64
            /// Então deve retornar string não vazia
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_GerarGraficoBase64_Entao_RetornaStringNaoVazia()
            {
                // Arrange
                var gen = new QRCodeGenerator();
                var data = gen.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);
                var base64QR = new Base64QRCode(data);

                // Act
                var result = base64QR.GetGraphic(5);

                // Assert
                result.ShouldNotBeNull();
                result.Length.ShouldBeGreaterThan(0);
                result.ShouldStartWith("iVBORw0KGgoAAAANS"); // Base64 PNG header
            }

            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando gero o gráfico Base64 com cores
            /// Então deve retornar string não vazia
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_GerarGraficoBase64ComCores_Entao_RetornaStringNaoVazia()
            {
                // Arrange
                var gen = new QRCodeGenerator();
                var data = gen.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);
                var base64QR = new Base64QRCode(data);

                // Act
                var result = base64QR.GetGraphic(5, "#FF0000", "#00FF00");

                // Assert
                result.ShouldNotBeNull();
                result.Length.ShouldBeGreaterThan(0);
            }

            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando uso o helper Base64QRCode
            /// Então deve retornar string não vazia
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_UsarHelperBase64QRCode_Entao_RetornaStringNaoVazia()
            {
                // Arrange & Act
                var result = Base64QRCodeHelper.GetQRCode("Test Data", 5, "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.M);

                // Assert
                result.ShouldNotBeNull();
                result.Length.ShouldBeGreaterThan(0);
                result.ShouldStartWith("iVBORw0KGgoAAAANS"); // Base64 PNG header
            }
        }

        /// <summary>
        /// Testes para PdfByteQRCode
        /// </summary>
        public class PdfByteQRCodeTests
        {
            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando crio um PdfByteQRCode
            /// Então não deve lançar exceção
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_CriarPdfByteQRCode_Entao_NaoLancaExcecao()
            {
                // Arrange
                var gen = new QRCodeGenerator();
                var data = gen.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);

                // Act & Assert
                Should.NotThrow(() => new PdfByteQRCode(data));
            }

            /// <summary>
            /// Dado que tenho um PdfByteQRCode
            /// Quando chamo o construtor padrão
            /// Então deve criar instância válida
            /// </summary>
            [Fact]
            public void Dado_PdfByteQRCode_Quando_CriarComConstrutorPadrao_Entao_CriaInstanciaValida()
            {
                // Arrange & Act & Assert
                Should.NotThrow(() => new PdfByteQRCode());
            }

            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando gero o gráfico PDF
            /// Então deve retornar bytes não vazios
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_GerarGraficoPDF_Entao_RetornaBytesNaoVazios()
            {
                // Arrange
                var gen = new QRCodeGenerator();
                var data = gen.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);
                var pdfQR = new PdfByteQRCode(data);

                // Act
                var result = pdfQR.GetGraphic(5);

                // Assert
                result.ShouldNotBeNull();
                result.Length.ShouldBeGreaterThan(0);
            }

            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando gero o gráfico PDF com cores
            /// Então deve retornar bytes não vazios
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_GerarGraficoPDFComCores_Entao_RetornaBytesNaoVazios()
            {
                // Arrange
                var gen = new QRCodeGenerator();
                var data = gen.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);
                var pdfQR = new PdfByteQRCode(data);

                // Act
                var result = pdfQR.GetGraphic(5, "#FF0000", "#00FF00");

                // Assert
                result.ShouldNotBeNull();
                result.Length.ShouldBeGreaterThan(0);
            }
        }

        /// <summary>
        /// Testes para PostscriptQRCode
        /// </summary>
        public class PostscriptQRCodeTests
        {
            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando crio um PostscriptQRCode
            /// Então não deve lançar exceção
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_CriarPostscriptQRCode_Entao_NaoLancaExcecao()
            {
                // Arrange
                var gen = new QRCodeGenerator();
                var data = gen.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);

                // Act & Assert
                Should.NotThrow(() => new PostscriptQRCode(data));
            }

            /// <summary>
            /// Dado que tenho um PostscriptQRCode
            /// Quando chamo o construtor padrão
            /// Então deve criar instância válida
            /// </summary>
            [Fact]
            public void Dado_PostscriptQRCode_Quando_CriarComConstrutorPadrao_Entao_CriaInstanciaValida()
            {
                // Arrange & Act & Assert
                Should.NotThrow(() => new PostscriptQRCode());
            }

            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando gero o gráfico Postscript
            /// Então deve retornar string não vazia
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_GerarGraficoPostscript_Entao_RetornaStringNaoVazia()
            {
                // Arrange
                var gen = new QRCodeGenerator();
                var data = gen.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);
                var psQR = new PostscriptQRCode(data);

                // Act
                var result = psQR.GetGraphic(5);

                // Assert
                result.ShouldNotBeNull();
                result.Length.ShouldBeGreaterThan(0);
                result.ShouldContain("%!PS-Adobe");
            }
        }

        /// <summary>
        /// Testes para SKBitmapByteQRCode
        /// </summary>
        public class SKBitmapByteQRCodeTests
        {
            /// <summary>
            /// Dado que tenho dados válidos
            /// Quando crio um SKBitmapByteQRCode
            /// Então não deve lançar exceção
            /// </summary>
            [Fact]
            public void Dado_DadosValidos_Quando_CriarSKBitmapByteQRCode_Entao_NaoLancaExcecao()
            {
                // Arrange
                var gen = new QRCodeGenerator();
                var data = gen.CreateQrCode("Test Data", QRCodeGenerator.ECCLevel.M);

                // Act & Assert
                Should.NotThrow(() => new SKBitmapByteQRCode(data));
            }

            /// <summary>
            /// Dado que tenho um SKBitmapByteQRCode
            /// Quando chamo o construtor padrão
            /// Então deve criar instância válida
            /// </summary>
            [Fact]
            public void Dado_SKBitmapByteQRCode_Quando_CriarComConstrutorPadrao_Entao_CriaInstanciaValida()
            {
                // Arrange & Act & Assert
                Should.NotThrow(() => new SKBitmapByteQRCode());
            }
        }

        /// <summary>
        /// Testes para DataTooLongException
        /// </summary>
        public class DataTooLongExceptionTests
        {
            /// <summary>
            /// Dado que tenho uma mensagem de erro
            /// Quando crio uma DataTooLongException
            /// Então deve criar exceção com mensagem correta
            /// </summary>
            [Fact]
            public void Dado_MensagemErro_Quando_CriarDataTooLongException_Entao_CriaExcecaoComMensagemCorreta()
            {
                // Arrange
                var eccLevel = "H";
                var encodingMode = "UTF8";
                var maxSizeByte = 2953;

                // Act
                var exception = new DataTooLongException(eccLevel, encodingMode, maxSizeByte);

                // Assert
                exception.ShouldNotBeNull();
                exception.Message.ShouldContain("exceeds the maximum size");
                exception.Message.ShouldContain(eccLevel);
                exception.Message.ShouldContain(encodingMode);
                exception.Message.ShouldContain(maxSizeByte.ToString());
            }

            /// <summary>
            /// Dado que tenho parâmetros de versão
            /// Quando crio uma DataTooLongException com versão
            /// Então deve criar exceção com mensagem correta
            /// </summary>
            [Fact]
            public void Dado_ParametrosVersao_Quando_CriarDataTooLongException_Entao_CriaExcecaoComMensagemCorreta()
            {
                // Arrange
                var eccLevel = "H";
                var encodingMode = "UTF8";
                var version = 40;
                var maxSizeByte = 2953;

                // Act
                var exception = new DataTooLongException(eccLevel, encodingMode, version, maxSizeByte);

                // Assert
                exception.ShouldNotBeNull();
                exception.Message.ShouldContain("exceeds the maximum size");
                exception.Message.ShouldContain(eccLevel);
                exception.Message.ShouldContain(encodingMode);
                exception.Message.ShouldContain(version.ToString());
                exception.Message.ShouldContain(maxSizeByte.ToString());
            }
        }
    }
}
