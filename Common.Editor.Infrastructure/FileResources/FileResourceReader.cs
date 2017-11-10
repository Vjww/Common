using System;
using System.IO;
using Common.Editor.Infrastructure.Streams;

namespace Common.Editor.Infrastructure.FileResources
{
    public class FileResourceReader<TStream> : IFileResourceReader
        where TStream : Stream
    {
        private readonly TStream _stream;
        private readonly IStreamReader<TStream> _reader;

        public FileResourceReader(
            TStream stream,
            IStreamReader<TStream> reader)
        {
            _stream = stream;
            _reader = reader;
        }

        public int ReadInteger(int offset)
        {
            var bytes = _reader.Read(_stream, offset, 4, SeekOrigin.Begin);
            return BitConverter.ToInt32(bytes, 0);
        }
    }
}