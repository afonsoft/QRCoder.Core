
# QRCoder.Core

|Code coverage|Build status|NuGet Package|
|-------------|------------|-------------|
[![codecov](https://codecov.io/gh/afonsoft/QRCoder.Core/graph/badge.svg?token=N8RED1A0D7)](https://codecov.io/gh/afonsoft/QRCoder.Core)|[![Build, test, pack, push (Release)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml/badge.svg?branch=main)](https://github.com/afonsoft/QRCoder.Core/actions/workflows/build-and-pack.yml)|[![NuGet Badge](https://buildstats.info/nuget/QRCoder.Core?rnd=0892982314)](https://www.nuget.org/packages/QRCoder.Core/)|

|Code Smell|Lines of Code|Bugs|Vulnerabilities|
|----------|-------------|----|---------------|
|[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=bugs)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=QrCode.Core&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=QrCode.Core)|

## Descrição do Projeto
QRCoder.Core é uma biblioteca C# .NET simples, baseada em [QrCode](https://github.com/codebude/QRCoder), que permite a criação de códigos QR. Esta versão é otimizada para .NET Core e está disponível como um pacote NuGet. O projeto é desenvolvido e mantido pela AFONSOFT, com foco em fornecer uma solução robusta e fácil de usar para geração de códigos QR em ambientes .NET.

## Status do Projeto
Concluída

## Estrutura do Repositório
```
.
├── Docs/                                   # Documentação gerada automaticamente para a biblioteca.
│   └── media/                              # Imagens e mídias utilizadas na documentação.
├── LICENSE.txt                             # Arquivo de licença do projeto.
├── QRCoder.Core/                           # Código-fonte principal da biblioteca QRCoder.Core.
│   ├── ASCIIQRCode.cs                      # Implementação para geração de QR Codes em formato ASCII.
│   ├── AbstractQRCode.cs                   # Classe base abstrata para todos os tipos de QR Codes.
│   ├── ArtQRCode.cs                        # Implementação para geração de QR Codes artísticos.
│   ├── Assets/                             # Ativos do projeto, incluindo ícones e arquivos de README para NuGet.
│   │   ├── nuget-icon.png                  # Ícone do pacote NuGet.
│   │   └── nuget-readme.md                 # Conteúdo do README para o pacote NuGet.
│   ├── Base64QRCode.cs                     # Implementação para geração de QR Codes em formato Base64.
│   ├── BitmapByteQRCode.cs                 # Implementação para geração de QR Codes como bitmaps de bytes.
│   ├── Exceptions/                         # Classes de exceção personalizadas para a biblioteca.
│   │   └── DataTooLongException.cs         # Exceção lançada quando os dados excedem o limite do QR Code.
│   ├── Extensions/                         # Métodos de extensão para funcionalidades adicionais.
│   │   └── StringValueAttribute.cs         # Atributo para valores de string personalizados.
│   ├── PayloadGenerator.cs                 # Gerador de payloads para diferentes tipos de QR Codes (ex: URL, SMS, Wi-Fi).
│   ├── PdfByteQRCode.cs                    # Implementação para geração de QR Codes em formato PDF.
│   ├── PngByteQRCode.cs                    # Implementação para geração de QR Codes em formato PNG.
│   ├── PostscriptQRCode.cs                 # Implementação para geração de QR Codes em formato Postscript.
│   ├── QRCode.cs                           # Classe principal para manipulação e renderização de QR Codes.
│   ├── QRCodeData.cs                       # Estrutura de dados para armazenar os dados do QR Code.
│   ├── QRCodeGenerator.cs                  # Gerador de dados de QR Code.
│   ├── QRCoder.Core.csproj                 # Arquivo de projeto C# para a biblioteca QRCoder.Core.
│   └── SvgQRCode.cs                        # Implementação para geração de QR Codes em formato SVG.
├── QRCoder.Core.Docs.shfbproj              # Projeto de documentação Sandcastle Help File Builder.
├── QRCoder.Core.Docs.sln                   # Solução para o projeto de documentação.
├── QRCoder.Core.Tests/                     # Projeto de testes unitários para a biblioteca.
│   ├── ArtQRCodeRendererTests.cs           # Testes para o renderizador de QR Codes artísticos.
│   ├── AsciiQRCodeRendererTests.cs         # Testes para o renderizador de QR Codes ASCII.
│   ├── Helpers/                            # Classes auxiliares para os testes.
│   │   ├── CategoryDiscoverer.cs           # Auxiliar para descoberta de categorias de testes.
│   │   └── HelperFunctions.cs              # Funções auxiliares gerais para testes.
│   ├── PayloadGeneratorTests.cs            # Testes para o gerador de payloads.
│   ├── PngByteQRCodeRendererTests.cs       # Testes para o renderizador de QR Codes PNG.
│   ├── QRCodeRendererTests.cs              # Testes para o renderizador geral de QR Codes.
│   ├── QRCoder.Core.Tests.csproj           # Arquivo de projeto C# para os testes.
│   ├── QRGeneratorTests.cs                 # Testes para o gerador de QR Codes.
│   ├── SvgQRCodeRendererTests.cs           # Testes para o renderizador de QR Codes SVG.
│   └── assets/                             # Ativos utilizados nos testes (imagens, etc.).
├── QRCoder.Core.sln                        # Solução principal do projeto QRCoder.Core.
└── readme.md                               # README original do repositório.
```

## Tecnologias Utilizadas
*   **C#**: Linguagem de programação principal.
*   **.NET Standard 2.1, .NET 6.0, .NET 8.0**: Frameworks de destino para a biblioteca.
*   **SkiaSharp**: Biblioteca gráfica para renderização de QR Codes em diferentes formatos.
*   **SkiaSharp.Views**: Componentes de UI para SkiaSharp.
*   **System.Text.Encoding**: Para manipulação de codificação de texto.
*   **System.Text.Encoding.Extensions**: Extensões para codificação de texto.
*   **System.Text.Encoding.CodePages**: Suporte a páginas de código adicionais.
*   **SourceLink.Create.CommandLine**: Para depuração de código-fonte.
*   **Microsoft.SourceLink.GitHub**: Para integração com o GitHub SourceLink.

## Pré-requisitos
Para utilizar ou contribuir com este projeto, você precisará ter o .NET SDK instalado em sua máquina, compatível com as versões .NET Standard 2.1, .NET 6.0 ou .NET 8.0.

## Como Rodar a Aplicação
Você pode gerar e visualizar seu primeiro código QR com apenas algumas linhas de código C#.

```csharp
using QRCoder;
using System.Drawing; // Necessário para Bitmap, pode variar dependendo do ambiente .NET

// Instancie o gerador de QR Code
using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
{
    // Crie os dados do QR Code a partir de uma string e nível de correção de erro
    using (QRCodeData qrCodeData = qrGenerator.CreateQrCode("O texto que deve ser codificado.", QRCodeGenerator.ECCLevel.Q))
    {
        // Crie uma instância de QRCode com os dados
        using (QRCode qrCode = new QRCode(qrCodeData))
        {
            // Obtenha a representação gráfica do QR Code como um Bitmap
            // O parâmetro '20' define o tamanho do módulo (pixel) do QR Code
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Exemplo de como salvar a imagem (requer System.Drawing.Common para .NET Core/5+)
            // qrCodeImage.Save("qrcode.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
```

### Parâmetros Opcionais e Sobrecargas
O método `GetGraphic` possui várias sobrecargas. As duas primeiras permitem definir a cor do gráfico do QR code usando tipos `Color` ou notação de cor hexadecimal HTML.

```csharp
// Definir cor usando tipos Color
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.DarkRed, Color.PaleGreen, true);

// Definir cor usando notação de cor hexadecimal HTML
Bitmap qrCodeImage = qrCode.GetGraphic(20, "#000ff0", "#0ff000");
```

Esta sobrecarga permite renderizar um logotipo/imagem no centro do QR code.

```csharp
Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, (Bitmap)Bitmap.FromFile("caminho/para/sua/imagem.png"));
```

## Fluxo do Projeto
O projeto `QRCoder.Core` é uma biblioteca que facilita a geração de códigos QR em aplicações .NET. O fluxo principal envolve:
1.  **Geração de Dados**: A classe `QRCodeGenerator` é responsável por pegar uma string de entrada e convertê-la em `QRCodeData`, que é uma representação binária do QR Code, considerando o nível de correção de erro (ECCLevel).
2.  **Renderização**: As classes que herdam de `AbstractQRCode` (como `QRCode`, `PngByteQRCode`, `SvgQRCode`, `ASCIIQRCode`, etc.) utilizam o `QRCodeData` para renderizar o QR Code em diferentes formatos gráficos (Bitmap, PNG, SVG, ASCII, etc.).
3.  **Geração de Payloads**: A classe `PayloadGenerator` oferece métodos para criar payloads formatados para tipos específicos de QR Codes, como URLs, SMS, contatos, Wi-Fi, entre outros, simplificando a criação de QR Codes para casos de uso comuns.
4.  **Tratamento de Exceções**: O projeto inclui exceções personalizadas, como `DataTooLongException`, para lidar com cenários onde os dados fornecidos excedem a capacidade máxima de um QR Code.

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
- Ajustes gerais no projeto e na documentação.
- Melhorias na formatação do README.md.
- Correção de erros de digitação no README.md.
- Atualização de links da wiki no README.md.
- Ajustes relacionados ao SkiaSharp.

### [1.0.3] - 2024-04-01
#### Fixed
- Correção de ações (fix actions).
#### Changed
- Atualização de dependências (codecov/codecov-action de 4 para 5, NuGet/setup-nuget de 2.0.0 para 2.0.1).
- Ajustes de condição.
