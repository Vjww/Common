using System;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Common.Editor.Data.Streams
{
    public class StreamWriter<TStream> : IStreamWriter<TStream>
        where TStream : Stream
    {
        public void Write(TStream stream, long offset, byte value, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            Write(stream, offset, new[] { value }, seekOrigin);
        }

        public void Write(TStream stream, long offset, byte[] values, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (values == null) throw new ArgumentNullException(nameof(values));
            if (values.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(values));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new InvalidEnumArgumentException(nameof(seekOrigin), (int)seekOrigin, typeof(SeekOrigin));

            stream.Seek(offset, seekOrigin);
            stream.Write(values, 0, values.Length);
        }

        public void WriteStringList(TStream stream, IEnumerable list)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (list == null) throw new ArgumentNullException(nameof(list));

            // TODO: Remove the dependancy on the CLI StreamWriter class
            // TODO: as this code will also close the stream??? causing a bug
            using (var streamWriter = new StreamWriter(stream, Encoding.Default))
            {
                foreach (var item in list)
                {
                    streamWriter.WriteLine(item);
                }
            }
        }
    }
}