namespace Common.Editor.Infrastructure.FileResources
{
    public interface IFileResourceExporter
    {
        void Export(IFileResource stream, string filePath);
    }
}