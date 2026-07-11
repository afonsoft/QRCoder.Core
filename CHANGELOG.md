# Changelog

Todas as alterações notáveis deste projeto serão documentadas neste arquivo.

O formato é baseado em [Keep a Changelog](https://keepachangelog.com/pt-BR/1.0.0/),
e este projeto adere à [Semantic Versioning](https://semver.org/lang/pt-BR/spec/v2.0.0.html).

## [Unreleased]

## [2.0.1] - 2026-07-11

### Adicionado
- Documentação XML em todas as APIs públicas da biblioteca.
- Seções de estrutura do repositório, visão de negócio e visão técnica nos READMEs.
- `BDDTests.cs` com testes no estilo Dado/Quando/Então para validar geração e renderização de QR Codes.

### Alterado
- Versão do pacote alterada de `2.0.0` para `2.0.1`.
- Badges de CI, NuGet, SonarCloud e Codecov corrigidos/atualizados em `README.md`, `README.pt-br.md` e `readme.md`.
- Links do SonarCloud ajustados para o projeto correto (`afonsoft_QRCoder.Core`).
- `CHANGELOG.md` reescrito no padrão Keep a Changelog e SemVer.

### Corrigido
- SonarQube S2184: divisão inteira no cálculo do tamanho de mídia do `PdfByteQRCode`.
- SonarQube S4136: agrupamento dos overloads de `GetGraphic` em `QRCode` e `PdfByteQRCode`.
- `CS1591` removido do `NoWarn` do `QRCoder.Core.csproj`; build agora é limpo sem warnings de documentação.

## [2.0.0] - 2026-05-10

### Alterado
- Reorganização do código com separação em camadas inspiradas em SOLID e Clean Architecture.
- Atualização dos frameworks-alvo para .NET Standard 2.1, .NET 8.0, .NET 10.0 e .NET Framework 4.8.
- Documentação multi-idioma (en-US padrão + pt-BR).
- Correção de testes e estabilização do build.

## [1.0.8] - 2026-02-18

### Adicionado
- Manipulação de bibliotecas nativas do SkiaSharp para CI no Linux.
- Workflows de publicação consolidados e simplificados.

### Alterado
- Atualização de dependências do GitHub Actions.

## [1.0.5] - 2025-07-13

### Alterado
- Migração da renderização para SkiaSharp, removendo a dependência de `System.Drawing`.
- Ajustes gerais no projeto, build e documentação.

## [1.0.3] - 2024-04-01

### Corrigido
- Correções nas Actions do GitHub.

### Alterado
- Atualização de dependências (`codecov/codecov-action`, `NuGet/setup-nuget`).

## [1.0.2] - 2024-03-12

### Alterado
- Ajustes de compatibilidade com .NET Framework 4.8 e netstandard2.1.
- Melhorias no XML de documentação.

## [1.0.1] - 2023-12-22

### Adicionado
- Versão inicial do QRCoder.Core com suporte a múltiplos frameworks e QR Code generation.

## Migration Guide

### De 2.0.0 para 2.0.1
- Nenhuma mudança quebradora. A versão foca em documentação, qualidade de código e correções de badges.

### De 1.0.x para 2.0.0
- Os namespaces e a estrutura de pastas foram reorganizados. Atualize os `using` conforme a nova estrutura (`Abstractions`, `Models`, `Generators`, `Renderers`).
- A biblioteca passou a depender exclusivamente do SkiaSharp para renderização cross-platform.

## System Requirements

- **.NET**: .NET Standard 2.1 ou superior
- **.NET 8.0+**: Recomendado para melhor desempenho
- **.NET Framework 4.8**: Suporte Windows legado
- **SkiaSharp**: Dependências nativas gerenciadas automaticamente
