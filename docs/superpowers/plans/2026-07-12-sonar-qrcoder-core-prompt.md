# Prompt Executivo — Correção SonarCloud QRCoder.Core

Você é um engenheiro .NET sênior trabalhando no repositório `afonsoft/QRCoder.Core`.
A tarefa é corrigir as 185 issues abertas do SonarCloud, organizadas em 6 fases e 10 lotes, respeitando a API pública e o fluxo de dados `payload → bits → módulos → renderização`.

## Contexto da arquitetura

- `QRCoder.Core/Generators/QRCodeGenerator.cs`: engine que transforma texto/payload em `QRCodeData`.
- `QRCoder.Core/Generators/PayloadGenerator.cs`: geradores de payload (WiFi, vCard, SEPA, Bitcoin, etc.).
- `QRCoder.Core/Renderers/*.cs`: renderizam `QRCodeData` para PNG, SVG, PDF, ASCII, Base64, Postscript, ArtQR.
- `QRCoder.Core/Models/QRCodeData.cs`: modelo de dados do QR code.
- `QRCoder.Core.Tests/`: testes xUnit/Shouldly.
- `.github/workflows/`: CI/CD (segurança, SonarCloud, Snyk, Qodana).

## Stack e restrições

- .NET Standard 2.1 / .NET 8 / .NET 10 / .NET Framework 4.8
- C# 10
- SkiaSharp 3.119.0
- xUnit + Shouldly + coverlet
- GitHub Actions
- SonarCloud

## Instruções obrigatórias

1. **Nunca modifique** `main`, `master` ou `develop` diretamente.
2. Crie a branch de trabalho a partir de `feature/devin-20260712-sonar-quality` (atualize com `main` se necessário).
3. Use a nomenclatura `feature/devin-YYYYMMDD-<descricao-curta>`.
4. Para cada fase/lote, crie a branch descrita no plano e abra um PR para a branch de integração.
5. Antes de cada commit, execute:
   ```bash
   dotnet build QRCoder.Core.sln
   dotnet test QRCoder.Core.sln
   ```
6. Preserve a API pública; quando não for possível, use `[Obsolete]` com mensagem explicativa.
7. Use `// NOSONAR` **apenas** como último recurso para preservar compatibilidade.
8. Não altere `/.github/workflows` exceto na Fase 5 e apenas após revisão de segurança.
9. Código em inglês; documentação/comentários em pt-BR/inglês conforme padrão.
10. Não commitar secrets, tokens ou `.env`.

## Padrões de correção por regra

- `S2933`/`S3604`: campos só atribuídos no construtor → `readonly`, remova inicializador redundante.
- `S2325`: método não usa estado de instância → `static`.
- `S3260`: classe privada não derivada → `sealed`.
- `S1643`: concatenação em loop → `StringBuilder`.
- `S3267`: loop simples com `Select`/`Where` → substituir por LINQ.
- `S3878`: `new[] { ... }` com `TrimEnd`/`Contains` quando há overload com `params` → passe elementos diretamente.
- `S1192`: literal repetido → `const`.
- `S6610`: `StartsWith(string)` com `char` quando aplicável.
- `S2184`: operação `int / int` que deveria ser flutuante → converta operandos para `float`/`double`.
- `S112`/`S3928`: `throw new Exception`/`ArgumentOutOfRangeException` genérico → exceções tipadas do projeto.
- `S3427`: overloads com parâmetros opcionais ocultos → remova defaults ou diferencie nomes.
- `S4136`: overloads devem ser adjacentes.
- `S3881`: implemente `protected virtual void Dispose(bool disposing)` e chame `Dispose(true)` + `GC.SuppressFinalize(this)`.
- `S101`/`S2342`: renomeie tipos internos; para API pública, suprima com `// NOSONAR` ou crie aliases `[Obsolete]`.
- `S107`/`S3776`: reduza parâmetros com classes `Options` e extraia helpers para baixar complexidade cognitiva.
- `S7630`/`S7636`/`S7637`/`S2612`/`S1135`: workflows — pin SHA, use variáveis de ambiente, não expanda secrets, revise permissões, remova `TODO`.
- `S2699`: teste sem assertion → adicione `ShouldNotBeNull()` ou assertion equivalente.

## Critérios de aceitação

- `dotnet build QRCoder.Core.sln` passa para todos os TFM.
- `dotnet test QRCoder.Core.sln` passa (exceto os 10 testes de hash SVG já conhecidos como frágeis).
- O número de issues SonarCloud diminui a cada lote.
- Nenhum novo warning crítico é introduzido.

## Fases e branches

1. `feature/devin-20260712-sonar-style-qrcodegenerator`
2. `feature/devin-20260712-sonar-style-payloadgenerator`
3. `feature/devin-20260712-sonar-style-renderers`
4. `feature/devin-20260712-sonar-style-extensions`
5. `feature/devin-20260712-sonar-exceptions`
6. `feature/devin-20260712-sonar-naming`
7. `feature/devin-20260712-sonar-complexity-generators`
8. `feature/devin-20260712-sonar-complexity-renderers`
9. `feature/devin-20260712-sonar-workflows`
10. `feature/devin-20260712-sonar-tests`

Branch de integração: `feature/devin-20260712-sonar-quality`.
