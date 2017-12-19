using System.Collections;
using System.IO;

namespace Common.Editor.Data.Streams
{
    public interface IStreamWriter<in TStream>
        where TStream : Stream
    {
        void Write(TStream stream, long offset, byte value, SeekOrigin seekOrigin);
        void Write(TStream stream, long offset, byte[] values, SeekOrigin seekOrigin);
        void WriteStringList(TStream stream, IEnumerable list);
    }
}