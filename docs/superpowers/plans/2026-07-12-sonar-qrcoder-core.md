# Plano de Execução — SonarCloud QRCoder.Core

> **For agentic workers:** REQUIRED SUB-SKILL: Use `superpowers:subagent-driven-development` (recommended) or `superpowers:executing-plans` to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Eliminar as 185 issues abertas do SonarCloud no projeto `afonsoft_QRCoder.Core` (quality gate em `ERROR`) sem alterar o comportamento público da biblioteca, mantendo compatibilidade com .NET Standard 2.1 / .NET 8 / .NET 10 / .NET Framework 4.8.

**Architecture:** O repositório é dividido em camadas: `Abstractions` (ciclo de vida), `Models` (QRCodeData), `Generators` (`QRCodeGenerator` + `PayloadGenerator`) e `Renderers` (formatos de saída). As correções devem seguir o fluxo de dados: payload → bits → módulos → renderização, preservando a API pública e evitando regressões nos testes.

**Tech Stack:** .NET Standard 2.1 / .NET 8 / .NET 10 / .NET Framework 4.8, C# 10, SkiaSharp 3.119.0, xUnit + Shouldly + coverlet, GitHub Actions, SonarCloud.

---

## Resumo do SonarCloud

- **Projeto:** `afonsoft_QRCoder.Core`
- **Branch analisado:** `main`
- **Quality Gate:** `ERROR`
- **Issues abertas:** 185
  - BLOCKER: 4
  - CRITICAL: 20
  - MAJOR: 80
  - MINOR: 73
  - INFO: 8
- **Bugs:** 3 | **Code Smells:** 172 | **Vulnerabilities:** 10 | **Security Hotspots:** 11
- **ncloc:** 6.210 | **Cobertura duplicação:** 0,2%

## Estratégia de Branch e PRs

- **Branch de integração:** `feature/devin-20260712-sonar-quality` (criada a partir de `main`).
- **Target dos PRs por fase:** a branch de integração; ao final, a integração é promovida a `main` via PR de consolidação (a ser aprovado pelo mantenedor).
- **Nomenclatura:** `feature/devin-YYYYMMDD-<descricao-curta>` conforme regras globais.
- **Não alterar** `main`, `master` ou `develop` diretamente; `/.github/workflows` só na Fase 5 com revisão de segurança.

## Fases, Lotes e Branches

### Fase 1 — Estilo e otimizações seguras

**Branch raiz da fase:** `feature/devin-20260712-sonar-style`

**Lotes:**

#### Lote 1.1: QRCodeGenerator — campos readonly, StringBuilder, classes sealed, remove comentários obsoletos

- **Branch:** `feature/devin-20260712-sonar-style-qrcodegenerator`
- **Arquivos:** `QRCoder.Core/Generators/QRCodeGenerator.cs`
- **Issues:** 24

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 65 | MINOR | `csharpsquid:S2325` | `public QRCodeData CreateQrCode(PayloadGenerator.Payload payload)` | Make 'CreateQrCode' a static method. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 77 | MINOR | `csharpsquid:S2325` | `public QRCodeData CreateQrCode(PayloadGenerator.Payload payload, ECCLevel eccLevel)` | Make 'CreateQrCode' a static method. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 93 | MINOR | `csharpsquid:S2325` | `public QRCodeData CreateQrCode(string plainText, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1)` | Make 'CreateQrCode' a static method. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 105 | MINOR | `csharpsquid:S2325` | `public QRCodeData CreateQrCode(byte[] binaryData, ECCLevel eccLevel)` | Make 'CreateQrCode' a static method. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 197 | MINOR | `csharpsquid:S1643` | `public static QRCodeData GenerateQrCode(byte[] binaryData, ECCLevel eccLevel)` | Use a StringBuilder instead. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 214 | MINOR | `csharpsquid:S1643` | `private static QRCodeData GenerateQrCode(string bitString, ECCLevel eccLevel, int version)` | Use a StringBuilder instead. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 259 | MINOR | `csharpsquid:S3267` | `private static QRCodeData GenerateQrCode(string bitString, ECCLevel eccLevel, int version)` | Loop should be simplified by calling Select(codeBlock => codeBlock.CodeWords)) |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 266 | MINOR | `csharpsquid:S3267` | `private static QRCodeData GenerateQrCode(string bitString, ECCLevel eccLevel, int version)` | Loop should be simplified by calling Select(codeBlock => codeBlock.ECCWords)) |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 369 | MINOR | `csharpsquid:S1643` | `private static string ReverseString(string inp)` | Use a StringBuilder instead. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 601 | MINOR | `csharpsquid:S3267` | `public static void PlaceAlignmentPatterns(ref QRCodeData qrCode, List<Point> alignmentPatternLocations, ref List<SKRectI> blockedModules)` | Loops should be simplified using the "Where" LINQ method |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 650 | MINOR | `csharpsquid:S3267` | `private static bool IsBlocked(SKRectI r1, List<SKRectI> blockedModules)` | Loops should be simplified using the "Where" LINQ method |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 665 | MAJOR | `csharpsquid:S1172` | `public static bool Pattern2(int x, int y)` | Remove this unused method parameter 'x'. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 670 | MAJOR | `csharpsquid:S1172` | `public static bool Pattern3(int x, int y)` | Remove this unused method parameter 'y'. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1038 | MINOR | `csharpsquid:S1192` | `private static bool IsValidISO(string input)` | Define a constant instead of using this literal 'ISO-8859-1' 5 times. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1061 | MINOR | `csharpsquid:S1643` | `private static string PlainTextToBinaryNumeric(string plainText)` | Use a StringBuilder instead. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1084 | MINOR | `csharpsquid:S1643` | `private static string PlainTextToBinaryAlphanumeric(string plainText)` | Use a StringBuilder instead. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1094 | MINOR | `csharpsquid:S2325` | `private string PlainTextToBinaryECI(string plainText)` | Make 'PlainTextToBinaryECI' a static method. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1100 | MINOR | `csharpsquid:S1643` | `private string PlainTextToBinaryECI(string plainText)` | Use a StringBuilder instead. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1132 | MINOR | `csharpsquid:S1643` | `private static string PlainTextToBinaryByte(string plainText, EciMode eciMode, bool utf8BOM, bool forceUtf8)` | Use a StringBuilder instead. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1536 | MINOR | `csharpsquid:S3260` | `private class Polynom {` | Private classes which are not derived in the current assembly should be marked as 'sealed'. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1548 | MAJOR | `csharpsquid:S125` | `public override string ToString()` | Remove this commented out code. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1554 | MINOR | `csharpsquid:S3878` | `public override string ToString()` | Remove this array creation and simply pass the elements. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1558 | MINOR | `csharpsquid:S3260` | `private class Point {` | Private classes which are not derived in the current assembly should be marked as 'sealed'. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1570 | MINOR | `csharpsquid:S3260` | `private class SKRectI {` | Private classes which are not derived in the current assembly should be marked as 'sealed'. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add QRCoder.Core/Generators/QRCodeGenerator.cs
git commit -m "fix(sonar): resolver QRCodeGenerator — campos readonly, StringBuilder, classes se"
```

#### Lote 1.2: PayloadGenerator — readonly, static, sealed, move métodos, comentários, catch vazio

- **Branch:** `feature/devin-20260712-sonar-style-payloadgenerator`
- **Arquivos:** `QRCoder.Core/Generators/PayloadGenerator.cs`
- **Issues:** 69

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 663 | MINOR | `csharpsquid:S3878` | `public override string ToString()` | Remove this array creation and simply pass the elements. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 946 | CRITICAL | `csharpsquid:S4487` | `field ultimateCreditor: private readonly Contact creditor, ultimateCreditor, debitor;` | Remove this unread private field 'ultimateCreditor' or refactor the code to use its value. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 948 | CRITICAL | `csharpsquid:S4487` | `field requestedDateOfPayment: private readonly DateTime? requestedDateOfPayment;` | Remove this unread private field 'requestedDateOfPayment' or refactor the code to use its value. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1082 | CRITICAL | `csharpsquid:S4487` | `field referenceTextType: private readonly ReferenceTextType? referenceTextType;` | Remove this unread private field 'referenceTextType' or refactor the code to use its value. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1199 | MAJOR | `csharpsquid:S2933` | `field iban: private string iban;` | Make 'iban' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1200 | MAJOR | `csharpsquid:S2933` | `field ibanType: private IbanType ibanType;` | Make 'ibanType' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1290 | MAJOR | `csharpsquid:S2933` | `field br: private string br = "\r\n";` | Make 'br' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | MAJOR | `csharpsquid:S2933` | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'name' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | MAJOR | `csharpsquid:S2933` | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'streetOrAddressline1' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | MAJOR | `csharpsquid:S2933` | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'houseNumberOrAddressline2' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | MAJOR | `csharpsquid:S2933` | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'zipCode' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | MAJOR | `csharpsquid:S2933` | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'city' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | MAJOR | `csharpsquid:S2933` | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'country' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1292 | MAJOR | `csharpsquid:S2933` | `field adrType: private AddressType adrType;` | Make 'adrType' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1303 | INFO | `csharpsquid:S1133` | `public class Contact {` | Do not forget to remove this deprecated code someday. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1315 | INFO | `csharpsquid:S1133` | `public class Contact {` | Do not forget to remove this deprecated code someday. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1605 | MAJOR | `csharpsquid:S2933` | `field br: private string br = "\n";` | Make 'br' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 2050 | MINOR | `csharpsquid:S1192` | `public override string ToString()` | Define a constant instead of using this literal 'ddMMyyyy' 4 times. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 2827 | MAJOR | `csharpsquid:S1123` | `public enum AuthorityType {` | Add an explanation. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 2827 | INFO | `csharpsquid:S1133` | `public enum AuthorityType {` | Do not forget to remove this deprecated code someday. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 2838 | MAJOR | `csharpsquid:S1123` | `public enum AuthorityType {` | Add an explanation. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 2838 | INFO | `csharpsquid:S1133` | `public enum AuthorityType {` | Do not forget to remove this deprecated code someday. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 2849 | MAJOR | `csharpsquid:S1123` | `public enum AuthorityType {` | Add an explanation. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 2849 | INFO | `csharpsquid:S1133` | `public enum AuthorityType {` | Do not forget to remove this deprecated code someday. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 2990 | INFO | `csharpsquid:S1133` | `public class OneTimePassword : Payload {` | Do not forget to remove this deprecated code someday. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3055 | INFO | `csharpsquid:S1133` | `public enum OneTimePasswordAuthAlgorithm {` | Do not forget to remove this deprecated code someday. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3174 | CRITICAL | `csharpsquid:S4487` | `field method: private readonly Method method;` | Remove this unread private field 'method' or refactor the code to use its value. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3177 | MAJOR | `csharpsquid:S2933` | `field encryptionTexts: private Dictionary<string, string> encryptionTexts = new Dictionary<string, string>() {` | Make 'encryptionTexts' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3256 | MAJOR | `csharpsquid:S2933` | `field UrlEncodeTable: private Dictionary<string, string> UrlEncodeTable = new Dictionary<string, string>` | Make 'UrlEncodeTable' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3640 | MAJOR | `csharpsquid:S2933` | `field _payerName: private string _payerName = "";` | Make '_payerName' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3640 | MINOR | `csharpsquid:S3604` | `field _payerName: private string _payerName = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3641 | MAJOR | `csharpsquid:S2933` | `field _payerAddress: private string _payerAddress = "";` | Make '_payerAddress' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3641 | MINOR | `csharpsquid:S3604` | `field _payerAddress: private string _payerAddress = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3642 | MAJOR | `csharpsquid:S2933` | `field _payerPlace: private string _payerPlace = "";` | Make '_payerPlace' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3642 | MINOR | `csharpsquid:S3604` | `field _payerPlace: private string _payerPlace = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3643 | MAJOR | `csharpsquid:S2933` | `field _amount: private string _amount = "";` | Make '_amount' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3643 | MINOR | `csharpsquid:S3604` | `field _amount: private string _amount = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3644 | MAJOR | `csharpsquid:S2933` | `field _code: private string _code = "";` | Make '_code' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3644 | MINOR | `csharpsquid:S3604` | `field _code: private string _code = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3645 | MAJOR | `csharpsquid:S2933` | `field _purpose: private string _purpose = "";` | Make '_purpose' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3645 | MINOR | `csharpsquid:S3604` | `field _purpose: private string _purpose = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3646 | MAJOR | `csharpsquid:S2933` | `field _deadLine: private string _deadLine = "";` | Make '_deadLine' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3647 | MAJOR | `csharpsquid:S2933` | `field _recipientIban: private string _recipientIban = "";` | Make '_recipientIban' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3647 | MINOR | `csharpsquid:S3604` | `field _recipientIban: private string _recipientIban = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3648 | MAJOR | `csharpsquid:S2933` | `field _recipientName: private string _recipientName = "";` | Make '_recipientName' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3648 | MINOR | `csharpsquid:S3604` | `field _recipientName: private string _recipientName = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3649 | MAJOR | `csharpsquid:S2933` | `field _recipientAddress: private string _recipientAddress = "";` | Make '_recipientAddress' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3649 | MINOR | `csharpsquid:S3604` | `field _recipientAddress: private string _recipientAddress = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3650 | MAJOR | `csharpsquid:S2933` | `field _recipientPlace: private string _recipientPlace = "";` | Make '_recipientPlace' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3650 | MINOR | `csharpsquid:S3604` | `field _recipientPlace: private string _recipientPlace = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3651 | MAJOR | `csharpsquid:S2933` | `field _recipientSiModel: private string _recipientSiModel = "";` | Make '_recipientSiModel' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3651 | MINOR | `csharpsquid:S3604` | `field _recipientSiModel: private string _recipientSiModel = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3652 | MAJOR | `csharpsquid:S2933` | `field _recipientSiReference: private string _recipientSiReference = "";` | Make '_recipientSiReference' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3652 | MINOR | `csharpsquid:S3604` | `field _recipientSiReference: private string _recipientSiReference = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3672 | MINOR | `csharpsquid:S2325` | `private string LimitLength(string value, int maxLength)` | Make 'LimitLength' a static method. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3720 | MAJOR | `csharpsquid:S2589` | `public SlovenianUpnQr(string payerName, string payerAddress, string payerPlace, string recipientName, string recipientAddress, string recipientPlace, string recipientIban, string description, double amount, DateTime? deadline, string recipientSiModel = "SI99", string recipientSiReference = "", string code = "OTHR")` | Remove this unnecessary check for null. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3729 | MINOR | `csharpsquid:S2325` | `private string FormatAmount(double amount)` | Make 'FormatAmount' a static method. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3797 | MAJOR | `csharpsquid:S2933` | `field characterSet: private CharacterSets characterSet;` | Make 'characterSet' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3799 | MAJOR | `csharpsquid:S2933` | `field mFields: private MandatoryFields mFields;` | Make 'mFields' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3800 | MAJOR | `csharpsquid:S2933` | `field oFields: private OptionalFields oFields;` | Make 'oFields' 'readonly'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3801 | MINOR | `csharpsquid:S1450` | `field separator: private string separator = "\|";` | Remove the field 'separator' and declare it as a local variable in the relevant methods. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3891 | MINOR | `csharpsquid:S3267` | `private string DetermineSeparator()` | Loops should be simplified using the "Where" LINQ method |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3958 | MINOR | `csharpsquid:S3267` | `private static string ValidateInput(string input, string fieldname, string[] patterns, string errorText = null)` | Loops should be simplified using the "Where" LINQ method |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3966 | MINOR | `csharpsquid:S3260` | `private class MandatoryFields {` | Private classes which are not derived in the current assembly should be marked as 'sealed'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 4457 | MINOR | `csharpsquid:S3398` | `public class RussiaPaymentOrderException : Exception {` | Move this method inside 'Iban'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 4466 | MAJOR | `csharpsquid:S108` | `private static bool IsValidQRIban(string iban)` | Either remove or fill this block of code. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 4466 | MINOR | `csharpsquid:S2486` | `private static bool IsValidQRIban(string iban)` | Handle the exception or explain in a comment why it can be ignored. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 4475 | MINOR | `csharpsquid:S3398` | `public class RussiaPaymentOrderException : Exception {` | Move this method inside 'Girocode'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 4519 | MINOR | `csharpsquid:S3398` | `public class RussiaPaymentOrderException : Exception {` | Move this method inside 'WiFi'. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add QRCoder.Core/Generators/PayloadGenerator.cs
git commit -m "fix(sonar): resolver PayloadGenerator — readonly, static, sealed, move métodos, c"
```

#### Lote 1.3: Renderizadores — Svg, Art, Pdf, Bitmap, Postscript, Base64, QRCode

- **Branch:** `feature/devin-20260712-sonar-style-renderers`
- **Arquivos:** `QRCoder.Core/Renderers/SvgQRCode.cs`, `QRCoder.Core/Renderers/ArtQRCode.cs`, `QRCoder.Core/Renderers/PdfByteQRCode.cs`, `QRCoder.Core/Renderers/BitmapByteQRCode.cs`, `QRCoder.Core/Renderers/PostscriptQRCode.cs`, `QRCoder.Core/Renderers/Base64QRCode.cs`, `QRCoder.Core/Renderers/QRCode.cs`
- **Issues:** 26

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `QRCoder.Core/Renderers/ArtQRCode.cs` | 142 | MINOR | `csharpsquid:S2325` | `private SKBitmap MakeDotPixel(int pixelsPerModule, int pixelSize, SKPaint brush)` | Make 'MakeDotPixel' a static method. |
| `QRCoder.Core/Renderers/ArtQRCode.cs` | 148 | MINOR | `csharpsquid:S2184` | `private SKBitmap MakeDotPixel(int pixelsPerModule, int pixelSize, SKPaint brush)` | Cast one of the operands of this division to 'float'. |
| `QRCoder.Core/Renderers/ArtQRCode.cs` | 148 | MINOR | `csharpsquid:S2184` | `private SKBitmap MakeDotPixel(int pixelsPerModule, int pixelSize, SKPaint brush)` | Cast one of the operands of this division to 'float'. |
| `QRCoder.Core/Renderers/ArtQRCode.cs` | 148 | MINOR | `csharpsquid:S2184` | `private SKBitmap MakeDotPixel(int pixelsPerModule, int pixelSize, SKPaint brush)` | Cast one of the operands of this division to 'float'. |
| `QRCoder.Core/Renderers/ArtQRCode.cs` | 174 | MINOR | `csharpsquid:S2325` | `private bool IsPartOfQuietZone(int x, int y, int numModules)` | Make 'IsPartOfQuietZone' a static method. |
| `QRCoder.Core/Renderers/ArtQRCode.cs` | 191 | MINOR | `csharpsquid:S2325` | `private bool IsPartOfFinderPattern(int x, int y, int numModules, int offset)` | Make 'IsPartOfFinderPattern' a static method. |
| `QRCoder.Core/Renderers/Base64QRCode.cs` | 20 | MAJOR | `csharpsquid:S2933` | `field qr: private QRCode qr;` | Make 'qr' 'readonly'. |
| `QRCoder.Core/Renderers/Base64QRCode.cs` | 113 | MINOR | `csharpsquid:S2325` | `private string SKBitmapToBase64(SKBitmap bmp, ImageType imgType)` | Make 'SKBitmapToBase64' a static method. |
| `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 111 | MINOR | `csharpsquid:S2325` | `private byte[] HexSKColorToByteArray(string colorString)` | Make 'HexSKColorToByteArray' a static method. |
| `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 113 | MINOR | `csharpsquid:S6610` | `private byte[] HexSKColorToByteArray(string colorString)` | "StartsWith" overloads that take a "char" should be used |
| `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 121 | MINOR | `csharpsquid:S2325` | `private byte[] IntTo4Byte(int inp)` | Make 'IntTo4Byte' a static method. |
| `QRCoder.Core/Renderers/PdfByteQRCode.cs` | 104 | MINOR | `csharpsquid:S1192` | `public byte[] GetGraphic(int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, int dpi = 150, long jpgQuality = 85)` | Define a constant instead of using this literal ' 0 obj\r\n' 5 times. |
| `QRCoder.Core/Renderers/PdfByteQRCode.cs` | 109 | MINOR | `csharpsquid:S1192` | `public byte[] GetGraphic(int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, int dpi = 150, long jpgQuality = 85)` | Define a constant instead of using this literal 'endobj\r\n' 4 times. |
| `QRCoder.Core/Renderers/PdfByteQRCode.cs` | 214 | MINOR | `csharpsquid:S2325` | `private byte[] HexSKColorToByteArray(string colorString)` | Make 'HexSKColorToByteArray' a static method. |
| `QRCoder.Core/Renderers/PdfByteQRCode.cs` | 216 | MINOR | `csharpsquid:S6610` | `private byte[] HexSKColorToByteArray(string colorString)` | "StartsWith" overloads that take a "char" should be used |
| `QRCoder.Core/Renderers/PostscriptQRCode.cs` | 156 | MINOR | `csharpsquid:S2325` | `private string CleanSvgVal(double input)` | Make 'CleanSvgVal' a static method. |
| `QRCoder.Core/Renderers/QRCode.cs` | 161 | MINOR | `csharpsquid:S2325` | `internal SKPath CreateRoundedSKRectIPath(SKRect rect, int cornerRadius)` | Make 'CreateRoundedSKRectIPath' a static method. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 225 | MINOR | `csharpsquid:S2325` | `private bool IsBlockedByLogo(double x, double y, ImageAttributes? attr, double pixelPerModule)` | Make 'IsBlockedByLogo' a static method. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 253 | MINOR | `csharpsquid:S2325` | `private string CleanSvgVal(double input)` | Make 'CleanSvgVal' a static method. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 281 | MAJOR | `csharpsquid:S2933` | `field _logoData: private string _logoData;` | Make '_logoData' 'readonly'. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 282 | MAJOR | `csharpsquid:S2933` | `field _mediaType: private MediaType _mediaType;` | Make '_mediaType' 'readonly'. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 283 | MAJOR | `csharpsquid:S2933` | `field _iconSizePercent: private int _iconSizePercent;` | Make '_iconSizePercent' 'readonly'. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 284 | MAJOR | `csharpsquid:S2933` | `field _fillLogoBackground: private bool _fillLogoBackground;` | Make '_fillLogoBackground' 'readonly'. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 285 | MAJOR | `csharpsquid:S2933` | `field _logoRaw: private object _logoRaw;` | Make '_logoRaw' 'readonly'. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 286 | MAJOR | `csharpsquid:S2933` | `field _isEmbedded: private bool _isEmbedded;` | Make '_isEmbedded' 'readonly'. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 386 | MINOR | `csharpsquid:S1939` | `public enum MediaType : int {` | 'int' should not be explicitly used as the underlying type. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add QRCoder.Core/Renderers/SvgQRCode.cs QRCoder.Core/Renderers/ArtQRCode.cs QRCoder.Core/Renderers/PdfByteQRCode.cs QRCoder.Core/Renderers/BitmapByteQRCode.cs QRCoder.Core/Renderers/PostscriptQRCode.cs QRCoder.Core/Renderers/Base64QRCode.cs QRCoder.Core/Renderers/QRCode.cs
git commit -m "fix(sonar): resolver Renderizadores — Svg, Art, Pdf, Bitmap, Postscript, Base64, "
```

#### Lote 1.4: Extensões, Modelos e atributos

- **Branch:** `feature/devin-20260712-sonar-style-extensions`
- **Arquivos:** `QRCoder.Core/Extensions/SKColorExtensions.cs`, `QRCoder.Core/Extensions/StringValueAttribute.cs`, `QRCoder.Core/Models/QRCodeData.cs`
- **Issues:** 3

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `QRCoder.Core/Extensions/SKColorExtensions.cs` | 30 | MINOR | `csharpsquid:S6610` | `public static SKColor FromHex(string hex)` | "StartsWith" overloads that take a "char" should be used |
| `QRCoder.Core/Extensions/StringValueAttribute.cs` | 8 | MAJOR | `csharpsquid:S3993` | `public class StringValueAttribute : Attribute {` | Specify AttributeUsage on 'StringValueAttribute'. |
| `QRCoder.Core/Models/QRCodeData.cs` | 95 | MINOR | `csharpsquid:S1481` | `public QRCodeData(byte[] rawData, Compression compressMode)` | Remove the unused local variable 'bArr'. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add QRCoder.Core/Extensions/SKColorExtensions.cs QRCoder.Core/Extensions/StringValueAttribute.cs QRCoder.Core/Models/QRCodeData.cs
git commit -m "fix(sonar): resolver Extensões, Modelos e atributos"
```
### Fase 2 — Exceções, overloads e estrutura

**Branch raiz da fase:** `feature/devin-20260712-sonar-exceptions`

**Lotes:**

#### Lote 2.1: PayloadGenerator e QRCodeGenerator — exceções específicas, overloads adjacentes, overloads ocultos e dispose pattern

- **Branch:** `feature/devin-20260712-sonar-exceptions`
- **Arquivos:** `QRCoder.Core/Generators/PayloadGenerator.cs`, `QRCoder.Core/Generators/QRCodeGenerator.cs`
- **Issues:** 12

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1304 | BLOCKER | `csharpsquid:S3427` | `public SwissQrCodeIbanException(string message, Exception inner)` | This method signature overlaps the one defined on line 1315, the default parameter value can only be used with named arguments. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3082 | MAJOR | `csharpsquid:S3928` | `public override string ToString()` | Use a constructor overloads that allows a more meaningful exception message to be provided. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3101 | MAJOR | `csharpsquid:S112` | `private string TimeToString()` | 'System.Exception' should not be thrown by user code. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3120 | MAJOR | `csharpsquid:S112` | `private void ProcessCommonFields(StringBuilder sb)` | 'System.Exception' should not be thrown by user code. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3130 | MAJOR | `csharpsquid:S112` | `private void ProcessCommonFields(StringBuilder sb)` | 'System.Exception' should not be thrown by user code. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3137 | MAJOR | `csharpsquid:S112` | `private void ProcessCommonFields(StringBuilder sb)` | 'System.Exception' should not be thrown by user code. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3231 | MINOR | `csharpsquid:S4136` | `private void ProcessCommonFields(StringBuilder sb)` | All 'ShadowSocksConfig' method overloads should be adjacent. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 14 | MAJOR | `csharpsquid:S3881` | `public class QRCodeGenerator : IDisposable` | Fix this implementation of 'IDisposable' to conform to the dispose pattern. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 302 | MAJOR | `csharpsquid:S3358` | `private static string GetFormatString(ECCLevel level, int maskVersion)` | Extract this nested ternary operation into an independent statement. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 302 | MAJOR | `csharpsquid:S3358` | `private static string GetFormatString(ECCLevel level, int maskVersion)` | Extract this nested ternary operation into an independent statement. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 511 | MAJOR | `csharpsquid:S127` | `public static void PlaceDataWords(ref QRCodeData qrCode, string data, ref List<SKRectI> blockedModules)` | Do not update the stop condition variable 'x' in the body of the for loop. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 842 | CRITICAL | `csharpsquid:S1994` | `private static List<string> CalculateECCWords(string bitString, ECCInfo eccInfo)` | This loop's stop condition tests 'leadTermSource' but the incrementer updates 'i'. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add QRCoder.Core/Generators/PayloadGenerator.cs QRCoder.Core/Generators/QRCodeGenerator.cs
git commit -m "fix(sonar): resolver PayloadGenerator e QRCodeGenerator — exceções específicas, o"
```
### Fase 3 — Nomenclatura e API pública

**Branch raiz da fase:** `feature/devin-20260712-sonar-naming`

**Lotes:**

#### Lote 3.1: Renomear tipos internos e suprimir/obsoletar API pública com acrônimos

- **Branch:** `feature/devin-20260712-sonar-naming`
- **Arquivos:** `QRCoder.Core/Generators/PayloadGenerator.cs`, `QRCoder.Core/Generators/QRCodeGenerator.cs`
- **Issues:** 6

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 186 | MINOR | `csharpsquid:S101` | `public class SMS : Payload {` | Rename class 'SMS' to match pascal case naming rules, consider using 'Sms'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 249 | MINOR | `csharpsquid:S2342` | `public enum SMSEncoding {` | Rename the enumeration 'SMSEncoding' to match the regular expression: '^([A-Z]{1,3}[a-z0-9]+)*([A-Z]{2})?$'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 269 | MINOR | `csharpsquid:S101` | `public class MMS : Payload {` | Rename class 'MMS' to match pascal case naming rules, consider using 'Mms'. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 328 | MINOR | `csharpsquid:S2342` | `public enum MMSEncoding {` | Rename the enumeration 'MMSEncoding' to match the regular expression: '^([A-Z]{1,3}[a-z0-9]+)*([A-Z]{2})?$'. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1402 | MINOR | `csharpsquid:S2342` | `public enum ECCLevel {` | Rename the enumeration 'ECCLevel' to match the regular expression: '^([A-Z]{1,3}[a-z0-9]+)*([A-Z]{2})?$'. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1463 | MINOR | `csharpsquid:S101` | `private struct ECCInfo {` | Rename struct 'ECCInfo' to match pascal case naming rules, consider using 'EccInfo'. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add QRCoder.Core/Generators/PayloadGenerator.cs QRCoder.Core/Generators/QRCodeGenerator.cs
git commit -m "fix(sonar): resolver Renomear tipos internos e suprimir/obsoletar API pública com"
```
### Fase 4 — Complexidade cognitiva e excesso de parâmetros

**Branch raiz da fase:** `feature/devin-20260712-sonar-complexity`

**Lotes:**

#### Lote 4.1: QRCodeGenerator e PayloadGenerator — extrair helpers, reduzir complexidade

- **Branch:** `feature/devin-20260712-sonar-complexity-generators`
- **Arquivos:** `QRCoder.Core/Generators/QRCodeGenerator.cs`, `QRCoder.Core/Generators/PayloadGenerator.cs`
- **Issues:** 17

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 595 | MAJOR | `csharpsquid:S107` | `public ContactData(ContactOutputType outputType, string firstname, string lastname, string nickname = null, string phone = null, string mobilePhone = null, string workPhone = null, string email = null, DateTime? birthday = null, string website = null, string street = null, string houseNumber = null, string city = null, string zipCode = null, string country = null, string note = null, string stateRegion = null, AddressOrder addressOrder = AddressOrder.Default, string org = null, string orgTitle = null)` | Constructor has 20 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 623 | CRITICAL | `csharpsquid:S3776` | `public override string ToString()` | Refactor this method to reduce its Cognitive Complexity from 156 to the 15 allowed. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 966 | MAJOR | `csharpsquid:S107` | `public SwissQrCode(Iban iban, Currency currency, Contact creditor, Reference reference, AdditionalInformation additionalInformation = null, Contact debitor = null, decimal? amount = null, DateTime? requestedDateOfPayment = null, Contact ultimateCreditor = null, string alternativeProcedure1 = null, string alternativeProcedure2 = null)` | Constructor has 11 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1348 | CRITICAL | `csharpsquid:S3776` | `private Contact(string name, string zipCode, string city, string country, string streetOrAddressline1, string houseNumberOrAddressline2, AddressType addressType)` | Refactor this constructor to reduce its Cognitive Complexity from 43 to the 15 allowed. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1627 | MAJOR | `csharpsquid:S107` | `public Girocode(string iban, string bic, string name, decimal amount, string remittanceInformation = "", TypeOfRemittance typeOfRemittance = TypeOfRemittance.Unstructured, string purposeOfCreditTransfer = "", string messageToGirocodeUser = "", GirocodeVersion version = GirocodeVersion.Version1, GirocodeEncoding encoding = GirocodeEncoding.ISO_8859_1)` | Constructor has 10 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1881 | CRITICAL | `csharpsquid:S3776` | `public BezahlCode(AuthorityType authority, string name, string account, string bnc, string iban, string bic, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string creditorId = "", string mandateId = "", DateTime? dateOfSignature = null, string reason = "", int postingKey = 0, string sepaReference = "", Currency currency = Currency.EUR, DateTime? executionDate = null, int internalMode = 0)` | Refactor this constructor to reduce its Cognitive Complexity from 107 to the 15 allowed. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 1881 | MAJOR | `csharpsquid:S107` | `public BezahlCode(AuthorityType authority, string name, string account, string bnc, string iban, string bic, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string creditorId = "", string mandateId = "", DateTime? dateOfSignature = null, string reason = "", int postingKey = 0, string sepaReference = "", Currency currency = Currency.EUR, DateTime? executionDate = null, int internalMode = 0)` | Constructor has 20 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 2017 | CRITICAL | `csharpsquid:S3776` | `public override string ToString()` | Refactor this method to reduce its Cognitive Complexity from 49 to the 15 allowed. |
| `QRCoder.Core/Generators/PayloadGenerator.cs` | 3712 | MAJOR | `csharpsquid:S107` | `public SlovenianUpnQr(string payerName, string payerAddress, string payerPlace, string recipientName, string recipientAddress, string recipientPlace, string recipientIban, string description, double amount, DateTime? deadline, string recipientSiModel = "SI99", string recipientSiReference = "", string code = "OTHR")` | Constructor has 13 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 203 | CRITICAL | `csharpsquid:S3776` | `private static QRCodeData GenerateQrCode(string bitString, ECCLevel eccLevel, int version)` | Refactor this method to reduce its Cognitive Complexity from 20 to the 15 allowed. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 419 | CRITICAL | `csharpsquid:S3776` | `public static int MaskCode(ref QRCodeData qrCode, int version, ref List<SKRectI> blockedModules, ECCLevel eccLevel)` | Refactor this method to reduce its Cognitive Complexity from 37 to the 15 allowed. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 499 | CRITICAL | `csharpsquid:S3776` | `public static void PlaceDataWords(ref QRCodeData qrCode, string data, ref List<SKRectI> blockedModules)` | Refactor this method to reduce its Cognitive Complexity from 30 to the 15 allowed. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 595 | CRITICAL | `csharpsquid:S3776` | `public static void PlaceAlignmentPatterns(ref QRCodeData qrCode, List<Point> alignmentPatternLocations, ref List<SKRectI> blockedModules)` | Refactor this method to reduce its Cognitive Complexity from 19 to the 15 allowed. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 700 | CRITICAL | `csharpsquid:S3776` | `public static int Score(ref QRCodeData qrCode)` | Refactor this method to reduce its Cognitive Complexity from 47 to the 15 allowed. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 991 | CRITICAL | `csharpsquid:S3776` | `private static int GetCountIndicatorLength(int version, EncodingMode encMode)` | Refactor this method to reduce its Cognitive Complexity from 17 to the 15 allowed. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1244 | CRITICAL | `csharpsquid:S3776` | `private static List<AlignmentPattern> CreateAlignmentPatternTable()` | Refactor this method to reduce its Cognitive Complexity from 21 to the 15 allowed. |
| `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1465 | MAJOR | `csharpsquid:S107` | `public ECCInfo(int version, ECCLevel errorCorrectionLevel, int totalDataCodewords, int eccPerBlock, int blocksInGroup1, int codewordsInGroup1, int blocksInGroup2, int codewordsInGroup2)` | Constructor has 8 parameters, which is greater than the 7 authorized. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add QRCoder.Core/Generators/QRCodeGenerator.cs QRCoder.Core/Generators/PayloadGenerator.cs
git commit -m "fix(sonar): resolver QRCodeGenerator e PayloadGenerator — extrair helpers, reduzi"
```

#### Lote 4.2: Renderizadores — introduzir classes Options para métodos GetGraphic e reduzir parâmetros

- **Branch:** `feature/devin-20260712-sonar-complexity-renderers`
- **Arquivos:** `QRCoder.Core/Renderers/QRCode.cs`, `QRCoder.Core/Renderers/SvgQRCode.cs`, `QRCoder.Core/Renderers/ArtQRCode.cs`, `QRCoder.Core/Renderers/PngByteQRCode.cs`, `QRCoder.Core/Renderers/Base64QRCode.cs`, `QRCoder.Core/Renderers/BitmapByteQRCode.cs`, `QRCoder.Core/Renderers/AsciiQRCode.cs`, `QRCoder.Core/Renderers/PostscriptQRCode.cs`
- **Issues:** 15

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `QRCoder.Core/Renderers/ArtQRCode.cs` | 64 | CRITICAL | `csharpsquid:S3776` | `public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKColor backgroundSKColor, SKBitmap backgroundImage = null, double pixelSizeFactor = 0.8, bool drawQuietZones = true, QuietZoneStyle quietZoneRenderingStyle = QuietZoneStyle.Dotted, BackgroundImageStyle backgroundImageStyle = BackgroundImageStyle.DataAreaOnly, SKBitmap finderPatternImage = null)` | Refactor this method to reduce its Cognitive Complexity from 27 to the 15 allowed. |
| `QRCoder.Core/Renderers/ArtQRCode.cs` | 64 | MAJOR | `csharpsquid:S107` | `public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKColor backgroundSKColor, SKBitmap backgroundImage = null, double pixelSizeFactor = 0.8, bool drawQuietZones = true, QuietZoneStyle quietZoneRenderingStyle = QuietZoneStyle.Dotted, BackgroundImageStyle backgroundImageStyle = BackgroundImageStyle.DataAreaOnly, SKBitmap finderPatternImage = null)` | Method has 10 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/ArtQRCode.cs` | 292 | MAJOR | `csharpsquid:S107` | `public static SKBitmap GetQRCode(string plainText, int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKColor backgroundSKColor, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, SKBitmap backgroundImage = null, double pixelSizeFactor = 0.8, bool drawQuietZones = true, QuietZoneStyle quietZoneRenderingStyle = QuietZoneStyle.Flat, BackgroundImageStyle backgroundImageStyle = BackgroundImageStyle.DataAreaOnly, SKBitmap finderPatternImage = null)` | Method has 16 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/AsciiQRCode.cs` | 102 | MAJOR | `csharpsquid:S107` | `public static string GetQRCode(string plainText, int pixelsPerModule, string darkSKColorString, string whiteSpaceString, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, string endOfLine = "\n", bool drawQuietZones = true)` | Method has 11 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/Base64QRCode.cs` | 103 | MAJOR | `csharpsquid:S107` | `public string GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon, int iconSizePercent = 15, int iconBorderWidth = 6, bool drawQuietZones = true, ImageType imgType = ImageType.Png)` | Method has 8 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/Base64QRCode.cs` | 171 | MAJOR | `csharpsquid:S107` | `public static string GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, ImageType imgType = ImageType.Png)` | Method has 11 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 61 | CRITICAL | `csharpsquid:S3776` | `public byte[] GetGraphic(int pixelsPerModule, byte[] darkSKColorRgb, byte[] lightSKColorRgb)` | Refactor this method to reduce its Cognitive Complexity from 22 to the 15 allowed. |
| `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 141 | MAJOR | `csharpsquid:S107` | `public static byte[] GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1)` | Method has 9 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/PngByteQRCode.cs` | 347 | MAJOR | `csharpsquid:S107` | `public static byte[] GetQRCode(string plainText, int pixelsPerModule, byte[] darkSKColorRgba, byte[] lightSKColorRgba, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true)` | Method has 10 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/PostscriptQRCode.cs` | 298 | MAJOR | `csharpsquid:S107` | `public static string GetQRCode(string plainText, int pointsPerModule, string darkSKColorHex, string lightSKColorHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, bool epsFormat = false)` | Method has 11 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/QRCode.cs` | 107 | CRITICAL | `csharpsquid:S3776` | `public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true, SKColor? iconBackgroundSKColor = null)` | Refactor this method to reduce its Cognitive Complexity from 16 to the 15 allowed. |
| `QRCoder.Core/Renderers/QRCode.cs` | 107 | MAJOR | `csharpsquid:S107` | `public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true, SKColor? iconBackgroundSKColor = null)` | Method has 8 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/QRCode.cs` | 218 | MAJOR | `csharpsquid:S107` | `public static SKBitmap GetQRCode(string plainText, int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true)` | Method has 13 parameters, which is greater than the 7 authorized. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 119 | CRITICAL | `csharpsquid:S3776` | `public string GetGraphic(Size viewBox, string darkSKColorHex, string lightSKColorHex, bool drawQuietZones = true, SizingMode sizingMode = SizingMode.WidthHeightAttribute, SvgLogo logo = null)` | Refactor this method to reduce its Cognitive Complexity from 48 to the 15 allowed. |
| `QRCoder.Core/Renderers/SvgQRCode.cs` | 424 | MAJOR | `csharpsquid:S107` | `public static string GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHex, string lightSKColorHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, SizingMode sizingMode = SizingMode.WidthHeightAttribute, SvgLogo logo = null)` | Method has 12 parameters, which is greater than the 7 authorized. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add QRCoder.Core/Renderers/QRCode.cs QRCoder.Core/Renderers/SvgQRCode.cs QRCoder.Core/Renderers/ArtQRCode.cs QRCoder.Core/Renderers/PngByteQRCode.cs QRCoder.Core/Renderers/Base64QRCode.cs QRCoder.Core/Renderers/BitmapByteQRCode.cs QRCoder.Core/Renderers/AsciiQRCode.cs QRCoder.Core/Renderers/PostscriptQRCode.cs
git commit -m "fix(sonar): resolver Renderizadores — introduzir classes Options para métodos Get"
```
### Fase 5 — Segurança dos workflows do GitHub Actions

**Branch raiz da fase:** `feature/devin-20260712-sonar-workflows`

**Lotes:**

#### Lote 5.1: Workflows — pin SHA, evitar script injection, não expandir secrets, permissões, TODOs

- **Branch:** `feature/devin-20260712-sonar-workflows`
- **Arquivos:** `.github/workflows/code-quality.yml`, `.github/workflows/auto-pr-from-main.yml`
- **Issues:** 11

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `.github/workflows/auto-pr-from-main.yml` | 81 | BLOCKER | `githubactions:S7630` | `**Author:** ${{ github.event.head_commit.author.name }}` | The expression github.event.head_commit.author.name can be set by an external actor to a specially crafted value, enabling script injection. Change this workflow to not use user-controlled data directly in a run block, for example by assigning this expression to an environment variable. |
| `.github/workflows/auto-pr-from-main.yml` | 125 | BLOCKER | `githubactions:S7630` | `echo "**Author:** ${{ github.event.head_commit.author.name }}" >> $GITHUB_STEP_SUMMARY` | The expression github.event.head_commit.author.name can be set by an external actor to a specially crafted value, enabling script injection. Change this workflow to not use user-controlled data directly in a run block, for example by assigning this expression to an environment variable. |
| `.github/workflows/code-quality.yml` | 29 | MAJOR | `githubactions:S7637` | `uses: JetBrains/qodana-action@v2026.1.3` | Use full commit SHA hash for this dependency. |
| `.github/workflows/code-quality.yml` | 59 | MAJOR | `githubactions:S7637` | `uses: NuGet/setup-nuget@v4` | Use full commit SHA hash for this dependency. |
| `.github/workflows/code-quality.yml` | 82 | MAJOR | `githubactions:S2612` | `run: chmod 777 sonar/ -R \|\| true` | Make sure granting write access to others is safe here. |
| `.github/workflows/code-quality.yml` | 87 | MAJOR | `githubactions:S7636` | `if [ -z "${{ secrets.SONNAR_TOKEN }}" ]; then` | Avoid expanding secrets in a run block. |
| `.github/workflows/code-quality.yml` | 98 | MAJOR | `githubactions:S7636` | `/d:sonar.login="${{ secrets.SONNAR_TOKEN }}" \` | Avoid expanding secrets in a run block. |
| `.github/workflows/code-quality.yml` | 108 | MAJOR | `githubactions:S7636` | `if [ -z "${{ secrets.SONNAR_TOKEN }}" ]; then` | Avoid expanding secrets in a run block. |
| `.github/workflows/code-quality.yml` | 113 | MAJOR | `githubactions:S7636` | `dotnet sonarscanner end /d:sonar.login="${{ secrets.SONNAR_TOKEN }}"` | Avoid expanding secrets in a run block. |
| `.github/workflows/code-quality.yml` | 133 | MAJOR | `githubactions:S7637` | `uses: snyk/actions/dotnet@master` | Use full commit SHA hash for this dependency. |
| `.github/workflows/code-quality.yml` | 227 | INFO | `githubactions:S1135` | `# Check for TODO comments` | Complete the task associated to this "TODO" comment. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add .github/workflows/code-quality.yml .github/workflows/auto-pr-from-main.yml
git commit -m "fix(sonar): resolver Workflows — pin SHA, evitar script injection, não expandir s"
```
### Fase 6 — Testes e validação final

**Branch raiz da fase:** `feature/devin-20260712-sonar-tests`

**Lotes:**

#### Lote 6.1: Adicionar assertion ao teste sem assert e executar validação final

- **Branch:** `feature/devin-20260712-sonar-tests`
- **Arquivos:** `QRCoder.Core.Tests/Generators/QRCodeGeneratorEdgeCaseTests.cs`
- **Issues:** 1

| Arquivo | Linha | Severidade | Regra | Símbolo | Mensagem Sonar |
|---------|-------|------------|-------|---------|----------------|
| `QRCoder.Core.Tests/Generators/QRCodeGeneratorEdgeCaseTests.cs` | 138 | BLOCKER | `csharpsquid:S2699` | `public void dispose_works_without_exception()` | Add at least one assertion to this test case. |

**Comandos de verificação:**
```bash
dotnet build QRCoder.Core.sln
dotnet test QRCoder.Core.sln
# Opcional: re-executar análise Sonar
dotnet sonarscanner begin /o:afonsoft /k:afonsoft_QRCoder.Core /d:sonar.host.url=https://sonarcloud.io /d:sonar.login=$SONAR_TOKEN
dotnet build QRCoder.Core.sln
dotnet sonarscanner end /d:sonar.login=$SONAR_TOKEN
```

**Commit padrão:**
```bash
git add QRCoder.Core.Tests/Generators/QRCodeGeneratorEdgeCaseTests.cs
git commit -m "fix(sonar): resolver Adicionar assertion ao teste sem assert e executar validação"
```

## Distribuição das issues por regra

| Regra | Quantidade | Severidade típica |
|-------|------------|-------------------|
| `csharpsquid:S2933` | 36 | MAJOR |
| `csharpsquid:S107` | 18 | MAJOR |
| `csharpsquid:S2325` | 18 | MINOR |
| `csharpsquid:S3776` | 15 | CRITICAL |
| `csharpsquid:S3604` | 12 | MINOR |
| `csharpsquid:S1643` | 7 | MINOR |
| `csharpsquid:S1133` | 7 | INFO |
| `csharpsquid:S3267` | 6 | MINOR |
| `csharpsquid:S4487` | 4 | CRITICAL |
| `githubactions:S7636` | 4 | MAJOR |
| `csharpsquid:S112` | 4 | MAJOR |
| `csharpsquid:S1192` | 4 | MINOR |
| `csharpsquid:S3260` | 4 | MINOR |
| `githubactions:S7637` | 3 | MAJOR |
| `csharpsquid:S1123` | 3 | MAJOR |
| `csharpsquid:S6610` | 3 | MINOR |
| `csharpsquid:S101` | 3 | MINOR |
| `csharpsquid:S2342` | 3 | MINOR |
| `csharpsquid:S3398` | 3 | MINOR |
| `csharpsquid:S2184` | 3 | MINOR |
| `githubactions:S7630` | 2 | BLOCKER |
| `csharpsquid:S3358` | 2 | MAJOR |
| `csharpsquid:S1172` | 2 | MAJOR |
| `csharpsquid:S3878` | 2 | MINOR |
| `csharpsquid:S2699` | 1 | BLOCKER |
| `csharpsquid:S3427` | 1 | BLOCKER |
| `csharpsquid:S1994` | 1 | CRITICAL |
| `githubactions:S2612` | 1 | MAJOR |
| `csharpsquid:S3993` | 1 | MAJOR |
| `csharpsquid:S3928` | 1 | MAJOR |
| `csharpsquid:S2589` | 1 | MAJOR |
| `csharpsquid:S108` | 1 | MAJOR |
| `csharpsquid:S3881` | 1 | MAJOR |
| `csharpsquid:S127` | 1 | MAJOR |
| `csharpsquid:S125` | 1 | MAJOR |
| `csharpsquid:S4136` | 1 | MINOR |
| `csharpsquid:S1450` | 1 | MINOR |
| `csharpsquid:S2486` | 1 | MINOR |
| `csharpsquid:S1481` | 1 | MINOR |
| `csharpsquid:S1939` | 1 | MINOR |
| `githubactions:S1135` | 1 | INFO |

## Listagem completa das 185 issues

| # | Key | Severidade | Regra | Arquivo | Linha | Símbolo | Mensagem |
|---|-----|------------|-------|---------|-------|---------|----------|
| 1 | AZxsv934-6XrgbjS3Mtg | BLOCKER | `githubactions:S7630` | `.github/workflows/auto-pr-from-main.yml` | 81 | `**Author:** ${{ github.event.head_commit.author.name }}` | The expression github.event.head_commit.author.name can be set by an external actor to a specially crafted value, enabling script injection. Change this workflow to not use user-controlled data directly in a run block, for example by assigning this expression to an environment variable. |
| 2 | AZxsv934-6XrgbjS3Mth | BLOCKER | `githubactions:S7630` | `.github/workflows/auto-pr-from-main.yml` | 125 | `echo "**Author:** ${{ github.event.head_commit.author.name }}" >> $GITHUB_STEP_SUMMARY` | The expression github.event.head_commit.author.name can be set by an external actor to a specially crafted value, enabling script injection. Change this workflow to not use user-controlled data directly in a run block, for example by assigning this expression to an environment variable. |
| 3 | AZ3yx-xTCQeXMg_kgcni | BLOCKER | `csharpsquid:S2699` | `QRCoder.Core.Tests/Generators/QRCodeGeneratorEdgeCaseTests.cs` | 138 | `public void dispose_works_without_exception()` | Add at least one assertion to this test case. |
| 4 | AZ3yx-4GCQeXMg_kgcos | BLOCKER | `csharpsquid:S3427` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1304 | `public SwissQrCodeIbanException(string message, Exception inner)` | This method signature overlaps the one defined on line 1315, the default parameter value can only be used with named arguments. |
| 5 | AZ3yx-4GCQeXMg_kgcor | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 623 | `public override string ToString()` | Refactor this method to reduce its Cognitive Complexity from 156 to the 15 allowed. |
| 6 | AZ3yx-4GCQeXMg_kgcn9 | CRITICAL | `csharpsquid:S4487` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 946 | `field ultimateCreditor: private readonly Contact creditor, ultimateCreditor, debitor;` | Remove this unread private field 'ultimateCreditor' or refactor the code to use its value. |
| 7 | AZ3yx-4GCQeXMg_kgcn- | CRITICAL | `csharpsquid:S4487` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 948 | `field requestedDateOfPayment: private readonly DateTime? requestedDateOfPayment;` | Remove this unread private field 'requestedDateOfPayment' or refactor the code to use its value. |
| 8 | AZ3yx-4GCQeXMg_kgcn_ | CRITICAL | `csharpsquid:S4487` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1082 | `field referenceTextType: private readonly ReferenceTextType? referenceTextType;` | Remove this unread private field 'referenceTextType' or refactor the code to use its value. |
| 9 | AZ3yx-4GCQeXMg_kgcov | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1348 | `private Contact(string name, string zipCode, string city, string country, string streetOrAddressline1, string houseNumberOrAddressline2, AddressType addressType)` | Refactor this constructor to reduce its Cognitive Complexity from 43 to the 15 allowed. |
| 10 | AZ3yx-4GCQeXMg_kgco4 | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1881 | `public BezahlCode(AuthorityType authority, string name, string account, string bnc, string iban, string bic, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string creditorId = "", string mandateId = "", DateTime? dateOfSignature = null, string reason = "", int postingKey = 0, string sepaReference = "", Currency currency = Currency.EUR, DateTime? executionDate = null, int internalMode = 0)` | Refactor this constructor to reduce its Cognitive Complexity from 107 to the 15 allowed. |
| 11 | AZ3yx-4GCQeXMg_kgco3 | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 2017 | `public override string ToString()` | Refactor this method to reduce its Cognitive Complexity from 49 to the 15 allowed. |
| 12 | AZ3yx-4GCQeXMg_kgcoA | CRITICAL | `csharpsquid:S4487` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3174 | `field method: private readonly Method method;` | Remove this unread private field 'method' or refactor the code to use its value. |
| 13 | AZWkW3JormSRoR_AbfTR | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 203 | `private static QRCodeData GenerateQrCode(string bitString, ECCLevel eccLevel, int version)` | Refactor this method to reduce its Cognitive Complexity from 20 to the 15 allowed. |
| 14 | AZgGmU93cgpk0Z1O8V__ | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 419 | `public static int MaskCode(ref QRCodeData qrCode, int version, ref List<SKRectI> blockedModules, ECCLevel eccLevel)` | Refactor this method to reduce its Cognitive Complexity from 37 to the 15 allowed. |
| 15 | AZgGmU93cgpk0Z1O8V_- | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 499 | `public static void PlaceDataWords(ref QRCodeData qrCode, string data, ref List<SKRectI> blockedModules)` | Refactor this method to reduce its Cognitive Complexity from 30 to the 15 allowed. |
| 16 | AZgGmU93cgpk0Z1O8WAA | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 595 | `public static void PlaceAlignmentPatterns(ref QRCodeData qrCode, List<Point> alignmentPatternLocations, ref List<SKRectI> blockedModules)` | Refactor this method to reduce its Cognitive Complexity from 19 to the 15 allowed. |
| 17 | AZWkW3JormSRoR_AbfTd | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 700 | `public static int Score(ref QRCodeData qrCode)` | Refactor this method to reduce its Cognitive Complexity from 47 to the 15 allowed. |
| 18 | AZWkW3JormSRoR_AbfTc | CRITICAL | `csharpsquid:S1994` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 842 | `private static List<string> CalculateECCWords(string bitString, ECCInfo eccInfo)` | This loop's stop condition tests 'leadTermSource' but the incrementer updates 'i'. |
| 19 | AZWkW3JormSRoR_AbfTe | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 991 | `private static int GetCountIndicatorLength(int version, EncodingMode encMode)` | Refactor this method to reduce its Cognitive Complexity from 17 to the 15 allowed. |
| 20 | AZWkW3JormSRoR_AbfTk | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1244 | `private static List<AlignmentPattern> CreateAlignmentPatternTable()` | Refactor this method to reduce its Cognitive Complexity from 21 to the 15 allowed. |
| 21 | AZgGmU-Qcgpk0Z1O8WAI | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Renderers/ArtQRCode.cs` | 64 | `public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKColor backgroundSKColor, SKBitmap backgroundImage = null, double pixelSizeFactor = 0.8, bool drawQuietZones = true, QuietZoneStyle quietZoneRenderingStyle = QuietZoneStyle.Dotted, BackgroundImageStyle backgroundImageStyle = BackgroundImageStyle.DataAreaOnly, SKBitmap finderPatternImage = null)` | Refactor this method to reduce its Cognitive Complexity from 27 to the 15 allowed. |
| 22 | AZ3yx-y4CQeXMg_kgcnj | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 61 | `public byte[] GetGraphic(int pixelsPerModule, byte[] darkSKColorRgb, byte[] lightSKColorRgb)` | Refactor this method to reduce its Cognitive Complexity from 22 to the 15 allowed. |
| 23 | AZgGmU-ucgpk0Z1O8WAN | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Renderers/QRCode.cs` | 107 | `public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true, SKColor? iconBackgroundSKColor = null)` | Refactor this method to reduce its Cognitive Complexity from 16 to the 15 allowed. |
| 24 | AZ3yx-2MCQeXMg_kgcnl | CRITICAL | `csharpsquid:S3776` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 119 | `public string GetGraphic(Size viewBox, string darkSKColorHex, string lightSKColorHex, bool drawQuietZones = true, SizingMode sizingMode = SizingMode.WidthHeightAttribute, SvgLogo logo = null)` | Refactor this method to reduce its Cognitive Complexity from 48 to the 15 allowed. |
| 25 | AZ9NmrvRGHtU7p2kuIF- | MAJOR | `githubactions:S7637` | `.github/workflows/code-quality.yml` | 29 | `uses: JetBrains/qodana-action@v2026.1.3` | Use full commit SHA hash for this dependency. |
| 26 | AZ9NmrvRGHtU7p2kuIF_ | MAJOR | `githubactions:S7637` | `.github/workflows/code-quality.yml` | 59 | `uses: NuGet/setup-nuget@v4` | Use full commit SHA hash for this dependency. |
| 27 | AZ9NmrvRGHtU7p2kuIGA | MAJOR | `githubactions:S2612` | `.github/workflows/code-quality.yml` | 82 | `run: chmod 777 sonar/ -R \|\| true` | Make sure granting write access to others is safe here. |
| 28 | AZ9NmrvRGHtU7p2kuIF6 | MAJOR | `githubactions:S7636` | `.github/workflows/code-quality.yml` | 87 | `if [ -z "${{ secrets.SONNAR_TOKEN }}" ]; then` | Avoid expanding secrets in a run block. |
| 29 | AZ9NmrvRGHtU7p2kuIF7 | MAJOR | `githubactions:S7636` | `.github/workflows/code-quality.yml` | 98 | `/d:sonar.login="${{ secrets.SONNAR_TOKEN }}" \` | Avoid expanding secrets in a run block. |
| 30 | AZ9NmrvRGHtU7p2kuIF8 | MAJOR | `githubactions:S7636` | `.github/workflows/code-quality.yml` | 108 | `if [ -z "${{ secrets.SONNAR_TOKEN }}" ]; then` | Avoid expanding secrets in a run block. |
| 31 | AZ9NmrvRGHtU7p2kuIF9 | MAJOR | `githubactions:S7636` | `.github/workflows/code-quality.yml` | 113 | `dotnet sonarscanner end /d:sonar.login="${{ secrets.SONNAR_TOKEN }}"` | Avoid expanding secrets in a run block. |
| 32 | AZ9NmrvRGHtU7p2kuIGB | MAJOR | `githubactions:S7637` | `.github/workflows/code-quality.yml` | 133 | `uses: snyk/actions/dotnet@master` | Use full commit SHA hash for this dependency. |
| 33 | AZWkW3IarmSRoR_AbfRN | MAJOR | `csharpsquid:S3993` | `QRCoder.Core/Extensions/StringValueAttribute.cs` | 8 | `public class StringValueAttribute : Attribute {` | Specify AttributeUsage on 'StringValueAttribute'. |
| 34 | AZ3yx-4GCQeXMg_kgcon | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 595 | `public ContactData(ContactOutputType outputType, string firstname, string lastname, string nickname = null, string phone = null, string mobilePhone = null, string workPhone = null, string email = null, DateTime? birthday = null, string website = null, string street = null, string houseNumber = null, string city = null, string zipCode = null, string country = null, string note = null, string stateRegion = null, AddressOrder addressOrder = AddressOrder.Default, string org = null, string orgTitle = null)` | Constructor has 20 parameters, which is greater than the 7 authorized. |
| 35 | AZ3yx-4GCQeXMg_kgcop | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 966 | `public SwissQrCode(Iban iban, Currency currency, Contact creditor, Reference reference, AdditionalInformation additionalInformation = null, Contact debitor = null, decimal? amount = null, DateTime? requestedDateOfPayment = null, Contact ultimateCreditor = null, string alternativeProcedure1 = null, string alternativeProcedure2 = null)` | Constructor has 11 parameters, which is greater than the 7 authorized. |
| 36 | AZ3yx-4GCQeXMg_kgcnr | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1199 | `field iban: private string iban;` | Make 'iban' 'readonly'. |
| 37 | AZ3yx-4GCQeXMg_kgcns | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1200 | `field ibanType: private IbanType ibanType;` | Make 'ibanType' 'readonly'. |
| 38 | AZ3yx-4GCQeXMg_kgcnt | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1290 | `field br: private string br = "\r\n";` | Make 'br' 'readonly'. |
| 39 | AZ3yx-4GCQeXMg_kgcnu | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'name' 'readonly'. |
| 40 | AZ3yx-4GCQeXMg_kgcnv | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'streetOrAddressline1' 'readonly'. |
| 41 | AZ3yx-4GCQeXMg_kgcnw | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'houseNumberOrAddressline2' 'readonly'. |
| 42 | AZ3yx-4GCQeXMg_kgcnx | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'zipCode' 'readonly'. |
| 43 | AZ3yx-4GCQeXMg_kgcny | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'city' 'readonly'. |
| 44 | AZ3yx-4GCQeXMg_kgcnz | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1291 | `field name: private string name, streetOrAddressline1, houseNumberOrAddressline2, zipCode, city, country;` | Make 'country' 'readonly'. |
| 45 | AZ3yx-4GCQeXMg_kgcn0 | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1292 | `field adrType: private AddressType adrType;` | Make 'adrType' 'readonly'. |
| 46 | AZ3yx-4GCQeXMg_kgcn1 | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1605 | `field br: private string br = "\n";` | Make 'br' 'readonly'. |
| 47 | AZ3yx-4GCQeXMg_kgco2 | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1627 | `public Girocode(string iban, string bic, string name, decimal amount, string remittanceInformation = "", TypeOfRemittance typeOfRemittance = TypeOfRemittance.Unstructured, string purposeOfCreditTransfer = "", string messageToGirocodeUser = "", GirocodeVersion version = GirocodeVersion.Version1, GirocodeEncoding encoding = GirocodeEncoding.ISO_8859_1)` | Constructor has 10 parameters, which is greater than the 7 authorized. |
| 48 | AZ3yx-4GCQeXMg_kgco9 | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1881 | `public BezahlCode(AuthorityType authority, string name, string account, string bnc, string iban, string bic, decimal amount, string periodicTimeunit = "", int periodicTimeunitRotation = 0, DateTime? periodicFirstExecutionDate = null, DateTime? periodicLastExecutionDate = null, string creditorId = "", string mandateId = "", DateTime? dateOfSignature = null, string reason = "", int postingKey = 0, string sepaReference = "", Currency currency = Currency.EUR, DateTime? executionDate = null, int internalMode = 0)` | Constructor has 20 parameters, which is greater than the 7 authorized. |
| 49 | AZ3yx-4GCQeXMg_kgcn7 | MAJOR | `csharpsquid:S1123` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 2827 | `public enum AuthorityType {` | Add an explanation. |
| 50 | AZ3yx-4GCQeXMg_kgcn3 | MAJOR | `csharpsquid:S1123` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 2838 | `public enum AuthorityType {` | Add an explanation. |
| 51 | AZ3yx-4GCQeXMg_kgcn5 | MAJOR | `csharpsquid:S1123` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 2849 | `public enum AuthorityType {` | Add an explanation. |
| 52 | AZ3yx-4GCQeXMg_kgco- | MAJOR | `csharpsquid:S3928` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3082 | `public override string ToString()` | Use a constructor overloads that allows a more meaningful exception message to be provided. |
| 53 | AZ3yx-4GCQeXMg_kgco_ | MAJOR | `csharpsquid:S112` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3101 | `private string TimeToString()` | 'System.Exception' should not be thrown by user code. |
| 54 | AZ3yx-4GCQeXMg_kgcpA | MAJOR | `csharpsquid:S112` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3120 | `private void ProcessCommonFields(StringBuilder sb)` | 'System.Exception' should not be thrown by user code. |
| 55 | AZ3yx-4GCQeXMg_kgcpB | MAJOR | `csharpsquid:S112` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3130 | `private void ProcessCommonFields(StringBuilder sb)` | 'System.Exception' should not be thrown by user code. |
| 56 | AZ3yx-4GCQeXMg_kgcpC | MAJOR | `csharpsquid:S112` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3137 | `private void ProcessCommonFields(StringBuilder sb)` | 'System.Exception' should not be thrown by user code. |
| 57 | AZ3yx-4GCQeXMg_kgcoB | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3177 | `field encryptionTexts: private Dictionary<string, string> encryptionTexts = new Dictionary<string, string>() {` | Make 'encryptionTexts' 'readonly'. |
| 58 | AZ3yx-4GCQeXMg_kgcoC | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3256 | `field UrlEncodeTable: private Dictionary<string, string> UrlEncodeTable = new Dictionary<string, string>` | Make 'UrlEncodeTable' 'readonly'. |
| 59 | AZ3yx-4GCQeXMg_kgcoF | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3640 | `field _payerName: private string _payerName = "";` | Make '_payerName' 'readonly'. |
| 60 | AZ3yx-4GCQeXMg_kgcoG | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3641 | `field _payerAddress: private string _payerAddress = "";` | Make '_payerAddress' 'readonly'. |
| 61 | AZ3yx-4GCQeXMg_kgcoH | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3642 | `field _payerPlace: private string _payerPlace = "";` | Make '_payerPlace' 'readonly'. |
| 62 | AZ3yx-4GCQeXMg_kgcoI | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3643 | `field _amount: private string _amount = "";` | Make '_amount' 'readonly'. |
| 63 | AZ3yx-4GCQeXMg_kgcoJ | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3644 | `field _code: private string _code = "";` | Make '_code' 'readonly'. |
| 64 | AZ3yx-4GCQeXMg_kgcoK | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3645 | `field _purpose: private string _purpose = "";` | Make '_purpose' 'readonly'. |
| 65 | AZ3yx-4GCQeXMg_kgcoL | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3646 | `field _deadLine: private string _deadLine = "";` | Make '_deadLine' 'readonly'. |
| 66 | AZ3yx-4GCQeXMg_kgcoM | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3647 | `field _recipientIban: private string _recipientIban = "";` | Make '_recipientIban' 'readonly'. |
| 67 | AZ3yx-4GCQeXMg_kgcoN | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3648 | `field _recipientName: private string _recipientName = "";` | Make '_recipientName' 'readonly'. |
| 68 | AZ3yx-4GCQeXMg_kgcoO | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3649 | `field _recipientAddress: private string _recipientAddress = "";` | Make '_recipientAddress' 'readonly'. |
| 69 | AZ3yx-4GCQeXMg_kgcoP | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3650 | `field _recipientPlace: private string _recipientPlace = "";` | Make '_recipientPlace' 'readonly'. |
| 70 | AZ3yx-4GCQeXMg_kgcoQ | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3651 | `field _recipientSiModel: private string _recipientSiModel = "";` | Make '_recipientSiModel' 'readonly'. |
| 71 | AZ3yx-4GCQeXMg_kgcoR | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3652 | `field _recipientSiReference: private string _recipientSiReference = "";` | Make '_recipientSiReference' 'readonly'. |
| 72 | AZ3yx-4GCQeXMg_kgcpF | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3712 | `public SlovenianUpnQr(string payerName, string payerAddress, string payerPlace, string recipientName, string recipientAddress, string recipientPlace, string recipientIban, string description, double amount, DateTime? deadline, string recipientSiModel = "SI99", string recipientSiReference = "", string code = "OTHR")` | Constructor has 13 parameters, which is greater than the 7 authorized. |
| 73 | AZ3yx-4GCQeXMg_kgcpG | MAJOR | `csharpsquid:S2589` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3720 | `public SlovenianUpnQr(string payerName, string payerAddress, string payerPlace, string recipientName, string recipientAddress, string recipientPlace, string recipientIban, string description, double amount, DateTime? deadline, string recipientSiModel = "SI99", string recipientSiReference = "", string code = "OTHR")` | Remove this unnecessary check for null. |
| 74 | AZ3yx-4GCQeXMg_kgcoS | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3797 | `field characterSet: private CharacterSets characterSet;` | Make 'characterSet' 'readonly'. |
| 75 | AZ3yx-4GCQeXMg_kgcoT | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3799 | `field mFields: private MandatoryFields mFields;` | Make 'mFields' 'readonly'. |
| 76 | AZ3yx-4GCQeXMg_kgcoU | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3800 | `field oFields: private OptionalFields oFields;` | Make 'oFields' 'readonly'. |
| 77 | AZ3yx-4GCQeXMg_kgcpO | MAJOR | `csharpsquid:S108` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 4466 | `private static bool IsValidQRIban(string iban)` | Either remove or fill this block of code. |
| 78 | AZWkW3JormSRoR_AbfTH | MAJOR | `csharpsquid:S3881` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 14 | `public class QRCodeGenerator : IDisposable` | Fix this implementation of 'IDisposable' to conform to the dispose pattern. |
| 79 | AZWkW3JormSRoR_AbfTP | MAJOR | `csharpsquid:S3358` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 302 | `private static string GetFormatString(ECCLevel level, int maskVersion)` | Extract this nested ternary operation into an independent statement. |
| 80 | AZWkW3JormSRoR_AbfTQ | MAJOR | `csharpsquid:S3358` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 302 | `private static string GetFormatString(ECCLevel level, int maskVersion)` | Extract this nested ternary operation into an independent statement. |
| 81 | AZWkW3JormSRoR_AbfTU | MAJOR | `csharpsquid:S127` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 511 | `public static void PlaceDataWords(ref QRCodeData qrCode, string data, ref List<SKRectI> blockedModules)` | Do not update the stop condition variable 'x' in the body of the for loop. |
| 82 | AZWkW3JormSRoR_AbfTa | MAJOR | `csharpsquid:S1172` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 665 | `public static bool Pattern2(int x, int y)` | Remove this unused method parameter 'x'. |
| 83 | AZWkW3JormSRoR_AbfTb | MAJOR | `csharpsquid:S1172` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 670 | `public static bool Pattern3(int x, int y)` | Remove this unused method parameter 'y'. |
| 84 | AZWkW3JormSRoR_AbfTl | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1465 | `public ECCInfo(int version, ECCLevel errorCorrectionLevel, int totalDataCodewords, int eccPerBlock, int blocksInGroup1, int codewordsInGroup1, int blocksInGroup2, int codewordsInGroup2)` | Constructor has 8 parameters, which is greater than the 7 authorized. |
| 85 | AZWkW3JormSRoR_AbfTB | MAJOR | `csharpsquid:S125` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1548 | `public override string ToString()` | Remove this commented out code. |
| 86 | AZgGmU-Qcgpk0Z1O8WAJ | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/ArtQRCode.cs` | 64 | `public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKColor backgroundSKColor, SKBitmap backgroundImage = null, double pixelSizeFactor = 0.8, bool drawQuietZones = true, QuietZoneStyle quietZoneRenderingStyle = QuietZoneStyle.Dotted, BackgroundImageStyle backgroundImageStyle = BackgroundImageStyle.DataAreaOnly, SKBitmap finderPatternImage = null)` | Method has 10 parameters, which is greater than the 7 authorized. |
| 87 | AZgGmU-Qcgpk0Z1O8WAD | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/ArtQRCode.cs` | 292 | `public static SKBitmap GetQRCode(string plainText, int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKColor backgroundSKColor, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, SKBitmap backgroundImage = null, double pixelSizeFactor = 0.8, bool drawQuietZones = true, QuietZoneStyle quietZoneRenderingStyle = QuietZoneStyle.Flat, BackgroundImageStyle backgroundImageStyle = BackgroundImageStyle.DataAreaOnly, SKBitmap finderPatternImage = null)` | Method has 16 parameters, which is greater than the 7 authorized. |
| 88 | AZgGmU8icgpk0Z1O8V_5 | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/AsciiQRCode.cs` | 102 | `public static string GetQRCode(string plainText, int pixelsPerModule, string darkSKColorString, string whiteSpaceString, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, string endOfLine = "\n", bool drawQuietZones = true)` | Method has 11 parameters, which is greater than the 7 authorized. |
| 89 | AZWkW3F9rmSRoR_AbfQ9 | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Renderers/Base64QRCode.cs` | 20 | `field qr: private QRCode qr;` | Make 'qr' 'readonly'. |
| 90 | AZgGmU70cgpk0Z1O8V_2 | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/Base64QRCode.cs` | 103 | `public string GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon, int iconSizePercent = 15, int iconBorderWidth = 6, bool drawQuietZones = true, ImageType imgType = ImageType.Png)` | Method has 8 parameters, which is greater than the 7 authorized. |
| 91 | AZgGmU70cgpk0Z1O8V_3 | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/Base64QRCode.cs` | 171 | `public static string GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, ImageType imgType = ImageType.Png)` | Method has 11 parameters, which is greater than the 7 authorized. |
| 92 | AZ3yx-y4CQeXMg_kgcnk | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 141 | `public static byte[] GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1)` | Method has 9 parameters, which is greater than the 7 authorized. |
| 93 | AZgGmU9dcgpk0Z1O8V_8 | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/PdfByteQRCode.cs` | 234 | `public static byte[] GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1)` | Method has 9 parameters, which is greater than the 7 authorized. |
| 94 | AZWkW3JXrmSRoR_AbfTA | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/PngByteQRCode.cs` | 347 | `public static byte[] GetQRCode(string plainText, int pixelsPerModule, byte[] darkSKColorRgba, byte[] lightSKColorRgba, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true)` | Method has 10 parameters, which is greater than the 7 authorized. |
| 95 | AZgGmU-Gcgpk0Z1O8WAB | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/PostscriptQRCode.cs` | 298 | `public static string GetQRCode(string plainText, int pointsPerModule, string darkSKColorHex, string lightSKColorHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, bool epsFormat = false)` | Method has 11 parameters, which is greater than the 7 authorized. |
| 96 | AZgGmU-ucgpk0Z1O8WAP | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/QRCode.cs` | 107 | `public SKBitmap GetGraphic(int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true, SKColor? iconBackgroundSKColor = null)` | Method has 8 parameters, which is greater than the 7 authorized. |
| 97 | AZgGmU-ucgpk0Z1O8WAM | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/QRCode.cs` | 218 | `public static SKBitmap GetQRCode(string plainText, int pixelsPerModule, SKColor darkSKColor, SKColor lightSKColor, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, SKBitmap icon = null, int iconSizePercent = 15, int iconBorderWidth = 0, bool drawQuietZones = true)` | Method has 13 parameters, which is greater than the 7 authorized. |
| 98 | AZWkW3ISrmSRoR_AbfRC | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 281 | `field _logoData: private string _logoData;` | Make '_logoData' 'readonly'. |
| 99 | AZWkW3ISrmSRoR_AbfRD | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 282 | `field _mediaType: private MediaType _mediaType;` | Make '_mediaType' 'readonly'. |
| 100 | AZWkW3ISrmSRoR_AbfRE | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 283 | `field _iconSizePercent: private int _iconSizePercent;` | Make '_iconSizePercent' 'readonly'. |
| 101 | AZWkW3ISrmSRoR_AbfRF | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 284 | `field _fillLogoBackground: private bool _fillLogoBackground;` | Make '_fillLogoBackground' 'readonly'. |
| 102 | AZWkW3ISrmSRoR_AbfRG | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 285 | `field _logoRaw: private object _logoRaw;` | Make '_logoRaw' 'readonly'. |
| 103 | AZWkW3ISrmSRoR_AbfRH | MAJOR | `csharpsquid:S2933` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 286 | `field _isEmbedded: private bool _isEmbedded;` | Make '_isEmbedded' 'readonly'. |
| 104 | AZWkW3ISrmSRoR_AbfRM | MAJOR | `csharpsquid:S107` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 424 | `public static string GetQRCode(string plainText, int pixelsPerModule, string darkSKColorHex, string lightSKColorHex, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1, bool drawQuietZones = true, SizingMode sizingMode = SizingMode.WidthHeightAttribute, SvgLogo logo = null)` | Method has 12 parameters, which is greater than the 7 authorized. |
| 105 | AZgGmU8ucgpk0Z1O8V_6 | MINOR | `csharpsquid:S6610` | `QRCoder.Core/Extensions/SKColorExtensions.cs` | 30 | `public static SKColor FromHex(string hex)` | "StartsWith" overloads that take a "char" should be used |
| 106 | AZ3yx-4GCQeXMg_kgcnn | MINOR | `csharpsquid:S101` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 186 | `public class SMS : Payload {` | Rename class 'SMS' to match pascal case naming rules, consider using 'Sms'. |
| 107 | AZ3yx-4GCQeXMg_kgcno | MINOR | `csharpsquid:S2342` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 249 | `public enum SMSEncoding {` | Rename the enumeration 'SMSEncoding' to match the regular expression: '^([A-Z]{1,3}[a-z0-9]+)*([A-Z]{2})?$'. |
| 108 | AZ3yx-4GCQeXMg_kgcnq | MINOR | `csharpsquid:S101` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 269 | `public class MMS : Payload {` | Rename class 'MMS' to match pascal case naming rules, consider using 'Mms'. |
| 109 | AZ3yx-4GCQeXMg_kgcnp | MINOR | `csharpsquid:S2342` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 328 | `public enum MMSEncoding {` | Rename the enumeration 'MMSEncoding' to match the regular expression: '^([A-Z]{1,3}[a-z0-9]+)*([A-Z]{2})?$'. |
| 110 | AZ3yx-4GCQeXMg_kgcoo | MINOR | `csharpsquid:S3878` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 663 | `public override string ToString()` | Remove this array creation and simply pass the elements. |
| 111 | AZ3yx-4GCQeXMg_kgcol | MINOR | `csharpsquid:S1192` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 2050 | `public override string ToString()` | Define a constant instead of using this literal 'ddMMyyyy' 4 times. |
| 112 | AZ3yx-4GCQeXMg_kgcoE | MINOR | `csharpsquid:S4136` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3231 | `private void ProcessCommonFields(StringBuilder sb)` | All 'ShadowSocksConfig' method overloads should be adjacent. |
| 113 | AZ3yx-4GCQeXMg_kgcoV | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3640 | `field _payerName: private string _payerName = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 114 | AZ3yx-4GCQeXMg_kgcoW | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3641 | `field _payerAddress: private string _payerAddress = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 115 | AZ3yx-4GCQeXMg_kgcoX | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3642 | `field _payerPlace: private string _payerPlace = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 116 | AZ3yx-4GCQeXMg_kgcoY | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3643 | `field _amount: private string _amount = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 117 | AZ3yx-4GCQeXMg_kgcoZ | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3644 | `field _code: private string _code = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 118 | AZ3yx-4GCQeXMg_kgcoa | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3645 | `field _purpose: private string _purpose = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 119 | AZ3yx-4GCQeXMg_kgcob | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3647 | `field _recipientIban: private string _recipientIban = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 120 | AZ3yx-4GCQeXMg_kgcoc | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3648 | `field _recipientName: private string _recipientName = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 121 | AZ3yx-4GCQeXMg_kgcod | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3649 | `field _recipientAddress: private string _recipientAddress = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 122 | AZ3yx-4GCQeXMg_kgcoe | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3650 | `field _recipientPlace: private string _recipientPlace = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 123 | AZ3yx-4GCQeXMg_kgcof | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3651 | `field _recipientSiModel: private string _recipientSiModel = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 124 | AZ3yx-4GCQeXMg_kgcog | MINOR | `csharpsquid:S3604` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3652 | `field _recipientSiReference: private string _recipientSiReference = "";` | Remove the member initializer, all constructors set an initial value for the member. |
| 125 | AZ3yx-4GCQeXMg_kgcpD | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3672 | `private string LimitLength(string value, int maxLength)` | Make 'LimitLength' a static method. |
| 126 | AZ3yx-4GCQeXMg_kgcpE | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3729 | `private string FormatAmount(double amount)` | Make 'FormatAmount' a static method. |
| 127 | AZ3yx-4GCQeXMg_kgcoh | MINOR | `csharpsquid:S1450` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3801 | `field separator: private string separator = "\|";` | Remove the field 'separator' and declare it as a local variable in the relevant methods. |
| 128 | AZ3yx-4GCQeXMg_kgcpH | MINOR | `csharpsquid:S3267` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3891 | `private string DetermineSeparator()` | Loops should be simplified using the "Where" LINQ method |
| 129 | AZ3yx-4GCQeXMg_kgcpJ | MINOR | `csharpsquid:S3267` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3958 | `private static string ValidateInput(string input, string fieldname, string[] patterns, string errorText = null)` | Loops should be simplified using the "Where" LINQ method |
| 130 | AZ3yx-4GCQeXMg_kgcnm | MINOR | `csharpsquid:S3260` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3966 | `private class MandatoryFields {` | Private classes which are not derived in the current assembly should be marked as 'sealed'. |
| 131 | AZ3yx-4GCQeXMg_kgcoj | MINOR | `csharpsquid:S3398` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 4457 | `public class RussiaPaymentOrderException : Exception {` | Move this method inside 'Iban'. |
| 132 | AZ3yx-4GCQeXMg_kgcpL | MINOR | `csharpsquid:S2486` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 4466 | `private static bool IsValidQRIban(string iban)` | Handle the exception or explain in a comment why it can be ignored. |
| 133 | AZ3yx-4GCQeXMg_kgcok | MINOR | `csharpsquid:S3398` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 4475 | `public class RussiaPaymentOrderException : Exception {` | Move this method inside 'Girocode'. |
| 134 | AZ3yx-4GCQeXMg_kgcoi | MINOR | `csharpsquid:S3398` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 4519 | `public class RussiaPaymentOrderException : Exception {` | Move this method inside 'WiFi'. |
| 135 | AZWkW3JormSRoR_AbfTJ | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 65 | `public QRCodeData CreateQrCode(PayloadGenerator.Payload payload)` | Make 'CreateQrCode' a static method. |
| 136 | AZWkW3JormSRoR_AbfTK | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 77 | `public QRCodeData CreateQrCode(PayloadGenerator.Payload payload, ECCLevel eccLevel)` | Make 'CreateQrCode' a static method. |
| 137 | AZWkW3JormSRoR_AbfTL | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 93 | `public QRCodeData CreateQrCode(string plainText, ECCLevel eccLevel, bool forceUtf8 = false, bool utf8BOM = false, EciMode eciMode = EciMode.Default, int requestedVersion = -1)` | Make 'CreateQrCode' a static method. |
| 138 | AZWkW3JormSRoR_AbfTM | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 105 | `public QRCodeData CreateQrCode(byte[] binaryData, ECCLevel eccLevel)` | Make 'CreateQrCode' a static method. |
| 139 | AZWkW3JormSRoR_AbfTN | MINOR | `csharpsquid:S1643` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 197 | `public static QRCodeData GenerateQrCode(byte[] binaryData, ECCLevel eccLevel)` | Use a StringBuilder instead. |
| 140 | AZ3vYRqH8DXjeodrPpb- | MINOR | `csharpsquid:S1643` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 214 | `private static QRCodeData GenerateQrCode(string bitString, ECCLevel eccLevel, int version)` | Use a StringBuilder instead. |
| 141 | AZWkW3JormSRoR_AbfTV | MINOR | `csharpsquid:S3267` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 259 | `private static QRCodeData GenerateQrCode(string bitString, ECCLevel eccLevel, int version)` | Loop should be simplified by calling Select(codeBlock => codeBlock.CodeWords)) |
| 142 | AZWkW3JormSRoR_AbfTW | MINOR | `csharpsquid:S3267` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 266 | `private static QRCodeData GenerateQrCode(string bitString, ECCLevel eccLevel, int version)` | Loop should be simplified by calling Select(codeBlock => codeBlock.ECCWords)) |
| 143 | AZWkW3JormSRoR_AbfTO | MINOR | `csharpsquid:S1643` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 369 | `private static string ReverseString(string inp)` | Use a StringBuilder instead. |
| 144 | AZWkW3JormSRoR_AbfTY | MINOR | `csharpsquid:S3267` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 601 | `public static void PlaceAlignmentPatterns(ref QRCodeData qrCode, List<Point> alignmentPatternLocations, ref List<SKRectI> blockedModules)` | Loops should be simplified using the "Where" LINQ method |
| 145 | AZWkW3JormSRoR_AbfTZ | MINOR | `csharpsquid:S3267` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 650 | `private static bool IsBlocked(SKRectI r1, List<SKRectI> blockedModules)` | Loops should be simplified using the "Where" LINQ method |
| 146 | AZWkW3JormSRoR_AbfTI | MINOR | `csharpsquid:S1192` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1038 | `private static bool IsValidISO(string input)` | Define a constant instead of using this literal 'ISO-8859-1' 5 times. |
| 147 | AZWkW3JormSRoR_AbfTh | MINOR | `csharpsquid:S1643` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1061 | `private static string PlainTextToBinaryNumeric(string plainText)` | Use a StringBuilder instead. |
| 148 | AZWkW3JormSRoR_AbfTg | MINOR | `csharpsquid:S1643` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1084 | `private static string PlainTextToBinaryAlphanumeric(string plainText)` | Use a StringBuilder instead. |
| 149 | AZWkW3JormSRoR_AbfTf | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1094 | `private string PlainTextToBinaryECI(string plainText)` | Make 'PlainTextToBinaryECI' a static method. |
| 150 | AZWkW3JormSRoR_AbfTi | MINOR | `csharpsquid:S1643` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1100 | `private string PlainTextToBinaryECI(string plainText)` | Use a StringBuilder instead. |
| 151 | AZWkW3JormSRoR_AbfTj | MINOR | `csharpsquid:S1643` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1132 | `private static string PlainTextToBinaryByte(string plainText, EciMode eciMode, bool utf8BOM, bool forceUtf8)` | Use a StringBuilder instead. |
| 152 | AZWkW3JormSRoR_AbfTF | MINOR | `csharpsquid:S2342` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1402 | `public enum ECCLevel {` | Rename the enumeration 'ECCLevel' to match the regular expression: '^([A-Z]{1,3}[a-z0-9]+)*([A-Z]{2})?$'. |
| 153 | AZWkW3JormSRoR_AbfTG | MINOR | `csharpsquid:S101` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1463 | `private struct ECCInfo {` | Rename struct 'ECCInfo' to match pascal case naming rules, consider using 'EccInfo'. |
| 154 | AZWkW3JormSRoR_AbfTC | MINOR | `csharpsquid:S3260` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1536 | `private class Polynom {` | Private classes which are not derived in the current assembly should be marked as 'sealed'. |
| 155 | AZWkW3JormSRoR_AbfTm | MINOR | `csharpsquid:S3878` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1554 | `public override string ToString()` | Remove this array creation and simply pass the elements. |
| 156 | AZWkW3JormSRoR_AbfTD | MINOR | `csharpsquid:S3260` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1558 | `private class Point {` | Private classes which are not derived in the current assembly should be marked as 'sealed'. |
| 157 | AZgGmU93cgpk0Z1O8V_9 | MINOR | `csharpsquid:S3260` | `QRCoder.Core/Generators/QRCodeGenerator.cs` | 1570 | `private class SKRectI {` | Private classes which are not derived in the current assembly should be marked as 'sealed'. |
| 158 | AZWkW3IhrmSRoR_AbfRQ | MINOR | `csharpsquid:S1481` | `QRCoder.Core/Models/QRCodeData.cs` | 95 | `public QRCodeData(byte[] rawData, Compression compressMode)` | Remove the unused local variable 'bArr'. |
| 159 | AZgGmU-Qcgpk0Z1O8WAH | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/ArtQRCode.cs` | 142 | `private SKBitmap MakeDotPixel(int pixelsPerModule, int pixelSize, SKPaint brush)` | Make 'MakeDotPixel' a static method. |
| 160 | AZgGmU-Qcgpk0Z1O8WAE | MINOR | `csharpsquid:S2184` | `QRCoder.Core/Renderers/ArtQRCode.cs` | 148 | `private SKBitmap MakeDotPixel(int pixelsPerModule, int pixelSize, SKPaint brush)` | Cast one of the operands of this division to 'float'. |
| 161 | AZgGmU-Qcgpk0Z1O8WAF | MINOR | `csharpsquid:S2184` | `QRCoder.Core/Renderers/ArtQRCode.cs` | 148 | `private SKBitmap MakeDotPixel(int pixelsPerModule, int pixelSize, SKPaint brush)` | Cast one of the operands of this division to 'float'. |
| 162 | AZgGmU-Qcgpk0Z1O8WAG | MINOR | `csharpsquid:S2184` | `QRCoder.Core/Renderers/ArtQRCode.cs` | 148 | `private SKBitmap MakeDotPixel(int pixelsPerModule, int pixelSize, SKPaint brush)` | Cast one of the operands of this division to 'float'. |
| 163 | AZWkW3J5rmSRoR_AbfTv | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/ArtQRCode.cs` | 174 | `private bool IsPartOfQuietZone(int x, int y, int numModules)` | Make 'IsPartOfQuietZone' a static method. |
| 164 | AZWkW3J5rmSRoR_AbfTw | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/ArtQRCode.cs` | 191 | `private bool IsPartOfFinderPattern(int x, int y, int numModules, int offset)` | Make 'IsPartOfFinderPattern' a static method. |
| 165 | AZgGmU70cgpk0Z1O8V_4 | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/Base64QRCode.cs` | 113 | `private string SKBitmapToBase64(SKBitmap bmp, ImageType imgType)` | Make 'SKBitmapToBase64' a static method. |
| 166 | AZgGmU-jcgpk0Z1O8WAK | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 111 | `private byte[] HexSKColorToByteArray(string colorString)` | Make 'HexSKColorToByteArray' a static method. |
| 167 | AZWkW3KBrmSRoR_AbfT3 | MINOR | `csharpsquid:S6610` | `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 113 | `private byte[] HexSKColorToByteArray(string colorString)` | "StartsWith" overloads that take a "char" should be used |
| 168 | AZWkW3KBrmSRoR_AbfT1 | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/BitmapByteQRCode.cs` | 121 | `private byte[] IntTo4Byte(int inp)` | Make 'IntTo4Byte' a static method. |
| 169 | AZWkW3JOrmSRoR_AbfS7 | MINOR | `csharpsquid:S1192` | `QRCoder.Core/Renderers/PdfByteQRCode.cs` | 104 | `public byte[] GetGraphic(int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, int dpi = 150, long jpgQuality = 85)` | Define a constant instead of using this literal ' 0 obj\r\n' 5 times. |
| 170 | AZWkW3JOrmSRoR_AbfS8 | MINOR | `csharpsquid:S1192` | `QRCoder.Core/Renderers/PdfByteQRCode.cs` | 109 | `public byte[] GetGraphic(int pixelsPerModule, string darkSKColorHtmlHex, string lightSKColorHtmlHex, int dpi = 150, long jpgQuality = 85)` | Define a constant instead of using this literal 'endobj\r\n' 4 times. |
| 171 | AZgGmU9dcgpk0Z1O8V_7 | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/PdfByteQRCode.cs` | 214 | `private byte[] HexSKColorToByteArray(string colorString)` | Make 'HexSKColorToByteArray' a static method. |
| 172 | AZWkW3JOrmSRoR_AbfS_ | MINOR | `csharpsquid:S6610` | `QRCoder.Core/Renderers/PdfByteQRCode.cs` | 216 | `private byte[] HexSKColorToByteArray(string colorString)` | "StartsWith" overloads that take a "char" should be used |
| 173 | AZWkW3JwrmSRoR_AbfTn | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/PostscriptQRCode.cs` | 156 | `private string CleanSvgVal(double input)` | Make 'CleanSvgVal' a static method. |
| 174 | AZgGmU-ucgpk0Z1O8WAO | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/QRCode.cs` | 161 | `internal SKPath CreateRoundedSKRectIPath(SKRect rect, int cornerRadius)` | Make 'CreateRoundedSKRectIPath' a static method. |
| 175 | AZWkW3ISrmSRoR_AbfRJ | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 225 | `private bool IsBlockedByLogo(double x, double y, ImageAttributes? attr, double pixelPerModule)` | Make 'IsBlockedByLogo' a static method. |
| 176 | AZWkW3ISrmSRoR_AbfRK | MINOR | `csharpsquid:S2325` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 253 | `private string CleanSvgVal(double input)` | Make 'CleanSvgVal' a static method. |
| 177 | AZWkW3ISrmSRoR_AbfRI | MINOR | `csharpsquid:S1939` | `QRCoder.Core/Renderers/SvgQRCode.cs` | 386 | `public enum MediaType : int {` | 'int' should not be explicitly used as the underlying type. |
| 178 | AZ9NmrvRGHtU7p2kuIGC | INFO | `githubactions:S1135` | `.github/workflows/code-quality.yml` | 227 | `# Check for TODO comments` | Complete the task associated to this "TODO" comment. |
| 179 | AZ3yx-4GCQeXMg_kgcot | INFO | `csharpsquid:S1133` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1303 | `public class Contact {` | Do not forget to remove this deprecated code someday. |
| 180 | AZ3yx-4GCQeXMg_kgcou | INFO | `csharpsquid:S1133` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 1315 | `public class Contact {` | Do not forget to remove this deprecated code someday. |
| 181 | AZ3yx-4GCQeXMg_kgcn6 | INFO | `csharpsquid:S1133` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 2827 | `public enum AuthorityType {` | Do not forget to remove this deprecated code someday. |
| 182 | AZ3yx-4GCQeXMg_kgcn2 | INFO | `csharpsquid:S1133` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 2838 | `public enum AuthorityType {` | Do not forget to remove this deprecated code someday. |
| 183 | AZ3yx-4GCQeXMg_kgcn4 | INFO | `csharpsquid:S1133` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 2849 | `public enum AuthorityType {` | Do not forget to remove this deprecated code someday. |
| 184 | AZ3yx-4GCQeXMg_kgcn8 | INFO | `csharpsquid:S1133` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 2990 | `public class OneTimePassword : Payload {` | Do not forget to remove this deprecated code someday. |
| 185 | AZ3yx-4GCQeXMg_kgcoD | INFO | `csharpsquid:S1133` | `QRCoder.Core/Generators/PayloadGenerator.cs` | 3055 | `public enum OneTimePasswordAuthAlgorithm {` | Do not forget to remove this deprecated code someday. |

---

# Prompt Executivo para Agente de Implementação

```text
Você é um engenheiro .NET sênior trabalhando no repositório afonsoft/QRCoder.Core.
A tarefa é corrigir as issues do SonarCloud listadas no plano acima, fase a fase, lote a lote.

### Contexto do código
QRCoder.Core/Generators/QRCodeGenerator.cs: engine que transforma texto/payload em QRCodeData.
QRCoder.Core/Generators/PayloadGenerator.cs: geradores de payload (WiFi, vCard, SEPA, Bitcoin, etc.).
QRCoder.Core/Renderers/*.cs: renderizam QRCodeData para PNG, SVG, PDF, ASCII, Base64, Postscript, ArtQR.
QRCoder.Core/Models/QRCodeData.cs: modelo de dados do QR code.
QRCoder.Core.Tests/: testes xUnit/Shouldly.

### Instruções obrigatórias
1. Nunca modifique main, master ou develop diretamente.
2. Crie a branch a partir de feature/devin-20260712-sonar-quality (atualize com main se necessário).
3. Para cada fase/lote, crie a branch descrita no plano e abra um PR para a branch de integração.
4. Antes de cada commit, execute: `dotnet build QRCoder.Core.sln` e `dotnet test QRCoder.Core.sln`.
5. Preserve a API pública; quando não for possível, use [Obsolete] com mensagem e `// NOSONAR` apenas como último recurso.
6. Não altere `/.github/workflows` exceto na Fase 5 e apenas após revisar segurança.
7. Siga o estilo de código existente (idioma do código: inglês; docs e comentários: pt-BR/inglês conforme padrão).
8. Use `StringBuilder` para concatenações em loops, `readonly` para campos só atribuídos no construtor, `sealed` para classes privadas não herdadas, `static` para métodos que não usam estado de instância.
9. Substitua exceções genéricas (`throw new Exception`) por exceções tipadas do projeto (`ArgumentException`, `InvalidOperationException`, etc.) ou existentes em `QRCoder.Core.Exceptions`.
10. Não commitar secrets, tokens ou `.env`.

### Critérios de aceitação
- `dotnet build QRCoder.Core.sln` deve passar para todos os TFM (netstandard2.1, net8.0, net10.0, net48).
- `dotnet test QRCoder.Core.sln` deve passar (exceto os 10 testes de hash SVG já conhecidos como frágeis, se ainda falharem).
- O número de issues SonarCloud deve diminuir a cada lote.
- Nenhum novo warning crítico deve ser introduzido.
```