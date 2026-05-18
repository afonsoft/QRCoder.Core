---
name: qrcode-development
description: >
  What: Guia para desenvolvimento de renderizadores, payloads e funcionalidades do QRCoder.Core.
  When: Ao criar novos renderizadores, adicionar payloads, modificar o QRCodeGenerator, ou trabalhar com SkiaSharp.
  Do NOT: Não usar para testes (ver qrcode-testing), CI/CD, ou documentação isolada.
---

## Contexto

QRCoder.Core é uma biblioteca cross-platform para geração de QR Codes. A arquitetura segue:
- `QRCodeGenerator` → engine central que gera `QRCodeData` (matriz de bits)
- `AbstractQRCode` → classe base para renderizadores
- Cada renderizador converte `QRCodeData` em um formato de saída específico

## Atuação

### Novo Renderizador
1. Criar classe em `QRCoder.Core/Renderers/`
2. Herdar de `AbstractQRCode`
3. Implementar `GetGraphic()` com parâmetros de customização
4. Manter compatibilidade cross-platform (sem System.Drawing)
5. Usar SkiaSharp para renderização gráfica se necessário

### Novo Payload
1. Criar classe em `PayloadGenerator` (arquivo existente)
2. Implementar `ToString()` retornando string formatada
3. Seguir padrão da indústria (RFC, especificação oficial)
4. Adicionar validação de inputs

### Performance
- Usar `ObjectPool<QRCodeData>` para reutilização de buffers
- Usar `Span<T>` e `System.Buffers` para operações com arrays
- Evitar alocações em hot paths

## Restrições

- Não usar System.Drawing (não é cross-platform)
- Manter compatibilidade com .NET Standard 2.1
- Não adicionar dependências nativas além do SkiaSharp
- XML documentation obrigatória em APIs públicas

## Exemplos

```csharp
// Gerar QR Code PNG
var generator = new QRCodeGenerator();
var data = generator.CreateQrCode("Hello", QRCodeGenerator.ECCLevel.M);
var pngCode = new PngByteQRCode(data);
byte[] pngBytes = pngCode.GetGraphic(20);
```
