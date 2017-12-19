using System;
using System.Collections;
using System.IO;
using Common.Editor.Infrastructure.Streams;

namespace Common.Editor.Infrastructure.FileResources
{
    public class FileResourceReader<TStream> : IFileResourceReader<TStream>
        where TStream : Stream
    {
        private readonly IStreamReader<TStream> _streamReader;

        public FileResourceReader(IStreamReader<TStream> streamReader)
        {
            _streamReader = streamReader ?? throw new ArgumentNullException(nameof(streamReader));
        }

        public int ReadInteger(TStream stream, int offset)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            var bytes = _streamReader.Read(stream, offset, 4, SeekOrigin.Begin);
            return BitConverter.ToInt32(bytes, 0);
        }

        public IEnumerable ReadStringList(TStream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            return _streamReader.ReadStringList(stream);
        }
    }
}