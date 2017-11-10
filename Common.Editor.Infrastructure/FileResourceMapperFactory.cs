using System;

namespace Common.Editor.Infrastructure
{
    public static class FileResourceMapperFactory<TFileResourceMapper>
        where TFileResourceMapper : class, IFileResourceMapper, new()
    {
        public static TFileResourceMapper New(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return new TFileResourceMapper { Id = id };
        }
    }
}