using System;
using System.IO;
using Common.Editor.Infrastructure.Old.DataSources;
using Common.Editor.Infrastructure.Old.Locators;

namespace Common.Editor.Infrastructure.Old.Mappers
{
    public abstract class MapperBase<TDataSource, TConnection, TEntity, TLocator> : IMapper<TDataSource, TEntity, TLocator>
        where TDataSource : class, IDataSource<TConnection>
        where TConnection : class, IConnection
        where TEntity : class, IEntity
        where TLocator : class, ILocator
    {
        public abstract void ImportEntityFromDataSource(TDataSource dataSource, TEntity entity, TLocator locator);

        public abstract void ExportEntityToDataSource(TDataSource dataSource, TEntity entity, TLocator locator);

        protected int ReadIntegerFromMemoryStream(StreamService<MemoryStream> source, int offset)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var bytes = source.Read(offset, 4);
            return BitConverter.ToInt32(bytes, 0);
        }

        protected string ReadStringFromTextResource(ITextFileResource source, int id)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return source.Read(id);
        }

        protected void WriteIntegerToMemoryStream(StreamService<MemoryStream> source, int offset, int value)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var bytes = BitConverter.GetBytes(value);
            source.Write(offset, bytes);
        }

        protected void WriteStringToTextResource(ITextFileResource source, int id, string value)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            source.Write(id, value);
        }
    }
}