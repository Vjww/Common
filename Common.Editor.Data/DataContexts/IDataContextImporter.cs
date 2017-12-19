using System.Collections.Generic;
using Common.Editor.Infrastructure.Entities;
using Common.Editor.Infrastructure.Repositories;

namespace Common.Editor.Infrastructure.DataContexts
{
    public interface IDataContextImporter
    {
        void Import(IList<IRepository<IEntity>> repositories);
    }
}