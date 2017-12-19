using System;
using Common.Editor.Infrastructure.Entities;

namespace Common.Editor.Infrastructure.Repositories
{
    public class RepositoryExporter : IRepositoryExporter
    {
        private readonly IEntityExporter _entityExporter;

        public RepositoryExporter(IEntityExporter entityExporter)
        {
            _entityExporter = entityExporter ?? throw new ArgumentNullException(nameof(entityExporter));
        }

        public void Export(IRepository<IEntity> repository)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            var entities = repository.Get();
            foreach (var entity in entities)
            {
                _entityExporter.Export(entity);
            }
        }
    }
}