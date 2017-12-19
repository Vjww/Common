using System;
using System.Collections.Generic;
using System.Linq;
using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private bool _isCapacityInitialised;
        private int _capacity;
        private readonly List<TEntity> _list;

        public int Capacity
        {
            get => _capacity;
            set => SetCapacity(value);
        }

        public Repository()
        {
            _list = new List<TEntity>();
        }

        public TEntity GetById(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return _list.Single(x => x.Id == id);
        }

        public IEnumerable<TEntity> Get()
        {
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return _list;
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            return _list.Where(predicate).AsEnumerable();
        }

        public void SetById(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (_list.Count == 0) throw new InvalidOperationException("There are no items in the repository.");

            for (var i = 0; i < _list.Count; i++)
            {
                if (_list[i].Id == item.Id)
                {
                    _list[i] = item;
                }
            }
        }

        public void Set(IEnumerable<TEntity> list)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));

            if (!_isCapacityInitialised) throw new InvalidOperationException($"The {nameof(Capacity)} property must first be initialised.");

            var enumerable = list as TEntity[] ?? list.OrderBy(x => x.Id).ToArray();
            if (enumerable.Count() != Capacity) throw new ArgumentOutOfRangeException(nameof(list));

            _list.Clear();
            _list.AddRange(enumerable);
        }

        private void SetCapacity(int capacity)
        {
            if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity));
            if (_isCapacityInitialised) throw new InvalidOperationException($"The {nameof(Capacity)} property cannot be changed after it has been initialised.");

            _capacity = capacity;
            _isCapacityInitialised = true;
        }
    }
}