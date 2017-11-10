using System;
using System.Collections.Generic;
using Common.Editor.Infrastructure.Old.DataSources;
using Common.Editor.Infrastructure.Old.Factories;
using Common.Editor.Infrastructure.Old.Locators;
using Common.Editor.Infrastructure.Old.Mappers;

namespace Common.Editor.Infrastructure.Old.Repositories
{
    public abstract class RepositoryBase<T, TU> : IRepository<T, TU>
        where T : class, IDataSource<TU>
        where TU : class, IConnection
    {
        public abstract void Import(T dataSource);

        public abstract void Export(T dataSource);

        protected DataSetBase<TEntity> ImportRepositoryFromDataSource<TDataSource, TEntity, TLocator, TMapper>(TDataSource dataSource, int itemCount)
            where TEntity : class, IEntity, new()
            where TLocator : class, ILocator, new()
            where TMapper : class, IMapper<TDataSource, TEntity, TLocator>, new()
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (itemCount <= 0) throw new ArgumentOutOfRangeException(nameof(itemCount));

            var list = new List<TEntity>();
            for (var i = 0; i < itemCount; i++)
            {
                var entity = EntityFactory<TEntity>.New(i);
                var locator = LocatorFactory<TLocator>.New(i);
                locator.Initialise();

                var mapper = new TMapper();
                mapper.ImportEntityFromDataSource(dataSource, entity, locator);

                list.Add(entity);
            }
            return new DataSetBase<TEntity>(list);
        }

        protected void ExportRepositoryToDataSource<TDataSource, TEntity, TLocator, TMapper>(TDataSource dataSource, IDataSet<TEntity> repository, int itemCount)
            where TEntity : class, IEntity
            where TLocator : class, ILocator, new()
            where TMapper : class, IMapper<TDataSource, TEntity, TLocator>, new()
        {
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (itemCount <= 0) throw new ArgumentOutOfRangeException(nameof(itemCount));

            for (var i = 0; i < itemCount; i++)
            {
                var entity = repository.GetById(i);
                var locator = LocatorFactory<TLocator>.New(i);
                locator.Initialise();

                var mapper = new TMapper();
                mapper.ExportEntityToDataSource(dataSource, entity, locator);
            }
        }
    }
}