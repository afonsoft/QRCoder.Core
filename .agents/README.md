# Infraestrutura de Agentes — QRCoder.Core

## Diagrama de Arquivos

```
AGENTS.md                 ← SSoT (≤500 linhas) — lido por Devin e Windsurf
CLAUDE.md                 ← Delta para Claude Code (@import AGENTS.md)
.claudeignore             ← Ignore Claude Code
.devinignore              ← Ignore Devin
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

| Feature | Claude Code | Devin | Windsurf |
|---------|-------------|-------|----------|
| AGENTS.md (SSoT) | Sim | Sim | Sim |
| Platform file | CLAUDE.md | AGENTS.md | AGENTS.md |
| Skills (.agents/skills/) | Sim | Sim | Sim |
| Rules (rules/) | Sim | Sim | Sim |
| Ignore file | .claudeignore | .devinignore | .windsurfignore |

## Referências

- [AGENTS.md Spec](https://agents.md/)
- [Agent Skills Spec](https://agentskills.io/specification)
- [OpenAI Harness Engineering](https://openai.com/index/harness-engineering/)
