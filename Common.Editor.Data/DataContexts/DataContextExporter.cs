using System;
using System.Collections.Generic;
using Common.Editor.Data.Entities;
using Common.Editor.Data.Repositories;

namespace Common.Editor.Data.DataContexts
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