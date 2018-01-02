﻿using System;
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

        public IEnumerable<IEntity> Import(int repositoryCapacity)
        {
            if (repositoryCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(repositoryCapacity));
            }

            var entities = new List<IEntity>();
            for (var i = 0; i < repositoryCapacity; i++)
            {
                var entity = _entityImporter.Import(i);
                entities.Add(entity);
            }

            return entities;
        }
    }
}