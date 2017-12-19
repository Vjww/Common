using System;
using System.Collections.Generic;
using Common.Editor.Infrastructure.Entities;
using Common.Editor.Infrastructure.Repositories;

namespace Common.Editor.Infrastructure.DataContexts
{
    public class DataContextImporter : IDataContextImporter
    {
        private readonly IRepositoryImporter _repositoryImporter;

        public DataContextImporter(IRepositoryImporter repositoryImporter)
        {
            _repositoryImporter = repositoryImporter ?? throw new ArgumentNullException(nameof(repositoryImporter));
        }

        public void Import(IList<IRepository<IEntity>> repositories)
        {
            if (repositories == null) throw new ArgumentNullException(nameof(repositories));

            foreach (var repository in repositories)
            {
                if (repository.Capacity <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(repository.Capacity));
                }
            }

            foreach (var repository in repositories)
            {
                _repositoryImporter.Import(repository);
            }
        }
    }
}