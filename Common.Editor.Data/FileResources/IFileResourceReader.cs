using System.Collections;
using System.IO;

namespace Common.Editor.Infrastructure.FileResources
{
    public interface IFileResourceReader<in TStream>
        where TStream : Stream
    {
        int ReadInteger(TStream stream, int offset);
        IEnumerable ReadStringList(TStream stream);
    }
}