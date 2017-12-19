using System.Collections;
using System.IO;

namespace Common.Editor.Data.Streams
{
    public interface IStreamReader<in TStream>
        where TStream : Stream
    {
        byte[] Read(TStream stream, long offset, int count, SeekOrigin seekOrigin);
        IEnumerable ReadStringList(TStream stream);
    }
}