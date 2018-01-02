using System.IO;

namespace Common.Editor.Data.FileResources
{
    public interface IFileResourceImporter
    {
        Stream Import(string filePath);
    }
}