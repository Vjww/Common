using System;
using Common.Editor.Infrastructure.Old.Locators;

namespace Common.Editor.Infrastructure.Old.Factories
{
    public static class LocatorFactory<TLocator>
        where TLocator : class, ILocator, new()
    {
        public static TLocator New(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            return new TLocator { Id = id };
        }
    }
}