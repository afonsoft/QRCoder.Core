# Devin Configuration — QRCoder.Core

> Referência principal: [AGENTS.md](AGENTS.md)

## Delta Devin

### Ambiente
- .NET 10.0 necessário (também builds para net8.0, netstandard2.1, net48)
- SkiaSharp requer dependências nativas Linux: `libfontconfig1 libfreetype6 libx11-6`

### Comandos Rápidos
```bash
dotnet restore QRCoder.Core.sln
dotnet build QRCoder.Core.sln --configuration Release
dotnet test QRCoder.Core.sln --configuration Release --collect:"XPlat Code Coverage"
```

### PRs
- Branch: `devin/<timestamp>-<descricao>`
- Target: `main`
- CI deve passar antes de notificar o usuário

### Notas
- Testes `net48` não rodam em Linux (sem Windows Desktop)
- SkiaSharp precisa de `LD_LIBRARY_PATH` configurado em alguns ambientes
- Usar `dotnet test -f net10.0` para rodar apenas no TFM disponível
