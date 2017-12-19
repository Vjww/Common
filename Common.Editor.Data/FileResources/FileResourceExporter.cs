using System;
using System.IO;

namespace Common.Editor.Infrastructure.FileResources
{
    public class FileResourceExporter<TStream> : IFileResourceExporter<TStream>
        where TStream : Stream, new()
    {
        private readonly IFile _fileResourceService;

        public FileResourceExporter(IFile fileResourceService)
        {
            _fileResourceService = fileResourceService ?? throw new ArgumentNullException(nameof(fileResourceService));
        }

        public void Export(TStream stream, string filePath)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            using (var fileStream = _fileResourceService.Open(filePath, FileMode.Truncate, FileAccess.Write))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
        }
    }
}