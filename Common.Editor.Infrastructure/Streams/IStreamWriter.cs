using System.IO;

namespace Common.Editor.Infrastructure.Streams
{
    public interface IStreamWriter<in TStream>
        where TStream : Stream
    {
        void Write(TStream stream, long offset, byte value, SeekOrigin seekOrigin);
        void Write(TStream stream, long offset, byte[] values, SeekOrigin seekOrigin);
    }
}