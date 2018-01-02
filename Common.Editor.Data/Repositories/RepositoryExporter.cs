using System;
using System.Collections.Generic;
using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Repositories
{
    public class RepositoryExporter : IRepositoryExporter
    {
        private readonly IEntityExporter _entityExporter;

        public RepositoryExporter(IEntityExporter entityExporter)
        {
            _entityExporter = entityExporter ?? throw new ArgumentNullException(nameof(entityExporter));
        }

        public void Export(IEnumerable<IEntity> entities)
        {
            foreach (var entity in entities)
            {
                _entityExporter.Export(entity);
            }
        }
    }
}