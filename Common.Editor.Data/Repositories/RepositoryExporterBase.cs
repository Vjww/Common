using System;
using System.Collections.Generic;
using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Repositories
{
    public class RepositoryExporterBase : IRepositoryExporter
    {
        private readonly IEntityExporter _entityExporter;

        protected RepositoryExporterBase(IEntityExporter entityExporter)
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