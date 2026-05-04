using System;
using System.Collections;
using System.IO;
using QRCoder.Core.Generators;
using QRCoder.Core.Models;
using Shouldly;
using Xunit;

namespace QRCoder.Core.Tests.Models
{
    public class QRCodeDataTests
    {
        [Fact]
        public void constructor_version_creates_correct_matrix_size()
        {
            // Version 1 = 21x21
            using (var data = new QRCodeData(1))
            {
                data.ModuleMatrix.Count.ShouldBe(21);
                data.ModuleMatrix[0].Length.ShouldBe(21);
                data.Version.ShouldBe(1);
            }
        }

        [Theory]
        [InlineData(1, 21)]
        [InlineData(2, 25)]
        [InlineData(5, 37)]
        [InlineData(10, 57)]
        [InlineData(40, 177)]
        public void constructor_version_creates_correct_size_for_versions(int version, int expectedSize)
        {
            using (var data = new QRCodeData(version))
            {
                data.ModuleMatrix.Count.ShouldBe(expectedSize);
            }
        }

        [Fact]
        public void module_matrix_initialized_to_false()
        {
            using (var data = new QRCodeData(1))
            {
                foreach (BitArray row in data.ModuleMatrix)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        row[i].ShouldBeFalse();
                    }
                }
            }
        }

        [Fact]
        public void get_raw_data_uncompressed_roundtrips()
        {
            using (var gen = new QRCodeGenerator())
            using (var original = gen.CreateQrCode("Test data", QRCodeGenerator.ECCLevel.M))
            {
                var rawData = original.GetRawData(QRCodeData.Compression.Uncompressed);
                using (var restored = new QRCodeData(rawData, QRCodeData.Compression.Uncompressed))
                {
                    restored.Version.ShouldBe(original.Version);
                    restored.ModuleMatrix.Count.ShouldBe(original.ModuleMatrix.Count);
                    for (int y = 0; y < original.ModuleMatrix.Count; y++)
                    {
                        for (int x = 0; x < original.ModuleMatrix[y].Length; x++)
                        {
                            restored.ModuleMatrix[y][x].ShouldBe(original.ModuleMatrix[y][x]);
                        }
                    }
                }
            }
        }

        [Fact]
        public void get_raw_data_deflate_roundtrips()
        {
            using (var gen = new QRCodeGenerator())
            using (var original = gen.CreateQrCode("Deflate test", QRCodeGenerator.ECCLevel.L))
            {
                var rawData = original.GetRawData(QRCodeData.Compression.Deflate);
                using (var restored = new QRCodeData(rawData, QRCodeData.Compression.Deflate))
                {
                    restored.Version.ShouldBe(original.Version);
                    restored.ModuleMatrix.Count.ShouldBe(original.ModuleMatrix.Count);
                }
            }
        }

        [Fact]
        public void get_raw_data_gzip_roundtrips()
        {
            using (var gen = new QRCodeGenerator())
            using (var original = gen.CreateQrCode("GZip test", QRCodeGenerator.ECCLevel.Q))
            {
                var rawData = original.GetRawData(QRCodeData.Compression.GZip);
                using (var restored = new QRCodeData(rawData, QRCodeData.Compression.GZip))
                {
                    restored.Version.ShouldBe(original.Version);
                    restored.ModuleMatrix.Count.ShouldBe(original.ModuleMatrix.Count);
                }
            }
        }

        [Fact]
        public void raw_data_invalid_header_throws()
        {
            var invalidData = new byte[] { 0x00, 0x00, 0x00, 0x00, 21 };
            Should.Throw<InvalidOperationException>(() => new QRCodeData(invalidData, QRCodeData.Compression.Uncompressed));
        }

        [Fact]
        public void save_and_load_raw_data_from_file()
        {
            var tempFile = Path.GetTempFileName();
            try
            {
                using (var gen = new QRCodeGenerator())
                using (var original = gen.CreateQrCode("File roundtrip", QRCodeGenerator.ECCLevel.M))
                {
                    original.SaveRawData(tempFile, QRCodeData.Compression.Uncompressed);

                    using (var restored = new QRCodeData(tempFile, QRCodeData.Compression.Uncompressed))
                    {
                        restored.Version.ShouldBe(original.Version);
                        restored.ModuleMatrix.Count.ShouldBe(original.ModuleMatrix.Count);
                    }
                }
            }
            finally
            {
                File.Delete(tempFile);
            }
        }

        [Fact]
        public void dispose_clears_module_matrix()
        {
            var data = new QRCodeData(1);
            data.ModuleMatrix.ShouldNotBeNull();
            data.Dispose();
            data.ModuleMatrix.ShouldBeNull();
            data.Version.ShouldBe(0);
        }

        [Fact]
        public void compressed_data_is_smaller_than_uncompressed()
        {
            using (var gen = new QRCodeGenerator())
            using (var data = gen.CreateQrCode("Compression size comparison test with longer data", QRCodeGenerator.ECCLevel.H))
            {
                var uncompressed = data.GetRawData(QRCodeData.Compression.Uncompressed);
                var deflated = data.GetRawData(QRCodeData.Compression.Deflate);
                var gzipped = data.GetRawData(QRCodeData.Compression.GZip);

                deflated.Length.ShouldBeLessThan(uncompressed.Length);
                gzipped.Length.ShouldBeLessThan(uncompressed.Length);
            }
        }
    }
}
