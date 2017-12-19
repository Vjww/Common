using System.IO;

namespace Common.Editor.Infrastructure.FileResources
{
    public interface IFileResourceExporter<in TStream>
        where TStream : Stream
    {
        void Export(TStream stream, string filePath);
    }
}