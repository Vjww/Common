using System;
using System.Collections;
using System.IO;

namespace Common.Editor.Infrastructure.FileResources
{
    public class FileResource<TStream> : IFileResource
        where TStream : Stream
    {
        private TStream _stream;
        private readonly IFileResourceExporter<TStream> _fileResourceExporter;
        private readonly IFileResourceImporter<TStream> _fileResourceImporter;
        private readonly IFileResourceReader<TStream> _fileResourceReader;
        private readonly IFileResourceWriter<TStream> _fileResourceWriter;

        public FileResource(
            TStream stream,
            IFileResourceExporter<TStream> fileResourceExporter,
            IFileResourceImporter<TStream> fileResourceImporter,
            IFileResourceReader<TStream> fileResourceReader,
            IFileResourceWriter<TStream> fileResourceWriter)
        {
            _stream = stream ?? throw new ArgumentNullException(nameof(stream));
            _fileResourceExporter = fileResourceExporter ?? throw new ArgumentNullException(nameof(fileResourceExporter));
            _fileResourceImporter = fileResourceImporter ?? throw new ArgumentNullException(nameof(fileResourceImporter));
            _fileResourceReader = fileResourceReader ?? throw new ArgumentNullException(nameof(fileResourceReader));
            _fileResourceWriter = fileResourceWriter ?? throw new ArgumentNullException(nameof(fileResourceWriter));
        }

        public void Export(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _fileResourceExporter.Export(_stream, filePath);
        }

        public void Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            _stream = _fileResourceImporter.Import(filePath);
        }

        public int ReadInteger(int offset)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            return _fileResourceReader.ReadInteger(_stream, offset);
        }

        public void WriteInteger(int offset, int value)
        {
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            _fileResourceWriter.WriteInteger(_stream, offset, value);
        }

        public IEnumerable ReadStringList()
        {
            return _fileResourceReader.ReadStringList(_stream);
        }

        public void WriteStringList(IEnumerable list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            _fileResourceWriter.WriteStringList(_stream, list);
        }
    }
}