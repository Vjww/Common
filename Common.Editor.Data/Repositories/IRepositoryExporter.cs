using System.Collections.Generic;
using Common.Editor.Data.Entities;

namespace Common.Editor.Data.Repositories
{
    public interface IRepositoryExporter
    {
        void Export(IEnumerable<IEntity> entities);
    }
}