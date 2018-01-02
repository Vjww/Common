using System.IO;

namespace Common.Editor.Data.Factories
{
    public interface IStreamFactory
    {
        Stream Create();
    }
}