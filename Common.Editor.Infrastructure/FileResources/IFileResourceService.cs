using System.IO;

namespace Common.Editor.Infrastructure.FileResources
{
    public interface IFileResourceService
    {
        Stream Open(string filePath, FileMode fileMode, FileAccess fileAccess);
    }
}