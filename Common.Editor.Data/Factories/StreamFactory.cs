using System.IO;

namespace Common.Editor.Data.Factories
{
    public class StreamFactory : IStreamFactory
    {
        public Stream Create()
        {
            return new MemoryStream();
        }
    }
}