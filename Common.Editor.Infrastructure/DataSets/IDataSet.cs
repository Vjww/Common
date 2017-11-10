using System;
using System.Collections.Generic;
using Common.Editor.Infrastructure.Entities;

namespace Common.Editor.Infrastructure.DataSets
{
    public interface IDataSet
    {
        int Capacity { get; }
        IEntity GetById(int id);
        IEnumerable<IEntity> Get();
        IEnumerable<IEntity> Get(Func<IEntity, bool> predicate);
        void SetById(IEntity item);
        void Set(IEnumerable<IEntity> list);
    }
}