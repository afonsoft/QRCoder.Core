# QRCoder.Core - Biblioteca Geradora de QR Code

[![Build status](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml)
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)
[![NuGet Badge](https://buildstats.info/nuget/QRCoder.Core?rnd=0892982314)](https://www.nuget.org/packages/QRCoder.Core/)
[![Code Quality](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)

> **[Read in English (en-US)](README.md)**

## Documentacao

- **[Guia de Uso (Portugues)](docs/pt-BR/guia-de-uso.md)** — PNG, SVG, PDF, ASCII, Base64, Postscript, QR Codes Artisticos
- **[Usage Guide (English)](docs/en-US/usage-guide.md)** — PNG, SVG, PDF, ASCII, Base64, Postscript, Artistic QR Codes

## Descricao do Projeto

QRCoder.Core e uma biblioteca .NET multiplataforma para geracao de QR Codes usando **SkiaSharp** para renderizacao de imagens. Compativel com **Windows**, **Linux**, **macOS** e **mobile** (Xamarin / MAUI).

Baseado em [QRCoder](https://github.com/codebude/QRCoder). Desenvolvido e mantido por [AFONSOFT](https://github.com/afonsoft).

### Formatos de Saida Suportados

| Formato | Classe | Descricao |
|---------|--------|-----------|
| **SKBitmap** | `QRCode` | Imagem bitmap SkiaSharp (multiplataforma) |
| **PNG** | `PngByteQRCode` | Array de bytes PNG (sem System.Drawing) |
| **SVG** | `SvgQRCode` | String de graficos vetoriais escalaveis |
| **PDF** | `PdfByteQRCode` | Documento PDF como array de bytes |
| **ASCII** | `ASCIIQRCode` | Arte ASCII para saida em terminal |
| **Base64** | `Base64QRCode` | String de imagem codificada em Base64 |
| **Postscript** | `PostscriptQRCode` | Formato Postscript/EPS |
| **Artistico** | `ArtQRCode` | QR personalizado com pontos arredondados e fundos |
| **BMP Bytes** | `BitmapByteQRCode` | Array de bytes Bitmap |

### Tipos de Payload Suportados

A classe `PayloadGenerator` fornece strings formatadas para casos de uso comuns de QR code:

| Payload | Descricao |
|---------|-----------|
| `Url` | URL de website |
| `WiFi` | Credenciais de rede Wi-Fi |
| `Mail` | Email com assunto e corpo |
| `SMS` | Mensagem SMS |
| `PhoneNumber` | Numero de telefone |
| `MMS` | Mensagem multimidia |
| `Geolocation` | Coordenadas GPS |
| `CalendarEvent` | Evento de calendario (iCal/vEvent) |
| `ContactData` | Contato vCard / MeCard |
| `BitcoinLikeCryptoCurrencyAddress` | Pagamento Bitcoin/cripto |
| `Girocode` | Pagamento SEPA europeu |
| `BezahlCode` | Padrao de pagamento alemao |
| `SwissQrCode` | Pagamento QR-bill suico |
| `OneTimePassword` | TOTP/HOTP para 2FA |
| `ShadowSocksConfig` | Configuracao de proxy ShadowSocks |
| `Bookmark` | Favorito do navegador |
| `SkypeCall` | Link de chamada Skype |
| `WhatsAppMessage` | Mensagem WhatsApp |
| `RussiaPaymentOrder` | Ordem de pagamento russa |
| `SlovenianUpnQr` | Pagamento UPN QR esloveno |

## Cobertura de Testes

| Metrica | Cobertura | Status |
|---------|-----------|--------|
| **Cobertura de Linhas** | 78%+ | Bom |
| **Cobertura de Branches** | 83%+ | Excelente |
| **Cobertura de Metodos** | 78%+ | Bom |
| **Total de Testes** | 300+ | Todos Passaram |

## Status do Projeto

**Concluido** - Mantido ativamente com pipelines modernos de CI/CD.

## Pre-requisitos

Esta biblioteca e compativel com multiplas versoes do .NET:

- **.NET Standard 2.1** — Compatibilidade maxima
- **.NET 8.0** — LTS recomendado
- **.NET 10.0** — Versao mais recente
- **.NET Framework 4.8** — Suporte legado

## Instalacao

### NuGet Package Manager (recomendado)

```bash
Install-Package QRCoder.Core
```

### .NET CLI

```bash
dotnet add package QRCoder.Core
```

### PackageReference

```xml
<PackageReference Include="QRCoder.Core" Version="2.0.0" />
```

## Inicio Rapido

Gere seu primeiro QR code com apenas algumas linhas de codigo:

```csharp
using QRCoder.Core;
using SkiaSharp;

// Criar o gerador de QR Code
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("https://github.com/afonsoft/QRCoder.Core",
    QRCodeGenerator.ECCLevel.M);

// Renderizar como bytes PNG (multiplataforma, sem System.Drawing)
using var png = new PngByteQRCode(data);
byte[] pngBytes = png.GetGraphic(10);
File.WriteAllBytes("qrcode.png", pngBytes);

// Ou renderizar como SKBitmap
using var qrCode = new QRCode(data);
using var bitmap = qrCode.GetGraphic(10);
```

### Mais Formatos de Saida

```csharp
// Saida SVG
using var svg = new SvgQRCode(data);
string svgString = svg.GetGraphic(10);

// Saida ASCII (otimo para terminal)
using var ascii = new ASCIIQRCode(data);
Console.WriteLine(ascii.GetGraphic(1));

// Saida PDF
using var pdf = new PdfByteQRCode(data);
byte[] pdfBytes = pdf.GetGraphic(5);

// Base64 PNG (embutir em HTML)
using var b64 = new Base64QRCode(data);
string base64Img = b64.GetGraphic(10);

// Com cores personalizadas
using var colorQr = new QRCode(data);
using var colorBmp = colorQr.GetGraphic(10, "#1a1a2e", "#e0e0e0");
```

### Exemplos de Payload

```csharp
using QRCoder.Core;

// QR Code Wi-Fi
var wifiPayload = new PayloadGenerator.WiFi("MinhaRede", "MinhaSenha",
    PayloadGenerator.WiFi.Authentication.WPA);
using var gen = new QRCodeGenerator();
using var wifiData = gen.CreateQrCode(wifiPayload.ToString(), QRCodeGenerator.ECCLevel.M);

// QR Code URL
var urlPayload = new PayloadGenerator.Url("https://github.com/afonsoft/QRCoder.Core");
using var urlData = gen.CreateQrCode(urlPayload.ToString(), QRCodeGenerator.ECCLevel.M);

// QR Code Email
var mailPayload = new PayloadGenerator.Mail("teste@exemplo.com", "Assunto", "Corpo do texto");
using var mailData = gen.CreateQrCode(mailPayload.ToString(), QRCodeGenerator.ECCLevel.M);

// Numero de Telefone
var phonePayload = new PayloadGenerator.PhoneNumber("+5511999999999");
using var phoneData = gen.CreateQrCode(phonePayload.ToString(), QRCodeGenerator.ECCLevel.M);

// Cartao de Contato (vCard)
var contactPayload = new PayloadGenerator.ContactData(
    PayloadGenerator.ContactData.ContactOutputType.VCard3,
    "Silva", "Joao",
    phone: "+5511999999999",
    email: "joao.silva@exemplo.com");
using var contactData = gen.CreateQrCode(contactPayload.ToString(), QRCodeGenerator.ECCLevel.M);
```

Consulte o **[Guia de Uso](docs/pt-BR/guia-de-uso.md)** completo para todos os formatos de saida, tipos de payload, configuracoes avancadas e niveis de correcao de erro.

## Niveis de Correcao de Erro

| Nivel | Recuperacao | Caso de Uso |
|-------|-------------|-------------|
| `ECCLevel.L` | ~7% | Capacidade maxima de dados |
| `ECCLevel.M` | ~15% | Uso geral (recomendado) |
| `ECCLevel.Q` | ~25% | Maior confiabilidade |
| `ECCLevel.H` | ~30% | Recuperacao maxima de erros (logos, QR artistico) |

## CI/CD e Build

O projeto utiliza um pipeline completo de CI/CD com GitHub Actions:

### Workflows Disponiveis

- **Build & Pack** — Build principal com testes, cobertura e criacao de pacotes
- **Code Quality** — Analise de codigo com Qodana e SonarCloud
- **Security Scans** — Analise de seguranca com CodeQL, Snyk e SonarCloud
- **Publish NuGet** — Publicacao automatica para NuGet.org e GitHub Packages
- **CI Build & Test** — Build continuo e testes automatizados

### Executando Testes Localmente

```bash
# Build do projeto
dotnet build QRCoder.Core.sln --configuration Release

# Executar todos os testes com cobertura
dotnet test QRCoder.Core.Tests/QRCoder.Core.Tests.csproj \
  --configuration Release \
  --logger "trx;LogFileName=test-results.trx" \
  --results-directory TestResults \
  --collect:"XPlat Code Coverage"

# Gerar relatorio de cobertura HTML
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator \
  -reports:"TestResults/**/coverage.cobertura.xml" \
  -targetdir:"TestResults/CoverageReport" \
  -reporttypes:"Html;XmlSummary;TextSummary"

# Visualizar relatorio: abra TestResults/CoverageReport/index.html
```

## Como Contribuir

1. **Crie uma branch** a partir da `main`:
   ```bash
   git checkout -b feature/sua-feature
   ```

2. **Faca suas alteracoes** seguindo as convencoes de codigo

3. **Os workflows automaticos** serao executados:
   - **Build & Pack** — Valida seu codigo
   - **Code Quality** — Analisa qualidade
   - **Security Scan** — Verifica seguranca

4. **Pull Request**: Crie um PR para `main`

5. **Review e Merge**: Apos aprovacao, seu codigo sera mergeado

## Desenvolvedores

- **Afonso Dutra Nogueira Filho** (AFONSOFT) — Desenvolvedor principal

## Licenca

Este projeto esta licenciado sob a Licenca MIT. Consulte o arquivo [LICENSE.txt](LICENSE.txt) para mais detalhes.
