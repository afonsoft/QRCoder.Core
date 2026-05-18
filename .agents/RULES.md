# RULES.md — QRCoder.Core Guardrails

## Hard Rules (bloqueio imediato)

| # | Regra | Verificação |
|---|-------|-------------|
| H1 | Todos os testes devem passar antes do merge | CI: `dotnet test` |
| H2 | Cobertura de código não pode diminuir (baseline: 78%) | CI: coverlet |
| H3 | Compatibilidade cross-platform obrigatória (Win/Linux/Mac) | CI: ubuntu-latest |
| H4 | Manter suporte .NET Standard 2.1 | Build multi-TFM |
| H5 | Nunca commitar secrets | `.gitignore` |
| H6 | Não usar System.Drawing (deprecated, não cross-platform) | Code review |
| H7 | Não push direto em `main` | Branch protection |

## Soft Rules (warning + confirmação)

| # | Regra | Ação |
|---|-------|------|
| S1 | Alterar `QRCodeGenerator.cs` (engine central) | Testes extensivos |
| S2 | Adicionar dependência NuGet | Verificar compatibilidade multi-TFM |
| S3 | Alterar formato de saída de renderizadores | Backward compatibility |
| S4 | Modificar CI workflows | Requer revisão |
| S5 | Alterar versão do SkiaSharp | Testar em todas as plataformas |

## Permissões por Ambiente

| Ambiente | Read | Write | Execute |
|----------|------|-------|---------|
| **dev** | Livre | Livre | Sandbox |
| **CI** | Livre | Via PR | Automático |
| **NuGet** | — | — | Via release workflow |

## Tool Permissions

- **Read-only**: busca, navegação, análise de código
- **Write**: edição via PR
- **Execute**: build, test em sandbox
- **Publish**: apenas via CI/CD

## Arquivos Imutáveis

```
bin/
obj/
Docs/ (SHFB generated)
.git/
.vs/
.vscode/
packages/
TestResults/
```
