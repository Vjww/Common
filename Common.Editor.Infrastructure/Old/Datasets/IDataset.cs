//using System;
//using System.Collections.Generic;
//using Common.Editor.Infrastructure.Entities;

//namespace Common.Editor.Infrastructure.Datasets
//{
//    public interface IDataSet<TEntity>
//        where TEntity : class, IEntity
//    {
//        TEntity GetById(int id);
//        IEnumerable<TEntity> Get();
//        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
//        void SetById(TEntity item);
//        void Set(IEnumerable<TEntity> list);
//    }
//}