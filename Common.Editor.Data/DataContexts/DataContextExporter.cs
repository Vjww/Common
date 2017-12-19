using System;
using System.Collections.Generic;
using Common.Editor.Infrastructure.Entities;
using Common.Editor.Infrastructure.Repositories;

namespace Common.Editor.Infrastructure.DataContexts
{
    public class DataContextExporter : IDataContextExporter
    {
        private readonly IRepositoryExporter _repositoryExporter;

        public DataContextExporter(IRepositoryExporter repositoryExporter)
        {
            _repositoryExporter = repositoryExporter ?? throw new ArgumentNullException(nameof(repositoryExporter));
        }

        public void Export(IList<IRepository<IEntity>> repositories)
        {
            if (repositories == null) throw new ArgumentNullException(nameof(repositories));
            if (repositories.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(repositories));

            foreach (var repository in repositories)
            {
                _repositoryExporter.Export(repository);
            }
        }
    }
}