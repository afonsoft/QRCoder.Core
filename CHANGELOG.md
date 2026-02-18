# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added
- Comprehensive CI/CD pipeline with GitHub Actions
- Multi-framework support (.NET Standard 2.1, .NET 8.0, .NET 10.0, .NET Framework 4.8)
- Cross-platform SkiaSharp native library handling
- Automated test coverage reporting with Coverlet
- Manual SkiaSharp library copying for Linux CI environments
- Enhanced test stability with graceful SkiaSharp availability checking

### Fixed
- SkiaSharp DllNotFoundException on Linux CI environments
- Native library deployment for all target frameworks
- Test asset copying and path handling across platforms
- Build warnings for obsolete SkiaSharp APIs

### Security
- Updated dependencies to latest secure versions
- Enhanced dependency scanning workflows

### Changed
- Migrated from classic .NET Framework to .NET Core/5+ architecture
- Improved error handling and logging in test helpers
- Standardized project structure and build configurations

## [1.0.7] - 2026-02-18

### Added
- Initial release of QRCoder.Core by AFONSOFT
- Support for multiple QR code types (ASCII, Artistic, PNG, SVG, PDF)
- Comprehensive payload generator for various data types
- Cross-platform compatibility with SkiaSharp rendering engine
- Extensive test suite with 239 test cases

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
- **Total Tests**: 239 (All Passed)

## [1.0.6] - Previous Release

### Added
- Basic QR code generation functionality
- Standard rendering options

---

## Migration Guide

### From 1.0.6 to 1.0.7
- No breaking changes
- Enhanced CI/CD pipeline
- Improved Linux compatibility
- Better error handling for missing native libraries

### System Requirements
- .NET Standard 2.1 or higher
- .NET 8.0+ (recommended)
- .NET Framework 4.8 (Windows only)
- SkiaSharp native dependencies (handled automatically)

### Dependencies
- SkiaSharp 3.119.0
- System.Text.Encoding packages
- Microsoft.Extensions.ObjectPool (performance optimization)

---

*For more detailed information about each release, please refer to the [GitHub Releases](https://github.com/afonsoft/QRCoder.Core/releases) page.*
