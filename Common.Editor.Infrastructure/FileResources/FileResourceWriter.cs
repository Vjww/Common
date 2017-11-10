using System;
using System.IO;
using Common.Editor.Infrastructure.Streams;

namespace Common.Editor.Infrastructure.FileResources
{
    public class FileResourceWriter<TStream> : IFileResourceWriter
        where TStream : Stream
    {
        private readonly TStream _stream;
        private readonly IStreamWriter<TStream> _writer;

        public FileResourceWriter(
            TStream stream,
            IStreamWriter<TStream> writer)
        {
            _stream = stream;
            _writer = writer;
        }

        public void WriteInteger(int offset, int value)
        {
            var bytes = BitConverter.GetBytes(value);
            _writer.Write(_stream, offset, bytes, SeekOrigin.Begin);
        }
    }
}