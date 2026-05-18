# TOOLS.md — QRCoder.Core Ferramentas

## Ferramentas de Build

| Ferramenta | Comando | Categoria |
|-----------|---------|-----------|
| dotnet restore | `dotnet restore QRCoder.Core.sln` | Read-only |
| dotnet build | `dotnet build QRCoder.Core.sln --configuration Release` | Execute |
| dotnet test | `dotnet test QRCoder.Core.sln --collect:"XPlat Code Coverage"` | Execute |
| dotnet pack | `dotnet pack --configuration Release` | Execute |

## Ferramentas de Qualidade

| Ferramenta | Uso | Categoria |
|-----------|-----|-----------|
| SonarCloud | Análise de qualidade de código | Execute |
| Codecov | Relatório de cobertura | Execute |
| coverlet | Coleta de cobertura em testes | Execute |

## Ferramentas de CI/CD

| Workflow | Trigger | Descrição |
|---------|---------|-----------|
| `ci-build-test.yml` | push feature/*, PR main | Build + testes + cobertura |
| `publish-all.yml` | tag release | Publicação NuGet |
| `code-quality.yml` | PR | SonarCloud + Qodana |
| `security-scan.yml` | schedule/PR | Scan de segurança |
| `openhands-resolver.yml` | issue label | Auto-fix via OpenHands |
| `auto-pr-from-main.yml` | push main | Sync automático |

## APIs Externas

| API | Uso | Headers |
|-----|-----|---------|
| NuGet.org | Publicação de pacotes | API Key via CI secrets |
| SonarCloud | Qualidade | Token via CI secrets |
| Codecov | Cobertura | Token via CI secrets |
| GitHub API | CI/CD | GITHUB_TOKEN |

## Dependências Nativas (Linux)

```bash
sudo apt-get install -y libfontconfig1 libfreetype6 libx11-6 libxext6 libxrender1 libxtst6
sudo apt-get install -y libglib2.0-0 libgl1-mesa-dev
```
