using System.IO;

namespace Common.Editor.Data.FileResources
{
    public interface IFileResourceExporter<in TStream>
        where TStream : Stream
    {
        void Export(TStream stream, string filePath);
    }
}