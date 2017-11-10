namespace Common.Editor.Infrastructure.FileResources
{
    public interface IFileResourceWriter
    {
        void WriteInteger(int offset, int value);
    }
}