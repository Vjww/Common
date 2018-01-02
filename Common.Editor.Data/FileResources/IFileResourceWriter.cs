using System.Collections;
using System.IO;

namespace Common.Editor.Data.FileResources
{
    public interface IFileResourceWriter
    {
        void WriteInteger(Stream stream, int offset, int value);
        void WriteStringList(Stream stream, IEnumerable list);
    }
}