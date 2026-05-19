---
name: qrcode-testing
description: >
  What: Guia para testes unitários do QRCoder.Core usando xUnit, Shouldly e coverlet.
  When: Ao escrever testes, aumentar cobertura, debugar falhas de teste, ou configurar test runners.
  Do NOT: Não usar para desenvolvimento de features (ver qrcode-development) ou CI/CD.
---

## Contexto

QRCoder.Core usa xUnit como framework de testes, Shouldly para assertions legíveis, e coverlet para cobertura de código. Os testes estão em `QRCoder.Core.Tests/`.

## Atuação

### Estrutura de Testes
```
QRCoder.Core.Tests/
├── Generators/         # Testes do QRCodeGenerator
├── Renderers/          # Testes por renderizador
├── Extensions/         # Testes de extensões
├── Models/             # Testes de modelos
├── Exceptions/         # Testes de exceções
├── Helpers/            # Utilitários de teste
└── assets/             # Arquivos de referência (imagens, SVGs)
```

### Padrões
- BDD em português: Dado/Quando/Então
- Uma assertion por teste quando possível
- Testes de renderização: comparar output com referência em `assets/`
- Testar todos os níveis ECC: L, M, Q, H

### Comandos
```bash
# Todos os testes
dotnet test QRCoder.Core.sln --configuration Release

# Com cobertura
dotnet test QRCoder.Core.sln --collect:"XPlat Code Coverage"

# Apenas net10.0 (Linux)
dotnet test QRCoder.Core.Tests/ -f net10.0

# Teste específico
dotnet test --filter "FullyQualifiedName~QRCodeGeneratorTests"
```

## Restrições

- Não modificar testes existentes para forçar passagem
- Testes `net48` não rodam em Linux (sem Windows Desktop)
- Cobertura não pode diminuir (baseline: 78%)
- Não commitar arquivos de TestResults

## Exemplos

```csharp
[Fact]
public void Dado_TextoValido_Quando_GerarQRCode_Entao_DeveRetornarDadosValidos()
{
    var generator = new QRCodeGenerator();
    var data = generator.CreateQrCode("Test", QRCodeGenerator.ECCLevel.M);
    data.ShouldNotBeNull();
    data.ModuleMatrix.ShouldNotBeEmpty();
}
```
