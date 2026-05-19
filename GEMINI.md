# Gemini CLI Configuration — QRCoder.Core

> Referência principal: [AGENTS.md](AGENTS.md)

## Delta Gemini

### Contexto
Gemini CLI carrega este arquivo automaticamente. O AGENTS.md contém todas as convenções.

### Build
```bash
dotnet restore QRCoder.Core.sln
dotnet build QRCoder.Core.sln --configuration Release
dotnet test QRCoder.Core.sln --configuration Release --collect:"XPlat Code Coverage"
```

### Skills
Disponíveis em `.agents/skills/` — carregar conforme contexto.

### Referências
- `.agents/RULES.md` — guardrails
- `.agents/TOOLS.md` — ferramentas
