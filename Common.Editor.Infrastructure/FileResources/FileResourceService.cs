using System.IO;

namespace Common.Editor.Infrastructure.FileResources
{
    public class FileResourceService : IFileResourceService
    {
        public Stream Open(string filePath, FileMode fileMode, FileAccess fileAccess)
        {
            return File.Open(filePath, fileMode, fileAccess);
        }
    }
}