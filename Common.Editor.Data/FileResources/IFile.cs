using System.IO;

namespace Common.Editor.Data.FileResources
{
    public interface IFile
    {
        Stream Open(string filePath, FileMode fileMode, FileAccess fileAccess);
    }
}