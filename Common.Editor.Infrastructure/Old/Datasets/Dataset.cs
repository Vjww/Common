//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Common.Editor.Infrastructure.Entities;

//namespace Common.Editor.Infrastructure.Datasets
//{
//    public class DataSet<TEntity> : IDataSet<TEntity>
//        where TEntity : class, IEntity
//    {
//        private readonly List<TEntity> _list;

//        public DataSet(List<TEntity> list)
//        {
//            _list = list ?? throw new ArgumentNullException(nameof(list));
//        }

//        public TEntity GetById(int id)
//        {
//            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

//            return _list.Single(x => x.Id == id);
//        }

//        public IEnumerable<TEntity> Get()
//        {
//            return _list;
//        }

//        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
//        {
//            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

//            return _list.Where(predicate).AsEnumerable();
//        }

//        public void SetById(TEntity item)
//        {
//            if (item == null) throw new ArgumentNullException(nameof(item));

//            for (var i = 0; i < _list.Count; i++)
//            {
//                if (_list[i].Id == item.Id)
//                {
//                    _list[i] = item;
//                }
//            }
//        }

//        public void Set(IEnumerable<TEntity> list)
//        {
//            if (list == null) throw new ArgumentNullException(nameof(list));

//            var array = list as TEntity[] ?? list.OrderBy(x => x.Id).ToArray();

//            if (_list.Count != array.Length)
//            {
//                throw new ArgumentException("The number of items in the source list does not match the number of items in the destination list.");
//            }

//            for (var i = 0; i < _list.Count; i++)
//            {
//                _list[i] = array[i];
//            }
//        }
//    }
//}