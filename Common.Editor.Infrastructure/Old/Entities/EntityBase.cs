using System;

namespace Common.Editor.Infrastructure.Old.Entities
{
    public abstract class EntityBase : IEntity
    {
        private bool _isIdInitialised;
        private int _id;

        public int Id
        {
            get => _id;
            set => SetId(value);
        }

        private void SetId(int id)
        {
            if (_isIdInitialised) throw new InvalidOperationException($"The {nameof(Id)} property cannot be changed after it has been initialised.");
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            _id = id;
            _isIdInitialised = true;
        }
    }
}