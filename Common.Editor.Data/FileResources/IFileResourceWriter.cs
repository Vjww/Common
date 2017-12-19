using System.Collections;
using System.IO;

namespace Common.Editor.Data.FileResources
{
    public interface IFileResourceWriter<in TStream>
        where TStream : Stream
    {
        void WriteInteger(TStream stream, int offset, int value);
        void WriteStringList(TStream stream, IEnumerable list);
    }
}