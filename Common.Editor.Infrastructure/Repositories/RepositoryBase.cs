using System.Collections.Generic;
using Common.Editor.Infrastructure.DataSets;

namespace Common.Editor.Infrastructure.Repositories
{
    public abstract class RepositoryBase : List<IDataSet>, IRepository
    {
        public abstract void Export();
        public abstract void Import();
    }
}