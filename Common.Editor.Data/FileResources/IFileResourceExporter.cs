using System.IO;

namespace Common.Editor.Data.FileResources
{
    public interface IFileResourceExporter
    {
        void Export(Stream stream, string filePath);
    }
}