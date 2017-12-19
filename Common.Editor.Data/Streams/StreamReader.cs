using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Editor.Data.Streams
{
    public class StreamReader<TStream> : IStreamReader<TStream>
        where TStream : Stream
    {
        public byte[] Read(TStream stream, long offset, int count, SeekOrigin seekOrigin = SeekOrigin.Begin)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            if (!Enum.IsDefined(typeof(SeekOrigin), seekOrigin))
                throw new ArgumentOutOfRangeException(nameof(seekOrigin));

            var buffer = new byte[count];
            stream.Seek(offset, seekOrigin);
            stream.Read(buffer, 0, count);
            return buffer;
        }

        public IEnumerable ReadStringList(TStream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            var list = new List<string>();

            // TODO: Remove the dependancy on the CLI StreamReader class
            // TODO: as this code will also close the stream??? causing a bug
            using (var streamReader = new StreamReader(stream, Encoding.Default))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }

            return list;
        }
    }
}