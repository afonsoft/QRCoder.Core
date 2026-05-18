---
name: 'C# QRCoder.Core Standards'
description: 'Padrões de código C# para a biblioteca QRCoder.Core, incluindo SkiaSharp, renderizadores e performance'
applyTo: '**/*.cs'
---

# C# QRCoder.Core Standards

## Arquitetura

- `QRCodeGenerator` → gera `QRCodeData` (bit matrix)
- `AbstractQRCode` → base para renderizadores
- Cada renderizador em arquivo separado em `Renderers/`
- Interfaces em `Abstractions/`

## SkiaSharp

- Sempre fazer `Dispose()` de objetos SKBitmap, SKCanvas, SKPaint
- Usar `using` statements para recursos gráficos
- Não assumir disponibilidade de fontes do sistema
- Configurar `LD_LIBRARY_PATH` em ambientes Linux

## Performance

- Usar `ObjectPool` para buffers reutilizáveis
- Usar `Span<T>` e `ReadOnlySpan<T>` onde possível
- Evitar boxing/unboxing em hot paths
- Preferir `stackalloc` para arrays pequenos

## Multi-TFM

- Manter compatibilidade com .NET Standard 2.1
- Usar `#if` directives para APIs específicas de TFM
- Testar em todos os target frameworks

## Documentação

- XML docs obrigatórios em todas as APIs públicas
- `<summary>`, `<param>`, `<returns>`, `<exception>`
- Exemplos em `<example>` para APIs complexas

## Testes

- xUnit + Shouldly para assertions
- BDD em português: Dado/Quando/Então
- Comparar outputs com referências em `assets/`
