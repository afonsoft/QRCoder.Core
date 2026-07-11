# QRCoder.Core - Biblioteca Geradora de QR Code

[![Build status](https://github.com/afonsoft/QRCoder.Core/actions/workflows/ci-build-test.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/ci-build-test.yml)
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)
[![NuGet Badge](https://img.shields.io/nuget/v/QRCoder.Core.svg)](https://www.nuget.org/packages/QRCoder.Core/)
[![Code Quality](https://sonarcloud.io/api/project_badges/measure?project=afonsoft_QRCoder.Core&metric=alert_status)](https://sonarcloud.io/project/overview?id=afonsoft_QRCoder.Core)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=afonsoft_QRCoder.Core&metric=security_rating)](https://sonarcloud.io/project/overview?id=afonsoft_QRCoder.Core)

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
| **ASCII** | `AsciiQRCode` | Arte ASCII para saida em terminal |
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
| **Cobertura de Linhas** | 96,9% | Excelente |
| **Cobertura de Branches** | 92,6% | Excelente |
| **Cobertura de Metodos** | 96,0% | Excelente |
| **Total de Testes** | 502 | Todos Passaram |

## Status do Projeto

**Concluido** - Mantido ativamente com pipelines modernos de CI/CD.

## Visao de Negocio

QRCoder.Core oferece uma base leve e multiplataforma para geracao de QR Codes, podendo ser embarcada em qualquer produto .NET — desde backends web e moveis ate aplicacoes desktop e ferramentas CLI. O objetivo e eliminar dependencias graficas especificas de plataforma, oferecendo uma API previsivel e extensivel para multiplos formatos de saida e payloads padronizados.

## Visao Tecnica

A biblioteca segue uma arquitetura de **Clean Architecture**:

- **Geracao**: `QRCodeGenerator` constroi a matriz abstrata `QRCodeData` (models).
- **Payloads**: `PayloadGenerator` formata strings padroes (Wi-Fi, vCard, SEPA, etc.) sem acoplamento a renderizacao.
- **Renderizacao**: Implementacoes de `AbstractQRCode` produzem formatos de saida (PNG, SVG, PDF, ASCII, Base64, Postscript, Art, BMP) usando **SkiaSharp** para renderizacao cross-platform.
- **Regra de dependencia**: `Abstractions` e `Models` nao possuem dependencias externas; `Renderers` e `Generators` dependem apenas de `Models` e `Abstractions`.
- **Portoes de qualidade**: build sem warnings, testes xUnit com **~97% de cobertura de linhas** e analise estatica via SonarCloud / Codecov / Snyk.

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
<PackageReference Include="QRCoder.Core" Version="2.0.1" />
```

## Inicio Rapido

Gere seu primeiro QR code com apenas algumas linhas de codigo:

```csharp
using System;
using System.IO;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
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
using System;
using System.IO;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using SkiaSharp;

// Saida SVG
using var svg = new SvgQRCode(data);
string svgString = svg.GetGraphic(10);

// Saida ASCII (otimo para terminal)
using var ascii = new AsciiQRCode(data);
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
using System;
using System.IO;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using QRCoder.Core.Renderers;
using SkiaSharp;

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

## Estrutura do Repositorio

```
.
├── QRCoder.Core/              # Codigo-fonte da biblioteca principal
│   ├── Abstractions/          # Classe base e contratos
│   │   └── AbstractQRCode.cs  # Classe base para todos os renderizadores
│   ├── Models/                # Modelo de dados e value objects
│   │   ├── QRCodeData.cs      # Estrutura de dados do QR Code
│   │   └── Size.cs            # Value object de dimensao de renderizacao
│   ├── Generators/            # Motor de geracao de QR Codes
│   │   ├── QRCodeGenerator.cs # Gerador principal de dados
│   │   └── PayloadGenerator.cs# Formatadores de payload (WiFi, URL, etc.)
│   ├── Renderers/             # Renderizadores por formato
│   │   ├── QRCode.cs          # Renderizador SKBitmap
│   │   ├── PngByteQRCode.cs   # Renderizador PNG byte array
│   │   ├── SvgQRCode.cs       # Renderizador SVG string
│   │   ├── PdfByteQRCode.cs   # Renderizador PDF byte array
│   │   ├── AsciiQRCode.cs     # Renderizador ASCII art
│   │   ├── Base64QRCode.cs    # Renderizador Base64
│   │   ├── PostscriptQRCode.cs# Renderizador Postscript/EPS
│   │   ├── ArtQRCode.cs       # Renderizador QR artistico
│   │   └── BitmapByteQRCode.cs# Renderizador BMP byte array
│   ├── Extensions/            # Extensoes SkiaSharp e utilitarios
│   ├── Exceptions/            # Excecoes customizadas
│   └── Assets/                # Ativos do NuGet
├── QRCoder.Core.Tests/        # Testes unitarios (502 testes)
├── QRCoder.Core.Benchmarks/   # Benchmarks de performance
├── docs/                      # Guias de uso
│   ├── en-US/usage-guide.md   # Guia em ingles
│   └── pt-BR/guia-de-uso.md   # Guia em portugues
├── .github/workflows/         # Pipelines de CI/CD
├── CHANGELOG.md               # Historico de versoes
└── README.md / README.pt-br.md# Documentacao em ingles e portugues
```

## Changelog

Consulte o [CHANGELOG.md](CHANGELOG.md) completo para o historico de versoes.

### [2.0.1] - 2026-07-11
#### Adicionado
- Documentacao XML em todas as APIs publicas (CS1591 removido do NoWarn).
- Secoes de estrutura do repositorio, visao de negocio e visao tecnica no README.
- `BDDTests.cs` com testes no estilo Dado/Quando/Entao para validar geracao e renderizacao de QR Codes.

#### Alterado
- Versao do pacote alterada para `2.0.1`.
- Badges de CI, NuGet, SonarCloud e Codecov atualizados nos arquivos README.
- Links do SonarCloud ajustados para o projeto correto (`afonsoft_QRCoder.Core`).
- CHANGELOG.md consolidado no padrao Keep a Changelog e SemVer.

#### Corrigido
- Badge do NuGet quebrado (agora via shields.io).
- Badge de build quebrado (agora `ci-build-test.yml`).
- SonarQube S2184 (divisao inteira no tamanho de midia do `PdfByteQRCode`).
- SonarQube S4136 ao agrupar overloads de `GetGraphic` em `QRCode` e `PdfByteQRCode`.

### [2.0.0] - 2026-05-10
#### Alterado
- Reorganizacao do codigo com estrutura SOLID e Clean Architecture.
- Documentacao multi-idioma (en-US padrao + pt-BR).
- Frameworks-alvo atualizados: .NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8.

### [1.0.8] - 2026-02-18
#### Adicionado
- Manipulacao de bibliotecas nativas do SkiaSharp para CI Linux.
- Consolidacao dos workflows de publicacao.

### [1.0.5] - 2025-07-13
#### Alterado
- Migracao da renderizacao para SkiaSharp.
- Ajustes gerais no projeto e documentacao.

### [1.0.3] - 2024-04-01
#### Alterado
- Atualizacao de dependencias.
#### Corrigido
- Correcoes nas actions.

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

## Historico de Estrelas

Veja o [grafico de historico de estrelas](https://www.star-history.com/?repos=afonsoft%2FQRCoder.Core&type=date&legend=top-left) deste repositorio.

## StarMapper

[![Mapa StarMapper](https://starmapper.bruniaux.com/afonsoft/QRCoder.Core/opengraph-image)](https://starmapper.bruniaux.com/afonsoft/QRCoder.Core)

## Licenca

Este projeto esta licenciado sob a Licenca MIT. Consulte o arquivo [LICENSE.txt](LICENSE.txt) para mais detalhes.
