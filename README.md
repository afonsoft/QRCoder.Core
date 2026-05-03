
# QRCoder.Core - QR Code Generator Library

[![Build status](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml)
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)
[![NuGet Badge](https://buildstats.info/nuget/QRCoder.Core?rnd=0892982314)](https://www.nuget.org/packages/QRCoder.Core/)
[![Code Quality](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)

## Documentation / Documentação

- **[Usage Guide (English)](docs/en-US/usage-guide.md)**
- **[Guia de Uso (Português)](docs/pt-BR/guia-de-uso.md)**

## Test Coverage

| Metric | Coverage | Status |
|--------|----------|--------|
| **Line Coverage** | 78%+ | Good |
| **Branch Coverage** | 83%+ | Excellent |
| **Method Coverage** | 78%+ | Good |
| **Total Tests** | 300+ | All Passed |

## Descrição do Projeto / Project Description

QRCoder.Core is a cross-platform .NET library for QR Code generation using **SkiaSharp** for image rendering. Compatible with **Windows**, **Linux**, **macOS**, and **mobile** (Xamarin / MAUI).

QRCoder.Core é uma biblioteca .NET multiplataforma para geração de QR Codes usando **SkiaSharp** para renderização de imagens. Compatível com **Windows**, **Linux**, **macOS** e **mobile** (Xamarin / MAUI).

Based on [QRCoder](https://github.com/codebude/QRCoder). Developed and maintained by AFONSOFT.

## Status do Projeto
Concluída

## Estrutura do Repositório
```
.
├── [Docs/](Docs/)                                   # Documentação gerada automaticamente para a biblioteca.
│   └── media/                              # Imagens e mídias utilizadas na documentação.
├── [LICENSE.txt](LICENSE.txt)                             # Arquivo de licença do projeto.
├── [QRCoder.Core/](QRCoder.Core/)                           # Código-fonte principal da biblioteca QRCoder.Core.
│   ├── [ASCIIQRCode.cs](QRCoder.Core/ASCIIQRCode.cs)                      # Implementação para gerar códigos QR em formato ASCII.
│   ├── [AbstractQRCode.cs](QRCoder.Core/AbstractQRCode.cs)                   # Classe base abstrata para todos os tipos de códigos QR.
│   ├── [ArtQRCode.cs](QRCoder.Core/ArtQRCode.cs)                        # Implementação para gerar códigos QR artísticos.
│   ├── [Assets/](QRCoder.Core/Assets/)                             # Ativos do projeto, incluindo ícones e arquivos README para NuGet.
│   │   ├── nuget-icon.png                  # Ícone do pacote NuGet.
│   │   └── nuget-readme.md                 # Conteúdo do README para o pacote NuGet.
│   ├── [Base64QRCode.cs](QRCoder.Core/Base64QRCode.cs)                     # Implementação para gerar códigos QR em formato Base64.
│   ├── [BitmapByteQRCode.cs](QRCoder.Core/BitmapByteQRCode.cs)                 # Implementação para gerar códigos QR como bitmaps de bytes.
│   ├── [Exceptions/](QRCoder.Core/Exceptions/)                         # Classes de exceção personalizadas para a biblioteca.
│   │   └── [DataTooLongException.cs](QRCoder.Core/Exceptions/DataTooLongException.cs)         # Exceção lançada quando os dados excedem o limite do código QR.
│   ├── [Extensions/](QRCoder.Core/Extensions/)                         # Métodos de extensão para funcionalidades adicionais.
│   │   └── [StringValueAttribute.cs](QRCoder.Core/Extensions/StringValueAttribute.cs)         # Atributo para valores de string personalizados.
│   ├── [PayloadGenerator.cs](QRCoder.Core/PayloadGenerator.cs)                 # Gerador de payload para diferentes tipos de códigos QR (ex: URL, SMS, Wi-Fi).
│   ├── [PdfByteQRCode.cs](QRCoder.Core/PdfByteQRCode.cs)                    # Implementação para gerar códigos QR em formato PDF.
│   ├── [PngByteQRCode.cs](QRCoder.Core/PngByteQRCode.cs)                    # Implementação para gerar códigos QR em formato PNG.
│   ├── [PostscriptQRCode.cs](QRCoder.Core/PostscriptQRCode.cs)                 # Implementação para gerar códigos QR em formato Postscript.
│   ├── [QRCode.cs](QRCoder.Core/QRCode.cs)                           # Classe principal para manipulação e renderização de códigos QR.
│   ├── [QRCodeData.cs](QRCoder.Core/QRCodeData.cs)                       # Estrutura de dados para armazenar dados do código QR.
│   ├── [QRCodeGenerator.cs](QRCoder.Core/QRCodeGenerator.cs)                  # Gerador de dados do código QR.
│   ├── [QRCoder.Core.csproj](QRCoder.Core/QRCoder.Core.csproj)                 # Arquivo de projeto C# para a biblioteca QRCoder.Core.
│   └── [SvgQRCode.cs](QRCoder.Core/SvgQRCode.cs)                        # Implementação para gerar códigos QR em formato SVG.
├── [QRCoder.Core.Docs.shfbproj](QRCoder.Core.Docs.shfbproj)              # Projeto de documentação do Sandcastle Help File Builder.
├── [QRCoder.Core.Docs.sln](QRCoder.Core.Docs.sln)                   # Solução para o projeto de documentação.
├── [QRCoder.Core.Tests/](QRCoder.Core.Tests/)                     # Projeto de testes unitários para a biblioteca.
│   ├── [ArtQRCodeRendererTests.cs](QRCoder.Core.Tests/ArtQRCodeRendererTests.cs)           # Testes para o renderizador de códigos QR artísticos.
│   ├── [AsciiQRCodeRendererTests.cs](QRCoder.Core.Tests/AsciiQRCodeRendererTests.cs)         # Testes para o renderizador de códigos QR ASCII.
│   ├── [Helpers/](QRCoder.Core.Tests/Helpers/)                            # Classes auxiliares para testes.
│   │   ├── [CategoryDiscoverer.cs](QRCoder.Core.Tests/Helpers/CategoryDiscoverer.cs)           # Auxiliar para descoberta de categorias de teste.
│   │   └── [HelperFunctions.cs](QRCoder.Core.Tests/Helpers/HelperFunctions.cs)              # Funções auxiliares gerais para testes.
│   ├── [PayloadGeneratorTests.cs](QRCoder.Core.Tests/PayloadGeneratorTests.cs)            # Testes para o gerador de payload.
│   ├── [PngByteQRCodeRendererTests.cs](QRCoder.Core.Tests/PngByteQRCodeRendererTests.cs)       # Testes para o renderizador de códigos QR PNG.
│   ├── [QRCodeRendererTests.cs](QRCoder.Core.Tests/QRCodeRendererTests.cs)              # Testes para o renderizador geral de códigos QR.
│   ├── [QRCoder.Core.Tests.csproj](QRCoder.Core.Tests/QRCoder.Core.Tests.csproj)           # Arquivo de projeto C# para os testes.
│   ├── [QRGeneratorTests.cs](QRCoder.Core.Tests/QRGeneratorTests.cs)                 # Testes para o gerador de códigos QR.
│   ├── [SvgQRCodeRendererTests.cs](QRCoder.Core.Tests/SvgQRCodeRendererTests.cs)           # Testes para o renderizador de códigos QR SVG.
│   └── [assets/](QRCoder.Core.Tests/assets/)                             # Ativos utilizados em testes (imagens, etc.).
├── [QRCoder.Core.sln](QRCoder.Core.sln)                        # Solução principal para o projeto QRCoder.Core.
└── [readme.md](readme.md)                               # README original do repositório.
```

## Tecnologias Utilizadas
*   **C#**: Linguagem de programação principal.
*   **.NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8**: Frameworks alvo para a biblioteca.
*   **SkiaSharp**: Biblioteca gráfica para renderização de códigos QR em diferentes formatos.
*   **SkiaSharp.Views**: Componentes de UI para SkiaSharp.
*   **System.Text.Encoding**: Para manipulação de codificação de texto.
*   **System.Text.Encoding.Extensions**: Extensões para codificação de texto.
*   **System.Text.Encoding.CodePages**: Suporte para páginas de código adicionais.
*   **SourceLink.Create.CommandLine**: Para depuração de código-fonte.
*   **Microsoft.SourceLink.GitHub**: Para integração com SourceLink do GitHub.

## Pré-requisitos
Para usar ou contribuir com este projeto, você precisará ter o SDK do .NET instalado em sua máquina, compatível com as versões .NET Standard 2.1, .NET 8.0, .NET 10.0 ou .NET Framework 4.8.

## Instalação

### NuGet Package Manager
```bash
Install-Package QRCoder.Core
```

### .NET CLI
```bash
dotnet add package QRCoder.Core
```

### PackageReference
```xml
<PackageReference Include="QRCoder.Core" Version="1.0.5" />
```

## Como Começar
Você pode gerar e visualizar seu primeiro código QR com apenas algumas linhas de código C#.

```csharp
using QRCoder.Core;
using SkiaSharp;

// Create the QR Code generator
using var generator = new QRCodeGenerator();
using var data = generator.CreateQrCode("https://github.com/afonsoft/QRCoder.Core",
    QRCodeGenerator.ECCLevel.M);

// Render as PNG bytes (cross-platform, no System.Drawing needed)
using var png = new PngByteQRCode(data);
byte[] pngBytes = png.GetGraphic(10);
File.WriteAllBytes("qrcode.png", pngBytes);

// Or render as SKBitmap
using var qrCode = new QRCode(data);
using var bitmap = qrCode.GetGraphic(10);
```

### More Examples / Mais Exemplos

See the full documentation for all output formats and payload types:
- **[English Guide](docs/en-US/usage-guide.md)** — PNG, SVG, PDF, ASCII, Base64, Postscript, Artistic
- **[Guia Português](docs/pt-BR/guia-de-uso.md)** — PNG, SVG, PDF, ASCII, Base64, Postscript, Artístico

```csharp
// SVG output
using var svg = new SvgQRCode(data);
string svgString = svg.GetGraphic(10);

// ASCII output (great for terminal)
using var ascii = new AsciiQRCode(data);
Console.WriteLine(ascii.GetGraphic(1));

// PDF output
using var pdf = new PdfByteQRCode(data);
byte[] pdfBytes = pdf.GetGraphic(5);

// With colors
using var colorQr = new QRCode(data);
using var colorBmp = colorQr.GetGraphic(10, "#1a1a2e", "#e0e0e0");
```

## Fluxo do Projeto
O projeto `QRCoder.Core` é uma biblioteca que facilita a geração de códigos QR em aplicações .NET. O fluxo principal envolve:
1.  **Geração de Dados**: A classe `QRCodeGenerator` é responsável por pegar uma string de entrada e convertê-la em `QRCodeData`, que é uma representação binária do Código QR, considerando o nível de correção de erro (ECCLevel).
2.  **Renderização**: Classes que herdam de `AbstractQRCode` (como `QRCode`, `PngByteQRCode`, `SvgQRCode`, `ASCIIQRCode`, etc.) usam `QRCodeData` para renderizar o Código QR em diferentes formatos gráficos (Bitmap, PNG, SVG, ASCII, etc.).
3.  **Geração de Payload**: A classe `PayloadGenerator` oferece métodos para criar payloads formatados para tipos específicos de Código QR, como URLs, SMS, contatos, Wi-Fi, entre outros, simplificando a criação de Códigos QR para casos de uso comuns.
4.  **Tratamento de Exceções**: O projeto inclui exceções personalizadas, como `DataTooLongException`, para lidar com cenários onde os dados fornecidos excedem a capacidade máxima de um Código QR.

## CI/CD e Build
O projeto utiliza um pipeline completo de CI/CD com GitHub Actions para garantir qualidade e automação:

### Workflows Disponíveis:
- **🚀 Build & Pack**: Build principal com testes, coverage e criação de pacotes
- **📊 Code Quality**: Análise de código com Qodana e SonarCloud
- **🔒 Security Scans**: Análises de segurança com CodeQL, Snyk e SonarCloud
- **📦 Publish NuGet**: Publicação automática para NuGet.org e GitHub Packages
- **🧪 CI Build & Test**: Build contínuo e testes automatizados

### 📊 Test Results & Coverage
- **Total Tests**: 300+ testes unitários
- **Test Status**: All passing
- **Coverage Metrics**: Line 78%+, Branch 83%+, Method 78%+
- **Frameworks Testados**: .NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8
- **Relatórios**: HTML coverage reports disponíveis em cada build

### 🧪 Executando Testes Localmente
Para executar os testes e verificar a cobertura localmente:

```bash
# Build do projeto
dotnet build QRCoder.Core.sln --configuration Release

# Executar todos os testes com coverage
dotnet test QRCoder.Core.Tests/QRCoder.Core.Tests.csproj --configuration Release --logger "trx;LogFileName=test-results.trx" --results-directory TestResults --collect:"XPlat Code Coverage"

# Gerar relatório de coverage HTML
dotnet tool install -g dotnet-reportgenerator-globaltool
reportgenerator -reports:"TestResults/**/coverage.cobertura.xml" -targetdir:"TestResults/CoverageReport" -reporttypes:"Html;XmlSummary;TextSummary"

# Visualizar relatório
# Abra: TestResults/CoverageReport/index.html
```

## Desenvolvedores/Contribuintes
*   **Afonso Dutra Nogueira Filho** (AFONSOFT) - Desenvolvedor principal.

## Licença
Este projeto está licenciado sob a Licença MIT. Para mais detalhes, consulte o arquivo [LICENSE.txt](LICENSE.txt).

## Changelog

### [1.0.6] - 2025-02-17
#### Added
- Comprehensive test coverage reporting (78% line coverage, 83.1% branch coverage, 78.1% method coverage)
- 239 unit tests across all target frameworks
- Performance optimization packages (Microsoft.Extensions.ObjectPool, System.Buffers, System.Memory)
- Local test execution documentation
- HTML coverage reports generation
- Test results badges and metrics
- Complete CI/CD pipeline with GitHub Actions
- Support for .NET 10.0 target framework
- Multiple security scans (CodeQL, Snyk, SonarCloud)
- Automated NuGet publishing workflow
- Code quality analysis with Qodana
- Multi-framework build matrix

#### Changed
- Updated README with detailed test coverage information
- Enhanced CI/CD section with test results
- Improved project documentation with test metrics
- Added test execution guide for developers
- Updated target frameworks: .NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8
- Improved GitHub Actions workflows
- Enhanced documentation with CI/CD badges
- Updated project dependencies

#### Fixed
- GitHub Actions syntax issues
- Environment variable references
- Code analysis integration

#### Coverage Details
- **Excellent Coverage (95%+)**: 10 classes including core QRCode, PngByteQRCode, SvgQRCode, PayloadGenerator
- **Good Coverage (70-94%)**: 4 classes including main QRCode and AbstractQRCode
- **Needs Improvement**: QRCodeData (20%)
- **No Coverage**: 8 alternative renderers (Base64QRCode, PdfByteQRCode, PostscriptQRCode, SKBitmapByteQRCode, etc.)

### [1.0.5] - 2025-02-17
#### Added
- Support for .NET 10.0 target framework
- Complete CI/CD pipeline with GitHub Actions
- Multiple security scans (CodeQL, Snyk, SonarCloud)
- Automated NuGet publishing workflow
- Code quality analysis with Qodana
- Enhanced test coverage reporting
- Multi-framework build matrix
#### Changed
- Updated target frameworks: .NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8
- Improved GitHub Actions workflows
- Enhanced documentation with CI/CD badges
- Updated project dependencies
#### Fixed
- GitHub Actions syntax issues
- Environment variable references
- Code analysis integration

### [1.0.4] - 2025-07-13
#### Changed
- General adjustments in the project and documentation.
- Improvements in README.md formatting.
- Typo corrections in README.md.
- Wiki link updates in README.md.
- Adjustments related to SkiaSharp.

### [1.0.3] - 2024-04-01
#### Fixed
- Action corrections (fix actions).
#### Changed
- Dependency updates (codecov/codecov-action from 4 to 5, NuGet/setup-nuget from 2.0.0 to 2.0.1).
- Condition adjustments.
