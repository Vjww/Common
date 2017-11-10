using System;
using System.Collections.Generic;
using System.Linq;
using Common.Editor.Infrastructure.Entities;

namespace Common.Editor.Infrastructure.DataSets
{
    public class DataSetBase : IDataSet
    {
        private readonly List<IEntity> _list;

        public int Capacity { get; }

        public DataSetBase(List<IEntity> list, int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
            _list = list ?? throw new ArgumentNullException(nameof(list));

            Capacity = capacity;
        }

        public IEntity GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return _list.Single(x => x.Id == id);
        }

        public IEnumerable<IEntity> Get()
        {
            return _list;
        }

        public IEnumerable<IEntity> Get(Func<IEntity, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));

            return _list.Where(predicate).AsEnumerable();
        }

        public void SetById(IEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i].Id == item.Id)
                {
                    _list[i] = item;
                }
            }
        }

        public void Set(IEnumerable<IEntity> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            var array = list as IEntity[] ?? list.OrderBy(x => x.Id).ToArray();

            if (_list.Count != array.Length)
            {
                throw new ArgumentException("The number of items in the source list does not match the number of items in the destination list.");
            }

            for (var i = 0; i < _list.Count; i++)
            {
                _list[i] = array[i];
            }
        }
    }
}