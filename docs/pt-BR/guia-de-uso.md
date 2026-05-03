# QRCoder.Core — Guia de Uso (pt-BR)

Biblioteca .NET multiplataforma para geração de QR Codes usando SkiaSharp. Compatível com **Windows**, **Linux**, **macOS** e **mobile** (Xamarin / MAUI).

## Índice

- [Instalação](#instalação)
- [Início Rápido](#início-rápido)
- [Formatos de Saída](#formatos-de-saída)
  - [QRCode (Bitmap SKBitmap)](#qrcode-bitmap-skbitmap)
  - [PNG em Bytes](#png-em-bytes)
  - [SVG](#svg)
  - [Base64](#base64)
  - [PDF](#pdf)
  - [ASCII Art](#ascii-art)
  - [Postscript / EPS](#postscript--eps)
  - [QR Code Artístico](#qr-code-artístico)
  - [BMP em Bytes](#bmp-em-bytes)
- [Payloads (Tipos de Conteúdo)](#payloads-tipos-de-conteúdo)
- [Configurações Avançadas](#configurações-avançadas)
- [Plataformas Suportadas](#plataformas-suportadas)

---

## Instalação

```bash
dotnet add package QRCoder.Core
```

Ou via NuGet Package Manager:

```
Install-Package QRCoder.Core
```

### Dependências por Plataforma

O SkiaSharp requer bibliotecas nativas para cada plataforma. O pacote `QRCoder.Core` já inclui as dependências corretas automaticamente:

| Plataforma | Pacote Nativo                      |
| ---------- | ---------------------------------- |
| Linux      | `SkiaSharp.NativeAssets.Linux`     |
| macOS      | `SkiaSharp.NativeAssets.macOS`     |
| Windows    | `SkiaSharp.NativeAssets.Win32`     |
| Android    | `SkiaSharp.NativeAssets.Android`   |
| iOS        | `SkiaSharp.NativeAssets.iOS`       |

---

## Início Rápido

```csharp
using QRCoder.Core;
using SkiaSharp;

// 1. Criar o gerador
using var gerador = new QRCodeGenerator();

// 2. Gerar os dados do QR Code
using var dados = gerador.CreateQrCode("https://github.com/afonsoft/QRCoder.Core", 
    QRCodeGenerator.ECCLevel.M);

// 3. Renderizar como imagem
using var qrCode = new QRCode(dados);
using var imagem = qrCode.GetGraphic(10); // 10 pixels por módulo

// 4. Salvar como PNG
using var stream = File.OpenWrite("qrcode.png");
imagem.Encode(stream, SKEncodedImageFormat.Png, 100);
```

---

## Formatos de Saída

### QRCode (Bitmap SKBitmap)

Gera um `SKBitmap` com o QR Code renderizado via SkiaSharp.

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("Olá Mundo!", QRCodeGenerator.ECCLevel.H);
using var qr = new QRCode(dados);

// Preto e branco padrão
using var bmp = qr.GetGraphic(10);

// Cores personalizadas
using var bmpColorido = qr.GetGraphic(10, SKColors.DarkBlue, SKColors.LightGray, true);

// Usando cores hexadecimais
using var bmpHex = qr.GetGraphic(10, "#1a1a2e", "#e0e0e0");

// Com logotipo centralizado
using var logo = SKBitmap.Decode("logo.png");
using var bmpComLogo = qr.GetGraphic(10, SKColors.Black, SKColors.White,
    icon: logo, iconSizePercent: 15, iconBorderWidth: 2);
```

### PNG em Bytes

Gera o QR Code diretamente como array de bytes PNG — ideal para APIs e serviços web.

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("Dados da API", QRCodeGenerator.ECCLevel.M);
using var png = new PngByteQRCode(dados);

// Padrão preto e branco
byte[] bytesPng = png.GetGraphic(5);
File.WriteAllBytes("qrcode.png", bytesPng);

// Com cores personalizadas (RGB)
byte[] corEscura = new byte[] { 0, 0, 128 };     // Azul escuro
byte[] corClara = new byte[] { 255, 255, 200 };   // Amarelo claro
byte[] bytesColorido = png.GetGraphic(5, corEscura, corClara);

// Com transparência (RGBA)
byte[] escuroAlfa = new byte[] { 0, 0, 0, 255 };
byte[] claroAlfa = new byte[] { 255, 255, 255, 128 };  // Semi-transparente
byte[] bytesAlfa = png.GetGraphic(5, escuroAlfa, claroAlfa);
```

### SVG

Gera o QR Code como string SVG — perfeito para web e documentos vetoriais.

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("https://afonsoft.com.br", QRCodeGenerator.ECCLevel.Q);
using var svg = new SvgQRCode(dados);

// SVG padrão
string svgString = svg.GetGraphic(10);
File.WriteAllText("qrcode.svg", svgString);

// Com cores personalizadas
string svgColorido = svg.GetGraphic(10, SKColors.DarkRed, SKColors.White);

// Com tamanho de viewBox específico
string svgViewBox = svg.GetGraphic(new Size(200, 200));

// Sem zona silenciosa (quiet zone)
string svgSemBorda = svg.GetGraphic(10, SKColors.Black, SKColors.White, false);

// Com logotipo SVG embutido
string svgLogo = File.ReadAllText("logo.svg");
var logoObj = new SvgQRCode.SvgLogo(svgLogo, 15);
string svgComLogo = svg.GetGraphic(10, SKColors.Black, SKColors.White, logo: logoObj);
```

### Base64

Gera o QR Code codificado em Base64 — útil para incorporar em HTML/CSS.

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("Dados Base64", QRCodeGenerator.ECCLevel.M);
using var b64 = new Base64QRCode(dados);

// PNG em Base64
string base64Png = b64.GetGraphic(5);

// JPEG em Base64
string base64Jpeg = b64.GetGraphic(5, SKColors.Black, SKColors.White, 
    true, Base64QRCode.ImageType.Jpeg);

// Usar em HTML
string htmlImg = $"<img src=\"data:image/png;base64,{base64Png}\" alt=\"QR Code\" />";
```

### PDF

Gera o QR Code como documento PDF em bytes.

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("Documento PDF", QRCodeGenerator.ECCLevel.M);
using var pdf = new PdfByteQRCode(dados);

// PDF padrão
byte[] bytesPdf = pdf.GetGraphic(5);
File.WriteAllBytes("qrcode.pdf", bytesPdf);

// Com cores e DPI personalizado
byte[] pdfColorido = pdf.GetGraphic(5, "#000080", "#FFFFFF", 300, 95);
```

### ASCII Art

Gera o QR Code como texto ASCII — útil para terminal e logs.

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("Terminal QR", QRCodeGenerator.ECCLevel.L);
using var ascii = new AsciiQRCode(dados);

// Padrão
string texto = ascii.GetGraphic(1);
Console.WriteLine(texto);

// Símbolos personalizados
string personalizado = ascii.GetGraphic(1, "██", "  ", true);

// Obter linha por linha
string[] linhas = ascii.GetLineByLineGraphic(1);
foreach (var linha in linhas)
    Console.WriteLine(linha);

// Via helper (uma linha)
string resultado = AsciiQRCodeHelper.GetQRCode("Rápido!", 1, "██", "  ",
    QRCodeGenerator.ECCLevel.M);
```

### Postscript / EPS

Gera o QR Code em formato Postscript ou EPS.

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("Impressão", QRCodeGenerator.ECCLevel.M);
using var ps = new PostscriptQRCode(dados);

// Postscript padrão
string postscript = ps.GetGraphic(5);
File.WriteAllText("qrcode.ps", postscript);

// Formato EPS
string eps = ps.GetGraphic(5, epsFormat: true);
File.WriteAllText("qrcode.eps", eps);

// Com cores
string psColorido = ps.GetGraphic(5, "#FF0000", "#FFFFFF");

// Com viewBox
string psViewBox = ps.GetGraphic(new Size(200, 200));
```

### QR Code Artístico

Gera QR Codes com estilo artístico (pontos ao invés de quadrados).

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("QR Artístico", QRCodeGenerator.ECCLevel.H);
using var art = new ArtQRCode(dados);

// Padrão (pontos arredondados)
using var bmp = art.GetGraphic(10);

// Com tamanho de pixel personalizado (0.0 a 1.0)
using var bmpPequeno = art.GetGraphic(10, SKColors.Black, SKColors.White,
    SKColors.Transparent, pixelSizeFactor: 0.5);

// Com imagem de fundo
using var fundo = SKBitmap.Decode("fundo.png");
using var bmpComFundo = art.GetGraphic(fundo);

// Com padrão de finder personalizado
using var finder = SKBitmap.Decode("finder.png");
using var bmpCustom = art.GetGraphic(10, SKColors.Black, SKColors.White,
    SKColors.Transparent, finderPatternImage: finder);
```

### BMP em Bytes

Gera o QR Code como array de bytes no formato Windows Bitmap.

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("BMP test", QRCodeGenerator.ECCLevel.M);
using var bmp = new SKBitmapByteQRCode(dados);

// Padrão
byte[] bytesBmp = bmp.GetGraphic(5);

// Com cores hexadecimais
byte[] bytesColorido = bmp.GetGraphic(5, "#FF0000", "#00FF00");

// Via helper
byte[] bytesHelper = SKBitmapByteQRCodeHelper.GetQRCode("Rápido!", 5,
    "#000000", "#FFFFFF", QRCodeGenerator.ECCLevel.M);
```

---

## Payloads (Tipos de Conteúdo)

O `PayloadGenerator` cria conteúdos estruturados para diversos tipos de QR Code:

### WiFi

```csharp
var wifi = new PayloadGenerator.WiFi("MinhaRede", "MinhaSenha123",
    PayloadGenerator.WiFi.Authentication.WPA);
string conteudo = wifi.ToString();

// Rede oculta
var wifiOculta = new PayloadGenerator.WiFi("RedeOculta", "Senha",
    PayloadGenerator.WiFi.Authentication.WPA, isHiddenSSID: true);
```

### URL

```csharp
var url = new PayloadGenerator.Url("https://github.com/afonsoft/QRCoder.Core");
string conteudo = url.ToString();
```

### E-mail

```csharp
var email = new PayloadGenerator.Mail("contato@afonsoft.com.br",
    "Assunto do E-mail", "Corpo da mensagem");
string conteudo = email.ToString();
```

### SMS

```csharp
var sms = new PayloadGenerator.SMS("+5511999999999", "Olá! Mensagem via QR Code.");
string conteudo = sms.ToString();
```

### Telefone

```csharp
var telefone = new PayloadGenerator.PhoneNumber("+5511999999999");
string conteudo = telefone.ToString();
// Resultado: tel:+5511999999999
```

### Geolocalização

```csharp
var geo = new PayloadGenerator.Geolocation("-23.5505", "-46.6333");
string conteudo = geo.ToString();
// Resultado: geo:-23.5505,-46.6333
```

### Bitcoin

```csharp
var btc = new PayloadGenerator.BitcoinAddress(
    "1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa",
    amount: 0.001,
    label: "Doação",
    message: "Obrigado pelo suporte!");
string conteudo = btc.ToString();
```

### vCard (Contato)

```csharp
var contato = new PayloadGenerator.ContactData(
    PayloadGenerator.ContactData.ContactOutputType.VCard3,
    firstname: "Afonso",
    lastname: "Nogueira",
    org: "AFONSOFT",
    email: "contato@afonsoft.com.br",
    phone: "+5511999999999",
    street: "Rua Exemplo, 123",
    city: "São Paulo",
    stateRegion: "SP",
    country: "Brasil");
string conteudo = contato.ToString();
```

### Evento de Calendário

```csharp
var evento = new PayloadGenerator.CalendarEvent(
    "Reunião de Equipe",
    "Descrição do evento",
    "Sala 101",
    new DateTime(2026, 06, 15, 14, 0, 0),
    new DateTime(2026, 06, 15, 15, 0, 0),
    true);
string conteudo = evento.ToString();
```

---

## Configurações Avançadas

### Níveis de Correção de Erro (ECC)

| Nível | Capacidade de Recuperação | Recomendado Para             |
| ----- | ------------------------- | ---------------------------- |
| L     | ~7%                       | Dados simples, URL curtas    |
| M     | ~15%                      | Uso geral (padrão)          |
| Q     | ~25%                      | QR Codes com logotipo        |
| H     | ~30%                      | Ambientes com desgaste       |

### Serialização de Dados

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("Dados serializáveis", QRCodeGenerator.ECCLevel.M);

// Salvar em arquivo
dados.SaveRawData("dados.qrr", QRCodeData.Compression.GZip);

// Carregar de arquivo
using var dadosCarregados = new QRCodeData("dados.qrr", QRCodeData.Compression.GZip);

// Serializar para bytes
byte[] rawBytes = dados.GetRawData(QRCodeData.Compression.Deflate);

// Desserializar de bytes
using var dadosDeBytes = new QRCodeData(rawBytes, QRCodeData.Compression.Deflate);
```

### Forçar UTF-8

```csharp
using var gerador = new QRCodeGenerator();
// Forçar codificação UTF-8 com BOM
using var dados = gerador.CreateQrCode("Texto com acentuação",
    QRCodeGenerator.ECCLevel.M,
    forceUtf8: true,
    utf8BOM: true);
```

### Versão Fixa do QR Code

```csharp
using var gerador = new QRCodeGenerator();
// Forçar versão 10 do QR Code (57x57 módulos)
using var dados = gerador.CreateQrCode("Texto",
    QRCodeGenerator.ECCLevel.M,
    requestedVersion: 10);
```

---

## Plataformas Suportadas

| Framework             | Versão | Status     |
| --------------------- | ------ | ---------- |
| .NET Standard         | 2.1    | Suportado  |
| .NET                  | 8.0    | Suportado  |
| .NET                  | 10.0   | Suportado  |
| .NET Framework        | 4.8    | Suportado  |
| Xamarin.Android       | -      | Via SkiaSharp |
| Xamarin.iOS           | -      | Via SkiaSharp |
| .NET MAUI             | -      | Via SkiaSharp |

### Exemplo para ASP.NET Core (API)

```csharp
[HttpGet("qrcode")]
public IActionResult GerarQRCode([FromQuery] string texto)
{
    using var gerador = new QRCodeGenerator();
    using var dados = gerador.CreateQrCode(texto, QRCodeGenerator.ECCLevel.M);
    using var png = new PngByteQRCode(dados);

    byte[] bytes = png.GetGraphic(5);
    return File(bytes, "image/png");
}
```

### Exemplo para .NET MAUI / Xamarin

```csharp
public ImageSource GerarQRCodeImagem(string texto)
{
    using var gerador = new QRCodeGenerator();
    using var dados = gerador.CreateQrCode(texto, QRCodeGenerator.ECCLevel.M);
    using var png = new PngByteQRCode(dados);

    byte[] bytes = png.GetGraphic(5);
    return ImageSource.FromStream(() => new MemoryStream(bytes));
}
```

### Exemplo para Console (Terminal)

```csharp
using var gerador = new QRCodeGenerator();
using var dados = gerador.CreateQrCode("Terminal!", QRCodeGenerator.ECCLevel.L);
using var ascii = new AsciiQRCode(dados);

Console.WriteLine(ascii.GetGraphic(1));
```
