using System.IO;

namespace Common.Editor.Data.FileResources
{
    public interface IFileResourceImporter<out TStream>
        where TStream : Stream
    {
        TStream Import(string filePath);
    }
}