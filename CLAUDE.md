# Claude Code Configuration — QRCoder.Core

@import AGENTS.md

## Delta Claude

### Carregamento Automático
Claude Code carrega este arquivo automaticamente. O `@import` acima carrega o AGENTS.md como SSoT.

### Memory
Claude Code mantém memória automática em `.agents/MEMORY.md`.

### Skills
Skills em `.agents/skills/` — carregadas sob demanda pelo contexto.

### Guardrails
- `.agents/RULES.md` — Hard/Soft rules
- `rules/*.instructions.md` — Rules por domínio
- `.claudeignore` — Arquivos a ignorar
