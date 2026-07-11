# Relatório de Build e Testes - QRCoder.Core

## Build Status

### Compilação
- **Status**: SUCESSO
- **Target Frameworks**: .NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8
- **Warnings**: 0
- **Errors**: 0

### Pacote
- `QRCoder.Core.2.0.1.nupkg` (ao publicar)

---

## Resultados dos Testes

### Execução
- **Status**: TODOS APROVADOS
- **Total de Testes**: 502
- **Aprovados**: 502
- **Falhas**: 0
- **Frameworks de teste**: net8.0, net10.0

### Categorias de Testes
- PayloadGeneratorTests
- QRCodeRendererTests
- PngByteQRCodeRendererTests
- SvgQRCodeRendererTests
- ArtQRCodeRendererTests
- AsciiQRCodeRendererTests
- QRGeneratorTests
- ExtensionTests
- ExceptionTests
- BDDTests

---

## Cobertura de Testes

### Resumo Geral
| Métrica | Valor | Status |
|---------|-------|--------|
| **Line Coverage** | 96.9% | Excelente |
| **Branch Coverage** | 92.6% | Excelente |
| **Method Coverage** | 96.0% | Excelente |

### Estatísticas Detalhadas
- **Assemblies**: 1
- **Classes**: 27
- **Files**: 17
- **Coverable Lines**: 5,282
- **Covered Lines**: 5,123
- **Uncovered Lines**: 159
- **Total Branches**: 2,682
- **Covered Branches**: 2,484

---

## Cobertura por Classe

### Excelente (95%+)
- `AbstractQRCode` - 100%
- `DataTooLongException` - 100%
- `CustomExtensions` - 100%
- `SKColorExtensions` - 100%
- `StringValueAttribute` - 100%
- `QRCodeData` - 100%
- `Size` - 100%
- `ArtQRCodeHelper` - 100%
- `AsciiQRCode` - 100%
- `AsciiQRCodeHelper` - 100%
- `Base64QRCode` - 100%
- `Base64QRCodeHelper` - 100%
- `PdfByteQRCode` - 100%
- `PdfByteQRCodeHelper` - 100%
- `PngByteQRCode` - 100%
- `PngByteQRCodeHelper` - 100%
- `SvgQRCodeHelper` - 100%
- `BitmapByteQRCode` - 100%
- `BitmapByteQRCodeHelper` - 100%
- `PostscriptQRCodeHelper` - 100%

### Bom (90-94%)
- `ArtQRCode` - 99.1%
- `SvgQRCode` - 99.4%
- `PostscriptQRCode` - 99.0%
- `QRCode` - 99.3%

### Aceitável (85-89%)
- `PayloadGenerator` - 95.1%
- `QRCodeGenerator` - 96.7%

---

## Ajustes de Qualidade Aplicados

- `CS1591` removido do `NoWarn`; documentação XML adicionada a todas as APIs públicas.
- SonarQube S2184 corrigido (divisão inteira em `PdfByteQRCode`).
- SonarQube S4136 corrigido (agrupamento de overloads `GetGraphic`).
- Badges do README apontam para URLs corretas (SonarCloud, NuGet, CI).
- `CHANGELOG.md` reescrito no padrão Keep a Changelog e SemVer.
