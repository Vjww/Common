using System;
using System.Collections;
using System.IO;
using Common.Editor.Infrastructure.Streams;

namespace Common.Editor.Infrastructure.FileResources
{
    public class FileResourceWriter<TStream> : IFileResourceWriter<TStream>
        where TStream : Stream
    {
        private readonly IStreamWriter<TStream> _streamWriter;

        public FileResourceWriter(IStreamWriter<TStream> streamWriter)
        {
            _streamWriter = streamWriter ?? throw new ArgumentNullException(nameof(streamWriter));
        }

        public void WriteInteger(TStream stream, int offset, int value)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));

            var bytes = BitConverter.GetBytes(value);
            _streamWriter.Write(stream, offset, bytes, SeekOrigin.Begin);
        }

        public void WriteStringList(TStream stream, IEnumerable list)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (list == null) throw new ArgumentNullException(nameof(list));

            _streamWriter.WriteStringList(stream, list);
        }
    }
}