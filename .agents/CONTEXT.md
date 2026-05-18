# Context Engineering — QRCoder.Core

## Estratégias de Carregamento

| Tipo | Quando | Arquivos |
|------|--------|----------|
| **Always-on** | Sempre carregado | `AGENTS.md`, `.agents/RULES.md` |
| **Pattern-matched** | Por tipo de arquivo | `rules/*.instructions.md` (via `applyTo`) |
| **On-demand** | Quando solicitado | `.agents/skills/`, `docs/`, `.agents/MEMORY.md` |
| **Progressive disclosure** | Arquivos grandes | Headers → seções relevantes |

## Hierarquia de Prioridade

1. Instruções do usuário (chat/prompt)
2. `AGENTS.md` (SSoT)
3. Arquivo de plataforma (`CLAUDE.md`, `DEVIN.md`, `GEMINI.md`)
4. `.agents/RULES.md`
5. `rules/*.instructions.md`
6. `.agents/skills/`
7. `.agents/MEMORY.md`

## Token Budget

- Reservar 20% do contexto para output
- `AGENTS.md` ≤ 500 linhas
- Skills: carregar apenas as relevantes

## Chunking

- `QRCodeGenerator.cs`: arquivo grande — carregar por método/seção
- Testes: agrupar por renderizador

## Mapa de Diretórios

```
Prioridade alta:
  QRCoder.Core/Generators/
  QRCoder.Core/Renderers/
  QRCoder.Core/Abstractions/
  QRCoder.Core.Tests/

Prioridade média:
  QRCoder.Core/Models/
  QRCoder.Core/Extensions/
  docs/

Prioridade baixa:
  QRCoder.Core/Assets/
  Docs/ (SHFB generated)
  .vscode/
```
