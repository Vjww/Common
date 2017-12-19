using System;
using System.IO;

namespace Common.Editor.Data.FileResources
{
    public class FileResourceImporter<TStream> : IFileResourceImporter<TStream>
        where TStream : Stream, new()
    {
        private readonly IFile _fileResourceService;

        public FileResourceImporter(IFile fileResourceService)
        {
            _fileResourceService = fileResourceService ?? throw new ArgumentNullException(nameof(fileResourceService));
        }

        public TStream Import(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(filePath));

            var stream = new TStream();
            using (var fileStream = _fileResourceService.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                fileStream.Seek(0, SeekOrigin.Begin);
                fileStream.CopyTo(stream);
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }
    }
}