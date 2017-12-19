using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Editor.Data.Tests.Old.FileResources
{
    [TestClass]
    public class FileResourceImporter
    {
        private readonly byte[] _eightBytes = { 0x02, 0x04, 0x06, 0x08, 0x0A, 0x0C, 0x0E, 0x10 };

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileResourceImporter_WhenImportingAndFilePathIsNull_ExpectArgumentException()
        {
            var sut = new FileResourceImporter<MemoryStream>(new StubIFileResourceService());

            var _ = sut.Import(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileResourceImporter_WhenImportingAndFilePathIsEmpty_ExpectArgumentException()
        {
            var sut = new FileResourceImporter<MemoryStream>(new StubIFileResourceService());

            var _ = sut.Import(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FileResourceImporter_WhenImportingAndFilePathIsWhitespace_ExpectArgumentException()
        {
            var sut = new FileResourceImporter<MemoryStream>(new StubIFileResourceService());

            var _ = sut.Import(" ");
        }

        [TestMethod]
        [DeploymentItem(@"Content\eightbytes.bin")]
        public void FileResourceImporter_WhenImporting_ExpectStreamLengthToMatchFileLength()
        {
            const string filePath = "eightbytes.bin";

            var sut = new FileResourceImporter<MemoryStream>(new FileResourceService());

            var stream = sut.Import(filePath);

            Assert.IsTrue(stream.Length == _eightBytes.Length);
        }

        [TestMethod]
        [DeploymentItem(@"Content\eightbytes.bin")]
        public void FileResourceImporter_WhenImporting_ExpectStreamPositionAtBeginning()
        {
            const string filePath = "eightbytes.bin";

            var sut = new FileResourceImporter<MemoryStream>(new FileResourceService());

            var stream = sut.Import(filePath);

            Assert.IsTrue(stream.Position == 0);
        }

        [TestMethod]
        [DeploymentItem(@"Content\eightbytes.bin")]
        public void FileResourceImporter_WhenImporting_ExpectStreamByteSequenceToMatchFileByteSequence()
        {
            const string filePath = "eightbytes.bin";

            var sut = new FileResourceImporter<MemoryStream>(new FileResourceService());

            var stream = sut.Import(filePath);

            var buffer = new byte[_eightBytes.Length];
            var _ = stream.Read(buffer, 0, _eightBytes.Length);

            Assert.IsTrue(_eightBytes.SequenceEqual(buffer));
        }
    }
}