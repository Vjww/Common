using System;

namespace Common.Editor.Infrastructure.Old.Factories
{
    public static class EntityFactory<TEntity>
        where TEntity : class, Entities.IEntity, new()
    {
        public static TEntity New(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return new TEntity { Id = id };
        }
    }
}