using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using QRCoder.Core.Tests.Helpers;
using QRCoder.Core.Tests.Helpers.XUnitExtenstions;
using Shouldly;
using SkiaSharp;
using Xunit;

namespace QRCoder.Core.Tests
{
    public class BDDTests
    {
        [Fact]
        [Category("BDD/Geracao")]
        public void DadoUmTextoSimples_QuandoGerarQRCode_EntaoDeveSerPossivelCriarDadosValidos()
        {
            // Dado
            var texto = "https://github.com/afonsoft/QRCoder.Core";
            var gerador = new QRCodeGenerator();

            // Quando
            var dados = gerador.CreateQrCode(texto, QRCodeGenerator.ECCLevel.M);

            // Entao
            dados.ShouldNotBeNull();
            dados.ModuleMatrix.ShouldNotBeEmpty();
            dados.ModuleMatrix.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BDD/Renderizacao")]
        public void DadoDadosDeQRCode_QuandoRenderizarPng_EntaoDeveGerarBytesNaoVazios()
        {
            // Dado
            var gerador = new QRCodeGenerator();
            var dados = gerador.CreateQrCode("BDD QR Code", QRCodeGenerator.ECCLevel.L);

            // Quando
            var png = new PngByteQRCode(dados);
            var bytes = png.GetGraphic(5);

            // Entao
            bytes.ShouldNotBeNull();
            bytes.Length.ShouldBeGreaterThan(0);
        }

        [Fact]
        [Category("BDD/Renderizacao")]
        public void DadoDadosDeQRCode_QuandoRenderizarSvg_EntaoDeveGerarStringNaoVazia()
        {
            // Dado
            var gerador = new QRCodeGenerator();
            var dados = gerador.CreateQrCode("BDD SVG QR Code", QRCodeGenerator.ECCLevel.Q);

            // Quando
            var svg = new SvgQRCode(dados);
            var conteudo = svg.GetGraphic(10);

            // Entao
            conteudo.ShouldNotBeNullOrWhiteSpace();
            conteudo.ShouldContain("<svg");
        }

        [Fact]
        [Category("BDD/Cores")]
        public void DadoCoresCustomizadas_QuandoRenderizarBitmap_EntaoAsDimensoesDevemSerCorretas()
        {
            // Dado
            var gerador = new QRCodeGenerator();
            var dados = gerador.CreateQrCode("Cores", QRCodeGenerator.ECCLevel.H);
            var pixelsPorModulo = 10;

            // Quando
            var qrCode = new QRCode(dados);
            using (var bitmap = qrCode.GetGraphic(pixelsPorModulo, SKColors.Red, SKColors.White, true))
            {
                // Entao
                bitmap.ShouldNotBeNull();
                bitmap.Width.ShouldBeGreaterThan(0);
                bitmap.Height.ShouldBeGreaterThan(0);
            }
        }
    }
}
