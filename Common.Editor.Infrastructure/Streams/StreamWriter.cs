using System;
using System.ComponentModel;
using System.IO;

namespace Common.Editor.Infrastructure.Streams
{
    public class StreamWriter<TStream> : IStreamWriter<TStream>
        where TStream : Stream
    {
        public void Write(TStream stream, long offset, byte value, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            Write(stream, offset, new[] { value }, seekOrigin);
        }

        public void Write(TStream stream, long offset, byte[] values, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(values));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            stream.Seek(offset, seekOrigin);
            stream.Write(values, 0, values.Length);
        }
    }
}