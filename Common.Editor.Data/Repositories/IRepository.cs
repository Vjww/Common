using System;
using System.Collections.Generic;
using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        int Capacity { get; set; }
        TEntity GetById(int id);
        IEnumerable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void SetById(TEntity item);
        void Set(IEnumerable<TEntity> list);
    }
}