using Common.Enums;

namespace Common.FileConnection
{
    public interface IFileConnection
    {
        void Open(string filePath, StreamDirectionType streamDirection);
        void Close();
    }
}
