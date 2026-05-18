# Infraestrutura de Agentes — QRCoder.Core

## Diagrama de Arquivos

```
AGENTS.md                 ← SSoT (≤500 linhas)
CLAUDE.md                 ← Delta para Claude Code
DEVIN.md                  ← Delta para Devin
GEMINI.md                 ← Delta para Gemini CLI
.aiignore                 ← Ignore JetBrains AI
.claudeignore             ← Ignore Claude Code
.cursorignore             ← Ignore Cursor
.devinignore              ← Ignore Devin
.geminiignore             ← Ignore Gemini CLI
.windsurfignore           ← Ignore Windsurf
.agents/
├── CONTEXT.md            ← Estratégias de contexto
├── RULES.md              ← Guardrails
├── MEMORY.md             ← Estado cross-session
├── TOOLS.md              ← Ferramentas e CI/CD
├── WORKFLOWS.md          ← Workflows de automação
├── README.md             ← Este arquivo
└── skills/
    ├── qrcode-development/   ← Desenvolvimento de QR Code
    └── qrcode-testing/       ← Testes de QR Code
rules/
└── csharp-qrcoder.instructions.md  ← Rules C# (applyTo: **/*.cs)
```

## Como Adicionar Nova Skill

1. Criar diretório em `.agents/skills/<nome-kebab-case>/`
2. Criar `SKILL.md` com frontmatter YAML
3. Documentar: What / When / Do NOT
4. Atualizar este README

## Compatibilidade

| Feature | Claude | Devin | Gemini | Cursor | Windsurf |
|---------|--------|-------|--------|--------|----------|
| AGENTS.md | Sim | Sim | Sim | Sim | Sim |
| Skills | Sim | Sim | Sim | Sim | Sim |
| Rules | Sim | Sim | Sim | Sim | Sim |
| Ignore | .claudeignore | .devinignore | .geminiignore | .cursorignore | .windsurfignore |

## Referências

- [AGENTS.md Spec](https://agents.md/)
- [Agent Skills Spec](https://agentskills.io/specification)
- [OpenAI Harness Engineering](https://openai.com/index/harness-engineering/)
