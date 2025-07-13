
# QRCoder.Core - QR Code Generator Library

|Code coverage|Build status|NuGet Package|
|-------------|------------|-------------|
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)|[![Build, test, pack, push (Release)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml)|[![NuGet Badge](https://buildstats.info/nuget/QRCoder.Core?rnd=0892982314)](https://www.nuget.org/packages/QRCoder.Core/)|

|Code Smell|Lines of Code|Bugs|Vulnerabilities|
|----------|-------------|----|---------------|
|[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=bugs)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|

## Descrição do Projeto
QRCoder.Core é uma biblioteca C# .NET simples, baseada em [QrCode](https://github.com/codebude/QRCoder), que permite a criação de códigos QR. Esta versão é otimizada para .NET Core e está disponível como um pacote NuGet. O projeto é desenvolvido e mantido pela AFONSOFT, com foco em fornecer uma solução robusta e fácil de usar para a geração de códigos QR em ambientes .NET.

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
*   **.NET Standard 2.1, .NET 6.0, .NET 8.0**: Frameworks alvo para a biblioteca.
*   **SkiaSharp**: Biblioteca gráfica para renderização de códigos QR em diferentes formatos.
*   **SkiaSharp.Views**: Componentes de UI para SkiaSharp.
*   **System.Text.Encoding**: Para manipulação de codificação de texto.
*   **System.Text.Encoding.Extensions**: Extensões para codificação de texto.
*   **System.Text.Encoding.CodePages**: Suporte para páginas de código adicionais.
*   **SourceLink.Create.CommandLine**: Para depuração de código-fonte.
*   **Microsoft.SourceLink.GitHub**: Para integração com SourceLink do GitHub.

## Pré-requisitos
Para usar ou contribuir com este projeto, você precisará ter o SDK do .NET instalado em sua máquina, compatível com as versões .NET Standard 2.1, .NET 6.0 ou .NET 8.0.

## Como Começar
Você pode gerar e visualizar seu primeiro código QR com apenas algumas linhas de código C#.

```csharp
using QRCoder;
using System.Drawing; // Necessário para Bitmap, pode variar dependendo do ambiente .NET

// Instancia o gerador de código QR
using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
{
    // Cria dados do código QR a partir de uma string e nível de correção de erro
    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode("O texto a ser codificado.", QRCodeGenerator.ECCLevel.Q))
    {
        // Cria uma instância de QRCode com os dados
        using (QRCode qrCode = new QRCode(qrCodeData))
        {
            // Obtém a representação gráfica do código QR como um Bitmap
            // O parâmetro '20' define o tamanho do módulo (pixel) do código QR
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Exemplo de como salvar a imagem (requer System.Drawing.Common para .NET Core/5+)
            // qrCodeImage.Save("qrcode.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
```

### Parâmetros Opcionais e Sobrecargas
O método `GetGraphic` possui várias sobrecargas. As duas primeiras permitem definir a cor gráfica do código QR usando tipos `Color` ou notação de cor hexadecimal HTML.

```csharp
// Define a cor usando tipos Color
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.DarkRed, Color.PaleGreen, true);

// Define a cor usando notação de cor hexadecimal HTML
Bitmap qrCodeImage = qrCode.GetGraphic(20, "#000ff0", "#0ff000");
```

Esta sobrecarga permite renderizar um logotipo/imagem no centro do código QR.

```csharp
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile("path/to/your/image.png"));
```

## Fluxo do Projeto
O projeto `QRCoder.Core` é uma biblioteca que facilita a geração de códigos QR em aplicações .NET. O fluxo principal envolve:
1.  **Geração de Dados**: A classe `QRCodeGenerator` é responsável por pegar uma string de entrada e convertê-la em `QRCodeData`, que é uma representação binária do Código QR, considerando o nível de correção de erro (ECCLevel).
2.  **Renderização**: Classes que herdam de `AbstractQRCode` (como `QRCode`, `PngByteQRCode`, `SvgQRCode`, `ASCIIQRCode`, etc.) usam `QRCodeData` para renderizar o Código QR em diferentes formatos gráficos (Bitmap, PNG, SVG, ASCII, etc.).
3.  **Geração de Payload**: A classe `PayloadGenerator` oferece métodos para criar payloads formatados para tipos específicos de Código QR, como URLs, SMS, contatos, Wi-Fi, entre outros, simplificando a criação de Códigos QR para casos de uso comuns.
4.  **Tratamento de Exceções**: O projeto inclui exceções personalizadas, como `DataTooLongException`, para lidar com cenários onde os dados fornecidos excedem a capacidade máxima de um Código QR.

## Cobertura de Código
A cobertura de código é monitorada e os resultados podem ser visualizados através do badge:
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)

## Desenvolvedores/Contribuintes
*   **Afonso Dutra Nogueira Filho** (AFONSOFT) - Desenvolvedor principal.

## Licença
Este projeto está licenciado sob a Licença MIT. Para mais detalhes, consulte o arquivo [LICENSE.txt](LICENSE.txt).

## Changelog

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
