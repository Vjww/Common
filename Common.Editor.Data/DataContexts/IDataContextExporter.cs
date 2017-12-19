using System.Collections.Generic;
using Common.Editor.Infrastructure.Entities;
using Common.Editor.Infrastructure.Repositories;

namespace Common.Editor.Infrastructure.DataContexts
{
    public interface IDataContextExporter
    {
        void Export(IList<IRepository<IEntity>> repositories);
    }
}