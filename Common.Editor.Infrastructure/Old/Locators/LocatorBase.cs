using System;

namespace Common.Editor.Infrastructure.Old.Locators
{
    public abstract class LocatorBase : ILocator
    {
        private bool _isIdInitialised;
        private int _id;

        public int Id
        {
            get => _id;
            set => SetId(value);
        }

        public virtual void Initialise()
        {
            if (!_isIdInitialised)
            {
                throw new InvalidOperationException($"The {nameof(Id)} property must be set before the {nameof(Initialise)} method can be called.");
            }
        }

        // TODO: refactor to new class
        protected static int GetMultiplier0To31From0To21(int id)
        {
            // Generate a multiplier of 0,1,3,4..30,31 from id of 0,1,2,3..20,21 
            return id / 2 * 3 + id % 2; // 0..10 * 3 + 0..1
        }

        // TODO: refactor to new class
        protected static int GetTeamAlphabeticalId(int id)
        {
            var idToAlphabeticalIdMap = new[]
            {
                10, 2, 1, 4, 3, 6, 7, 0, 8, 9, 5
            };

            return idToAlphabeticalIdMap[id];
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