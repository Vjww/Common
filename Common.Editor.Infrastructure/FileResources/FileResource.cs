using System.IO;

namespace Common.Editor.Infrastructure.FileResources
{
    public class FileResource<TStream> : IFileResource
        where TStream : Stream
    {
        private TStream _stream;
        private readonly IFileResourceExporter<TStream> _exporter;
        private readonly IFileResourceImporter<TStream> _importer;
        private readonly IFileResourceReader _reader;
        private readonly IFileResourceWriter _writer;

        public FileResource(
            TStream stream,
            IFileResourceExporter<TStream> exporter,
            IFileResourceImporter<TStream> importer,
            IFileResourceReader reader,
            IFileResourceWriter writer)
        {
            _stream = stream;
            _exporter = exporter;
            _importer = importer;
            _reader = reader;
            _writer = writer;
        }

        public void Export(string filePath)
        {
            _exporter.Export(_stream, filePath);
        }

        public void Import(string filePath)
        {
            _stream = _importer.Import(filePath);
        }

        public int ReadInteger(int offset)
        {
            return _reader.ReadInteger(offset);
        }

        public void WriteInteger(int offset, int value)
        {
            _writer.WriteInteger(offset, value);
        }
    }
}