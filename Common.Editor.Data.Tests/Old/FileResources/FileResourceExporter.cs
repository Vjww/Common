using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Editor.Data.Tests.Old.FileResources
{
    [TestClass]
    public class FileResourceExporter
    {
        private readonly byte[] _fourBytes = { 0x01, 0x03, 0x05, 0x07 };
        private readonly byte[] _eightBytes = { 0x02, 0x04, 0x06, 0x08, 0x0A, 0x0C, 0x0E, 0x10 };

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FileResourceExporter_WhenExportingAndStreamIsNull_ExpectArgumentNullException()
        {
            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            sut.Export(null, "test");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileResourceExporter_WhenExportingAndFilePathIsNull_ExpectArgumentException()
        {
            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            sut.Export(new MemoryStream(), null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileResourceExporter_WhenExportingAndFilePathIsEmpty_ExpectArgumentException()
        {
            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            sut.Export(new MemoryStream(), string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileResourceExporter_WhenExportingAndFilePathIsWhitespace_ExpectArgumentException()
        {
            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            sut.Export(new MemoryStream(), " ");
        }

        [TestMethod]
        [DeploymentItem(@"Content\zerobytes.bin")]
        public void FileResourceExporter_WhenExporting_ExpectFileLengthToMatchStreamLength()
        {
            const string filePath = "zerobytes.bin";

            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            using (var stream = new MemoryStream(_eightBytes))
            {
                sut.Export(stream, filePath);
            }

            var importer = new FileResourceImporter<MemoryStream>(new FileResourceService());
            var result = importer.Import(filePath);

            Assert.IsTrue(result.Length == _eightBytes.Length);
        }

        [TestMethod]
        [DeploymentItem(@"Content\fourbytes.bin")]
        public void FileResourceExporter_WhenExportingLargerStream_ExpectFileLengthToMatchStreamLength()
        {
            const string filePath = "fourbytes.bin";

            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            using (var stream = new MemoryStream(_eightBytes))
            {
                sut.Export(stream, filePath);
            }

            var importer = new FileResourceImporter<MemoryStream>(new FileResourceService());
            var result = importer.Import(filePath);

            Assert.IsTrue(result.Length == _eightBytes.Length);
        }

        [TestMethod]
        [DeploymentItem(@"Content\eightbytes.bin")]
        public void FileResourceExporter_WhenExportingSmallerStream_ExpectFileLengthToMatchStreamLength()
        {
            const string filePath = "eightbytes.bin";

            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            using (var stream = new MemoryStream(_fourBytes))
            {
                sut.Export(stream, filePath);
            }

            var importer = new FileResourceImporter<MemoryStream>(new FileResourceService());
            var result = importer.Import(filePath);

            Assert.IsTrue(result.Length == _fourBytes.Length);
        }

        [TestMethod]
        [DeploymentItem(@"Content\zerobytes.bin")]
        public void FileResourceExporter_WhenExporting_ExpectFileByteSequenceToMatchStreamByteSequence()
        {
            const string filePath = "zerobytes.bin";

            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            using (var stream = new MemoryStream(_eightBytes))
            {
                sut.Export(stream, filePath);
            }

            var importer = new FileResourceImporter<MemoryStream>(new FileResourceService());
            var result = importer.Import(filePath);
            var buffer = new byte[_eightBytes.Length];
            var _ = result.Read(buffer, 0, _eightBytes.Length);

            Assert.IsTrue(_eightBytes.SequenceEqual(buffer));
        }

        [TestMethod]
        [DeploymentItem(@"Content\fourbytes.bin")]
        public void FileResourceExporter_WhenExportingLargerStream_ExpectFileByteSequenceToMatchStreamByteSequence()
        {
            const string filePath = "fourbytes.bin";

            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            using (var stream = new MemoryStream(_eightBytes))
            {
                sut.Export(stream, filePath);
            }

            var importer = new FileResourceImporter<MemoryStream>(new FileResourceService());
            var result = importer.Import(filePath);
            var buffer = new byte[_eightBytes.Length];
            var _ = result.Read(buffer, 0, _eightBytes.Length);

            Assert.IsTrue(_eightBytes.SequenceEqual(buffer));
        }

        [TestMethod]
        [DeploymentItem(@"Content\eightbytes.bin")]
        public void FileResourceExporter_WhenExportingSmallerStream_ExpectFileByteSequenceToMatchStreamByteSequence()
        {
            const string filePath = "eightbytes.bin";

            var sut = new FileResourceExporter<MemoryStream>(new FileResourceService());

            using (var stream = new MemoryStream(_fourBytes))
            {
                sut.Export(stream, filePath);
            }

            var importer = new FileResourceImporter<MemoryStream>(new FileResourceService());
            var result = importer.Import(filePath);
            var buffer = new byte[_fourBytes.Length];
            var _ = result.Read(buffer, 0, _fourBytes.Length);

            Assert.IsTrue(_fourBytes.SequenceEqual(buffer));
        }
    }
}