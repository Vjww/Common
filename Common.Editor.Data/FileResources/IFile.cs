using System.IO;

namespace Common.Editor.Infrastructure.FileResources
{
    public interface IFile
    {
        Stream Open(string filePath, FileMode fileMode, FileAccess fileAccess);
    }
}