namespace Common.Editor.Infrastructure.FileResources
{
    public interface IFileResourceImporter
    {
        IFileResource Import(string filePath);
    }
}