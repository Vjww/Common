using System;
using System.Collections.Generic;
using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Repositories
{
    public class RepositoryImporter : IRepositoryImporter
    {
        private readonly IEntityImporter _entityImporter;

        public RepositoryImporter(IEntityImporter entityImporter)
        {
            _entityImporter = entityImporter ?? throw new ArgumentNullException(nameof(entityImporter));
        }

        public void Import(IRepository<IEntity> repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            var list = new List<IEntity>();
            for (var i = 0; i < repository.Capacity; i++)
            {
                var entity = _entityImporter.Import(i);
                list.Add(entity);
            }

            repository.Set(list);
        }
    }
}