# AGENTS.md — QRCoder.Core

## Missão

QRCoder.Core é uma biblioteca .NET cross-platform para geração e renderização de QR Codes usando SkiaSharp. Suporta múltiplos formatos de saída (PNG, SVG, PDF, ASCII, Base64, Postscript, ArtQR) e payloads padronizados (WiFi, vCard, Bitcoin, SEPA, etc.). Qualquer agente LLM que trabalhe neste repositório deve seguir as convenções aqui documentadas.

## Stack Tecnológica

| Camada | Tecnologia | Versão |
|--------|-----------|--------|
| Runtime | .NET | Standard 2.1 / 8.0 / 10.0 / FW 4.8 |
| Linguagem | C# | 10.0 |
| Renderização | SkiaSharp | 3.119.0 |
| Pool | Microsoft.Extensions.ObjectPool | 9.0.7 |
| Testes | xUnit + Shouldly + coverlet | — |
| CI/CD | GitHub Actions | — |
| Qualidade | SonarCloud + Codecov | — |
| Licença | MIT | — |

## Estrutura do Projeto

```
QRCoder.Core/                  # Biblioteca principal
├── Abstractions/              # Interfaces e classes base (AbstractQRCode)
├── Models/                    # QRCodeData, módulos, masking
├── Generators/                # QRCodeGenerator (engine central)
├── Renderers/                 # Renderizadores por formato
│   ├── QRCode.cs              # SKBitmap (SkiaSharp)
│   ├── PngByteQRCode.cs       # PNG puro (.NET)
│   ├── SvgQRCode.cs           # SVG string
│   ├── PdfByteQRCode.cs       # PDF byte array
│   ├── ASCIIQRCode.cs         # ASCII art
│   ├── Base64QRCode.cs        # Base64 image
│   ├── PostscriptQRCode.cs    # Postscript/EPS
│   ├── ArtQRCode.cs           # QR artístico
│   └── BitmapByteQRCode.cs    # BMP bytes
├── Extensions/                # Métodos de extensão
├── Exceptions/                # Exceções tipadas
└── Assets/                    # Ícones e recursos NuGet
QRCoder.Core.Tests/            # Testes unitários (300+)
├── Generators/                # Testes do QRCodeGenerator
├── Renderers/                 # Testes por renderizador
├── Extensions/                # Testes de extensões
├── Models/                    # Testes de modelos
├── Exceptions/                # Testes de exceções
├── Helpers/                   # Utilitários de teste
└── assets/                    # Arquivos de referência
docs/                          # Documentação bilíngue
├── en-US/                     # Guia de uso (inglês)
└── pt-BR/                     # Guia de uso (português)
.agents/                       # Infraestrutura de agentes
```

## Caminhos por Plataforma

| Plataforma | Config Principal | Skills | Rules |
|-----------|-----------------|--------|-------|
| Todos | `AGENTS.md` | `.agents/skills/` | `.agents/RULES.md`, `rules/` |
| Claude Code | `CLAUDE.md` | auto-loaded | `.agents/RULES.md` |
| Devin | `DEVIN.md` | `.agents/skills/` | `.agents/RULES.md` |
| Gemini CLI | `GEMINI.md` | `.agents/skills/` | `.agents/RULES.md` |

## Comandos de Build

```bash
# Restaurar dependências
dotnet restore QRCoder.Core.sln

# Build completo
dotnet build QRCoder.Core.sln --configuration Release

# Testes com cobertura
dotnet test QRCoder.Core.sln --configuration Release \
  --collect:"XPlat Code Coverage" \
  --results-directory TestResults

# Apenas testes .NET 10
dotnet test QRCoder.Core.Tests/ -f net10.0 --configuration Release
```

## Padrões de Código

### DO (Faça)
- Seguir Clean Architecture: Abstractions → Models → Generators → Renderers
- Documentação XML em todas as APIs públicas
- Testes para todo novo renderizador ou payload
- Manter compatibilidade cross-platform (SkiaSharp, sem System.Drawing)
- Documentação bilíngue (pt-BR + en-US)
- Usar `ObjectPool` para buffers de matriz reutilizáveis
- Usar `System.Buffers` e `System.Memory` para performance

### DON'T (Não Faça)
- Não usar System.Drawing (incompatível cross-platform)
- Não reduzir cobertura de testes (78%+ baseline)
- Não quebrar compatibilidade com .NET Standard 2.1
- Não commitar binários nativos (`.so`, `.dylib`, `.dll`)
- Não hardcodar caminhos de plataforma

## Hard Rules

1. **Testes obrigatórios**: CI falha se qualquer teste quebrar
2. **Cobertura mínima**: não pode diminuir em relação ao baseline (78%)
3. **Cross-platform**: deve funcionar em Windows, Linux e macOS
4. **Secrets**: nunca commitar `.env`, tokens ou API keys
5. **Compatibilidade**: manter suporte a .NET Standard 2.1

## Soft Rules

1. Alterar `QRCodeGenerator.cs` → requer testes extensivos
2. Adicionar dependência NuGet → verificar compatibilidade multi-TFM
3. Alterar formatos de saída → manter backward compatibility
4. Modificar CI workflows → requer revisão

## Agent Loop

> Padrão: **ReAct** (Observe → Think → Act → Verify)

```
1. Receber tarefa
2. Carregar AGENTS.md + RULES.md
3. Analisar código relevante
4. Implementar alteração
5. Executar testes: dotnet test
6. Verificar cobertura
7. Criar PR
```

## Response Style

- Idioma: Português (pt-BR) para docs; inglês para código
- Conciso e direto
- Commits: `feat:`, `fix:`, `test:`, `docs:`, `refactor:`

## Referências

- `.agents/CONTEXT.md` — Estratégias de contexto
- `.agents/RULES.md` — Guardrails
- `.agents/TOOLS.md` — Ferramentas
- `.agents/WORKFLOWS.md` — Automação
- `.agents/skills/` — Skills on-demand
- `rules/` — Rules por domínio
- `docs/` — Documentação bilíngue
