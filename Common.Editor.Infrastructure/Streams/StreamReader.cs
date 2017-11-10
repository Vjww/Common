using System;
using System.IO;

namespace Common.Editor.Infrastructure.Streams
{
    public class StreamReader<TStream> : IStreamReader<TStream>
        where TStream : Stream
    {
        public byte[] Read(TStream stream, long offset, int count, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new ArgumentOutOfRangeException(nameof(seekOrigin));

            var buffer = new byte[count];
            stream.Seek(offset, seekOrigin);
            stream.Read(buffer, 0, count);
            return buffer;
        }
    }
}