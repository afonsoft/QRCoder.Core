using System;
using Shouldly;
using Xunit;
using QRCoder.Core.Generators;

namespace QRCoder.Core.Tests.Generators
{
    /// <summary>
    /// Testes BDD para os payloads do PayloadGenerator
    /// </summary>
    public class PayloadGeneratorBddTests
    {
        /// <summary>
        /// Testes para OneTimePassword
        /// </summary>
        public class OneTimePasswordTests
        {
            /// <summary>
            /// Dado um OneTimePassword TOTP com secret
            /// Quando gerar a string
            /// Então deve retornar URI otpauth para TOTP
            /// </summary>
            [Fact]
            public void Dado_TOTPComSecret_Quando_GerarString_Entao_RetornaUriOtpauthTotp()
            {
                // Arrange
                var otp = new PayloadGenerator.OneTimePassword
                {
                    Secret = "JBSWY3DPEHPK3PXP",
                    Label = "user@example.com",
                    Issuer = "Example"
                };

                // Act
                var result = otp.ToString();

                // Assert
                result.ShouldStartWith("otpauth://totp/");
                result.ShouldContain("secret=JBSWY3DPEHPK3PXP");
                result.ShouldContain("issuer=Example");
                result.ShouldContain("Example:user@example.com");
            }

            /// <summary>
            /// Dado um OneTimePassword HOTP com secret e counter
            /// Quando gerar a string
            /// Então deve retornar URI otpauth para HOTP com counter
            /// </summary>
            [Fact]
            public void Dado_HOTPComSecret_Quando_GerarString_Entao_RetornaUriOtpauthHotpComCounter()
            {
                // Arrange
                var otp = new PayloadGenerator.OneTimePassword
                {
                    Type = PayloadGenerator.OneTimePassword.OneTimePasswordAuthType.HOTP,
                    Secret = "JBSWY3DPEHPK3PXP",
                    Counter = 42,
                    Issuer = "Example"
                };

                // Act
                var result = otp.ToString();

                // Assert
                result.ShouldStartWith("otpauth://hotp/");
                result.ShouldContain("secret=JBSWY3DPEHPK3PXP");
                result.ShouldContain("counter=42");
            }

            /// <summary>
            /// Dado um OneTimePassword TOTP com period diferente do padrao
            /// Quando gerar a string
            /// Então deve incluir o period na URI
            /// </summary>
            [Fact]
            public void Dado_TOTPComPeriodDiferente_Quando_GerarString_Entao_IncluiPeriod()
            {
                // Arrange
                var otp = new PayloadGenerator.OneTimePassword
                {
                    Secret = "JBSWY3DPEHPK3PXP",
                    Period = 60
                };

                // Act
                var result = otp.ToString();

                // Assert
                result.ShouldContain("period=60");
            }

            /// <summary>
            /// Dado um OneTimePassword com digits diferente de 6
            /// Quando gerar a string
            /// Então deve incluir os digits na URI
            /// </summary>
            [Fact]
            public void Dado_DigitsDiferente_Quando_GerarString_Entao_IncluiDigits()
            {
                // Arrange
                var otp = new PayloadGenerator.OneTimePassword
                {
                    Secret = "JBSWY3DPEHPK3PXP",
                    Digits = 8
                };

                // Act
                var result = otp.ToString();

                // Assert
                result.ShouldContain("digits=8");
            }

            /// <summary>
            /// Dado um OneTimePassword sem secret
            /// Quando gerar a string
            /// Então deve lancar excecao
            /// </summary>
            [Fact]
            public void Dado_SemSecret_Quando_GerarString_Entao_LancaExcecao()
            {
                // Arrange
                var otp = new PayloadGenerator.OneTimePassword();

                // Act & Assert
                Should.Throw<Exception>(() => otp.ToString());
            }
        }

        /// <summary>
        /// Testes para Geolocation
        /// </summary>
        public class GeolocationTests
        {
            /// <summary>
            /// Dado uma localizacao com encoding GEO
            /// Quando gerar a string
            /// Então deve retornar URI geo
            /// </summary>
            [Fact]
            public void Dado_LocalizacaoGeo_Quando_GerarString_Entao_RetornaUriGeo()
            {
                // Arrange
                var geo = new PayloadGenerator.Geolocation("45.123", "9.456");

                // Act
                var result = geo.ToString();

                // Assert
                result.ShouldBe("geo:45.123,9.456");
            }

            /// <summary>
            /// Dado uma localizacao com encoding GoogleMaps
            /// Quando gerar a string
            /// Então deve retornar link do Google Maps
            /// </summary>
            [Fact]
            public void Dado_LocalizacaoGoogleMaps_Quando_GerarString_Entao_RetornaLinkGoogleMaps()
            {
                // Arrange
                var geo = new PayloadGenerator.Geolocation("45.123", "9.456", PayloadGenerator.Geolocation.GeolocationEncoding.GoogleMaps);

                // Act
                var result = geo.ToString();

                // Assert
                result.ShouldBe("https://maps.google.com/maps?q=45.123,9.456");
            }

            /// <summary>
            /// Dado uma localizacao com virgula nas coordenadas
            /// Quando gerar a string
            /// Então deve substituir por ponto
            /// </summary>
            [Fact]
            public void Dado_CoordenadasComVirgula_Quando_GerarString_Entao_SubstituirPorPonto()
            {
                // Arrange
                var geo = new PayloadGenerator.Geolocation("45,123", "9,456");

                // Act
                var result = geo.ToString();

                // Assert
                result.ShouldBe("geo:45.123,9.456");
            }
        }

        /// <summary>
        /// Testes para SlovenianUpnQr
        /// </summary>
        public class SlovenianUpnQrTests
        {
            /// <summary>
            /// Dado um SlovenianUpnQr valido
            /// Quando gerar a string
            /// Então deve iniciar com UPNQR e conter os campos
            /// </summary>
            [Fact]
            public void Dado_UPNQRValido_Quando_GerarString_Entao_IniciaComUPNQRComCampos()
            {
                // Arrange
                var upn = new PayloadGenerator.SlovenianUpnQr(
                    "A", "B", "C", "D", "E", "F", "IBAN", "Desc", 1.23
                );

                // Act
                var result = upn.ToString();

                // Assert
                result.ShouldStartWith("UPNQR");
                result.ShouldContain("A");
                result.ShouldContain("B");
                result.ShouldContain("C");
                result.ShouldContain("D");
                result.ShouldContain("E");
                result.ShouldContain("F");
                result.ShouldContain("IBAN");
                result.ShouldContain("DESC");
                result.ShouldContain("00000000123");
            }

            /// <summary>
            /// Dado um SlovenianUpnQr com data de vencimento
            /// Quando gerar a string
            /// Então deve incluir a data formatada
            /// </summary>
            [Fact]
            public void Dado_UPNQRComDataVencimento_Quando_GerarString_Entao_IncluiDataFormatada()
            {
                // Arrange
                var deadline = new DateTime(2025, 12, 31);
                var upn = new PayloadGenerator.SlovenianUpnQr(
                    "A", "B", "C", "D", "E", "F", "IBAN", "Desc", 1.23, deadline
                );

                // Act
                var result = upn.ToString();

                // Assert
                result.ShouldContain("31.12.2025");
            }

            /// <summary>
            /// Dado um SlovenianUpnQr com valores padrao
            /// Quando gerar a string
            /// Então deve calcular o checksum corretamente
            /// </summary>
            [Fact]
            public void Dado_UPNQRComValoresPadrao_Quando_GerarString_Entao_CalculaChecksumCorretamente()
            {
                // Arrange
                var upn = new PayloadGenerator.SlovenianUpnQr(
                    "A", "B", "C", "D", "E", "F", "I", "D", 1.23
                );

                // Act
                var result = upn.ToString();

                // Assert
                // checksum = 5 + 1 + 1 + 1 + 11 + 4 + 1 + 0 + 1 + 1 + 1 + 1 + 4 + 0 + 19 = 51
                result.ShouldContain("051");
            }

            /// <summary>
            /// Dado um SlovenianUpnQr
            /// Quando acessar as propriedades de configuracao
            /// Então deve retornar os valores esperados
            /// </summary>
            [Fact]
            public void Dado_UPNQR_Quando_AcessarPropriedades_Entao_RetornaValoresEsperados()
            {
                // Arrange & Act
                var upn = new PayloadGenerator.SlovenianUpnQr(
                    "A", "B", "C", "D", "E", "F", "IBAN", "Desc", 1.23
                );

                // Assert
                upn.Version.ShouldBe(15);
                upn.EccLevel.ShouldBe(QRCodeGenerator.ECCLevel.M);
                upn.EciMode.ShouldBe(QRCodeGenerator.EciMode.Iso8859_2);
            }
        }

        /// <summary>
        /// Testes para SwissQrCode.Contact
        /// </summary>
        public class SwissQrCodeContactTests
        {
            /// <summary>
            /// Dado um contato com endereco estruturado
            /// Quando gerar a string
            /// Então deve iniciar com S e conter os dados
            /// </summary>
            [Fact]
            public void Dado_ContatoEnderecoEstruturado_Quando_GerarString_Entao_IniciaComS()
            {
                // Arrange
                var contact = PayloadGenerator.SwissQrCode.Contact.WithStructuredAddress(
                    "Empresa", "12345", "Cidade", "BR", "Rua", "42"
                );

                // Act
                var result = contact.ToString();

                // Assert
                result.ShouldStartWith("S");
                result.ShouldContain("Empresa");
                result.ShouldContain("Rua");
                result.ShouldContain("42");
                result.ShouldContain("12345");
                result.ShouldContain("Cidade");
                result.ShouldContain("BR");
            }

            /// <summary>
            /// Dado um contato com endereco combinado
            /// Quando gerar a string
            /// Então deve iniciar com K e conter os dados
            /// </summary>
            [Fact]
            public void Dado_ContatoEnderecoCombinado_Quando_GerarString_Entao_IniciaComK()
            {
                // Arrange
                var contact = PayloadGenerator.SwissQrCode.Contact.WithCombinedAddress(
                    "Empresa", "BR", "Linha 1", "Linha 2"
                );

                // Act
                var result = contact.ToString();

                // Assert
                result.ShouldStartWith("K");
                result.ShouldContain("Empresa");
                result.ShouldContain("Linha 1");
                result.ShouldContain("Linha 2");
                result.ShouldContain("BR");
            }

            /// <summary>
            /// Dado um contato combinado sem a segunda linha de endereco
            /// Quando criar
            /// Então deve lancar excecao
            /// </summary>
            [Fact]
            public void Dado_ContatoCombinadoSemLinha2_Quando_Criar_Entao_LancaExcecao()
            {
                // Act & Assert
                Should.Throw<PayloadGenerator.SwissQrCode.Contact.SwissQrCodeContactException>(
                    () => PayloadGenerator.SwissQrCode.Contact.WithCombinedAddress("Empresa", "BR", "Linha 1", null)
                );
            }
        }

        /// <summary>
        /// Testes para ContactData
        /// </summary>
        public class ContactDataTests
        {
            /// <summary>
            /// Dado um ContactData vCard 3.0
            /// Quando gerar a string
            /// Então deve retornar um vCard completo
            /// </summary>
            [Fact]
            public void Dado_ContatoVCard3_Quando_GerarString_Entao_RetornaVCardCompleto()
            {
                // Arrange
                var contact = new PayloadGenerator.ContactData(
                    PayloadGenerator.ContactData.ContactOutputType.VCard3,
                    "Joao",
                    "Silva",
                    phone: "+5511999999999",
                    email: "joao@exemplo.com",
                    street: "Rua",
                    houseNumber: "42",
                    city: "Cidade",
                    zipCode: "12345",
                    country: "BR"
                );

                // Act
                var result = contact.ToString();

                // Assert
                result.ShouldContain("BEGIN:VCARD");
                result.ShouldContain("VERSION:3.0");
                result.ShouldContain("N:Silva;Joao;;;");
                result.ShouldContain("FN:Joao Silva");
                result.ShouldContain("TEL;TYPE=HOME,VOICE:+5511999999999");
                result.ShouldContain("EMAIL:joao@exemplo.com");
                result.ShouldContain("ADR;TYPE=HOME,PREF:;;Rua 42;12345;Cidade;;BR");
                result.ShouldContain("END:VCARD");
            }

            /// <summary>
            /// Dado um ContactData MeCard
            /// Quando gerar a string
            /// Então deve retornar um MeCard
            /// </summary>
            [Fact]
            public void Dado_ContatoMeCard_Quando_GerarString_Entao_RetornaMeCard()
            {
                // Arrange
                var contact = new PayloadGenerator.ContactData(
                    PayloadGenerator.ContactData.ContactOutputType.MeCard,
                    "Joao",
                    "Silva",
                    phone: "+5511999999999",
                    email: "joao@exemplo.com"
                );

                // Act
                var result = contact.ToString();

                // Assert
                result.ShouldStartWith("MECARD+");
                result.ShouldContain("N:Silva, Joao");
                result.ShouldContain("TEL:+5511999999999");
                result.ShouldContain("EMAIL:joao@exemplo.com");
            }

            /// <summary>
            /// Dado um ContactData vCard 4.0 com ordem de endereco reversa
            /// Quando gerar a string
            /// Então deve formatar o endereco na ordem reversa
            /// </summary>
            [Fact]
            public void Dado_ContatoVCard4OrdemReversa_Quando_GerarString_Entao_FormataEnderecoReverso()
            {
                // Arrange
                var contact = new PayloadGenerator.ContactData(
                    PayloadGenerator.ContactData.ContactOutputType.VCard4,
                    "Joao",
                    "Silva",
                    street: "Rua",
                    houseNumber: "42",
                    city: "Cidade",
                    zipCode: "12345",
                    country: "BR",
                    addressOrder: PayloadGenerator.ContactData.AddressOrder.Reversed
                );

                // Act
                var result = contact.ToString();

                // Assert
                result.ShouldContain("ADR;TYPE=home,pref:;;42 Rua;Cidade;;12345;BR");
            }
        }
    }
}
