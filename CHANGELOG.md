# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- SRE code quality improvements and architecture enhancements
- SOLID principles implementation with validation framework
- Domain-Driven Design patterns with Value Objects and Domain Services
- Enhanced test coverage with BDD-style Portuguese tests
- Clean Architecture separation between layers

### Fixed
- CS0618: Documented obsolete SkiaSharp SKFilterQuality warnings
- Build stability improvements with proper dependency management
- Test framework stability with graceful error handling

### Security
- **Updated Security Tokens**: Standardized token usage across all GitHub Actions workflows
  - `CODECOV_TOKEN`: Configured for codecov coverage uploads
  - `NUGET_TOKEN`: Configured for NuGet.org publishing
  - `SONNAR_TOKEN`: Updated from SONAR_TOKEN for SonarCloud analysis
- Architecture improvements following security best practices
- Enhanced validation framework for input sanitization
- Proper dependency injection patterns

### Changed
- Refactored validation system with extensible framework
- Improved code organization following Clean Architecture
- Enhanced test structure with better coverage reporting
- **GitHub Actions**: Updated all workflows to use standardized security tokens
- **Documentation**: Added security tokens configuration section to README

## [1.0.8] - 2026-02-18

### Added
- **SOLID Architecture**: Complete implementation of Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, and Dependency Inversion principles
- **DDD Patterns**: Value Objects (HexColor), Domain Services (QRCodeGenerationService), Repository pattern foundation
- **Validation Framework**: Extensible IValidator<T> interface with concrete implementations
- **Clean Architecture**: Proper layering between Domain, Application, Infrastructure, Presentation
- **Enhanced Testing**: BDD-style tests in Portuguese with comprehensive coverage
- **Code Quality**: Improved error handling, documentation, and type safety

### Fixed
- **CS0618 Warnings**: Added TODO comments for obsolete SkiaSharp SKFilterQuality APIs
- **Build Stability**: Resolved project file configuration issues
- **Test Reliability**: Enhanced test stability with proper exception handling

### Security
- **Input Validation**: Comprehensive validation framework for all user inputs
- **Type Safety**: Immutable value objects with proper equality implementation
- **Dependency Injection**: Secure dependency management with proper lifetime handling

### Changed
- **Architecture**: Refactored from monolithic to layered architecture
- **Error Handling**: Implemented graceful degradation patterns
- **Code Organization**: Separated concerns following SOLID principles

## [1.0.7] - 2026-02-17

### Added
- Comprehensive SRE stabilization and test coverage improvements
- 13 new test cases for previously uncovered renderer classes
- BDD-style tests in Portuguese (Dado, Quando, Então)
- Comprehensive CHANGELOG.md following Keep a Changelog standard
- Test coverage section to README.md with detailed metrics

### Fixed
- SkiaSharp obsolete API warnings with TODO comments for future migration
- Build warnings and project configuration issues
- Test asset copying and path handling across platforms

### Security
- Updated dependencies to latest secure versions
- Enhanced dependency scanning workflows

### Changed
- Documentation updates with coverage metrics and changelog link
- Improved CI/CD pipeline stability and error handling

## [1.0.6] - Previous Release

### Added
- Initial release of QRCoder.Core by AFONSOFT
- Support for multiple QR code types (ASCII, Artistic, PNG, SVG, PDF, Base64)
- Comprehensive payload generator for various data types
- Cross-platform compatibility with SkiaSharp rendering engine

### Features
- **QR Code Types**: Standard, Artistic, ASCII, SVG, PNG, PDF, Base64
- **Payload Support**: URL, WiFi, SMS, Email, Geographic Location, Contact Data, Calendar Events, Payment Information
- **Rendering Options**: Custom colors, logos, quiet zones, transparency
- **Cross-Platform**: Windows, Linux, macOS support
- **.NET Support**: .NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8

### Test Coverage
- **Line Coverage**: 78%
- **Branch Coverage**: 83.1%
- **Method Coverage**: 78.1%
- **Total Tests**: 252 (All Passed)

---

## Migration Guide

### From 1.0.7 to 1.0.8
- **Architecture**: New SOLID-based validation framework
- **Testing**: Enhanced BDD-style test structure
- **Code Quality**: Improved error handling and type safety
- **Documentation**: Updated with comprehensive coverage metrics

### System Requirements
- **.NET**: .NET Standard 2.1 or higher
- **.NET 8.0+**: Recommended for best performance
- **.NET Framework 4.8**: Windows-only support
- **SkiaSharp**: Native dependencies handled automatically

### Dependencies
- **Core**: SkiaSharp 3.119.0, System.Text.Encoding packages
- **Performance**: Microsoft.Extensions.ObjectPool, System.Buffers, System.Memory
- **Testing**: xUnit.Net v2, Shouldly assertions, Coverlet coverage

---

*For more detailed information about each release, please refer to [GitHub Releases](https://github.com/afonsoft/QRCoder.Core/releases) page.*
