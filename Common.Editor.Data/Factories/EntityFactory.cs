﻿using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Factories
{
    // TODO: Redundant?
    public class EntityFactory<TEntity> : IEntityFactory<TEntity>
        where TEntity : class, IEntity, new()
    {
        public TEntity Create(int id)
        {
            // TODO: Should this instantiate from the di container?
            return new TEntity { Id = id };
        }
    }
}