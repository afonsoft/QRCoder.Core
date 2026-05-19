# WORKFLOWS.md — QRCoder.Core Automação

## Workflow: Novo Renderizador

### Precondições
- Formato de saída definido
- Renderizador herda de `AbstractQRCode`

### Passos
1. Criar classe em `QRCoder.Core/Renderers/`
2. Herdar de `AbstractQRCode`
3. Implementar método `GetGraphic()`
4. Criar testes em `QRCoder.Core.Tests/Renderers/`
5. Documentar em `docs/en-US/` e `docs/pt-BR/`
6. Atualizar README com novo formato
7. Criar PR

### Critérios de Sucesso
- Testes passam em todos os TFMs
- Cross-platform (sem System.Drawing)
- Documentação bilíngue

---

## Workflow: Novo Payload

### Precondições
- Payload segue padrão da indústria (ex: vCard, WiFi QR)

### Passos
1. Criar classe em `PayloadGenerator`
2. Implementar `ToString()` com formato padronizado
3. Criar testes unitários
4. Documentar exemplos de uso
5. Criar PR

---

## Workflow: Bug Fix

### Passos
1. Reproduzir com teste que falha
2. Implementar correção
3. Verificar que teste passa
4. Rodar suite completa: `dotnet test`
5. Criar PR

---

## Verification Loop

```
Código → Build → Testes → Cobertura → CI → Review
  ↑                                         |
  └──── Ajustar (máx. 2x) ────────────────┘
```

### Execução Local
```bash
dotnet restore QRCoder.Core.sln
dotnet build QRCoder.Core.sln --configuration Release
dotnet test QRCoder.Core.sln --configuration Release --collect:"XPlat Code Coverage"
```

---

## Workflow: Release

### Passos
1. Atualizar versão em `QRCoder.Core.csproj`
2. Atualizar `CHANGELOG.md`
3. Criar tag de release
4. CI publica automaticamente no NuGet

---

## Trigger Conditions

| Evento | Workflow |
|--------|---------|
| Push em `feature/*`, `bug/*`, `hotfix/*` | `ci-build-test.yml` |
| PR para `main` | `ci-build-test.yml` + `code-quality.yml` |
| Tag de release | `publish-all.yml` |
| Push em `main` | `auto-pr-from-main.yml` |
| Schedule | `security-scan.yml` |
