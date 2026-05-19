# QRCoder.Core Agent Memory

Este arquivo é mantido automaticamente pelo agente AI para persistir aprendizados sobre o codebase.

## Decisões Técnicas

| Data | Decisão | Motivo | Alternativas Descartadas |
|------|---------|--------|--------------------------|
| 2026-05 | SkiaSharp como engine de renderização | Cross-platform (Win/Linux/Mac) | System.Drawing (não cross-platform) |
| 2026-05 | ObjectPool para QRCodeData | Performance em alta demanda | Criação por request |
| 2026-05 | Multi-TFM (netstandard2.1, net8.0, net10.0, net48) | Máxima compatibilidade | Apenas net8.0+ |

## Débitos Técnicos

| Item | Impacto | Prioridade |
|------|---------|-----------|
| Cobertura 78% (target 90%) | Qualidade | Média |
| PayloadGenerator sem testes completos | Risco de regressão | Média |

## Lições Aprendidas

| Contexto | Erro | Como Evitar |
|----------|------|-------------|
| Build net48 em Linux | Falha por falta de Windows Desktop | Usar `-f net10.0` para testes locais |
| SkiaSharp em CI | Falta de dependências nativas | Instalar libfontconfig1, libfreetype6, etc. |

## Políticas de Limpeza

- Fatos desatualizados devem ser removidos
- Memórias de branches deletadas devem ser descartadas
