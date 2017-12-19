using System.Collections.Generic;
using Common.Editor.Data.Entities;
using Common.Editor.Data.Repositories;

namespace Common.Editor.Data.DataContexts
{
    public interface IDataContextImporter
    {
        void Import(IList<IRepository<IEntity>> repositories);
    }
}